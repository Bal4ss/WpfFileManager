using System.Diagnostics;
using System.Threading.Tasks;
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
    private static class Fields
    {
        public const string FolderIcon = "FolderIcon";
        public const string ProgramIcon = "ProgramIcon";
    }
    
    private readonly IActionService _actionService;
    private readonly ISqLiteService _sqLiteService;

    private readonly FileModel _model;

    private ICommand _singleClickAction;
    private ICommand _doubleClickAction;

    public FileVm(IActionService actionService, ISqLiteService sqLiteService, FileModel model)
    {
        _actionService = actionService;
        _sqLiteService = sqLiteService;

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
        
        _sqLiteService.AppendFile(_model);
    }
}