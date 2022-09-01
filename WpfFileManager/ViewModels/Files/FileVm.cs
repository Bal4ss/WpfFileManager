using System.Diagnostics;
using System.Windows.Input;
using System.Windows.Media;
using Entities.Enums;
using Entities.Files;
using Extensions;
using Services.Core.Actions;
using Services.Core.DB;
using WpfFileManager.Extensions;
using WpfFileManager.ViewModels.Core.Files;

namespace WpfFileManager.ViewModels.Files;

public class FileVm : BaseViewModel, IFileVm
{
    private readonly IActionService _actionService;

    private readonly FileModel _model;
    private readonly IMySqlService _mySqlService;
    private ICommand _doubleClickAction;

    private ICommand _singleClickAction;

    public FileVm(IActionService actionService, IMySqlService mySqlService, FileModel model)
    {
        _actionService = actionService;
        _mySqlService = mySqlService;

        _model = model;

        Icon = ResourcesRepository.GetGeometryGroup(_model.Type == FileTypes.Folder
            ? Fields.FolderIcon
            : Fields.ProgramIcon);
    }

    public ICommand SingleClickAction
        => _singleClickAction ??= new RelayCommand(c => _actionService.UpdateSideSection?.Invoke(_model));

    public ICommand DoubleClickAction
        => _doubleClickAction ??= new RelayCommand(c => DoubleClickEvent());

    public GeometryGroup Icon { get; }

    public string FileName => _model.FileName;

    private void DoubleClickEvent()
    {
        if (_model.Type == FileTypes.Folder)
        {
            _actionService.UpdateMainSection?.Invoke(_model.FullPath);
            return;
        }

        var process = new Process
        {
            StartInfo = new ProcessStartInfo(_model.FullPath),
            EnableRaisingEvents = true
        };
        process.Start();

        _mySqlService.AppendFile(_model);
    }

    private static class Fields
    {
        public const string FolderIcon = "FolderIcon";
        public const string ProgramIcon = "ProgramIcon";
    }
}