using System.Diagnostics;
using System.Windows.Input;
using System.Windows.Media;
using Entities.Enums;
using Entities.Files;
using Extensions;
using FolderReader.Extensions;
using FolderReader.ViewModels.Core.Files;
using Services.Core.Actions;

namespace FolderReader.ViewModels.Files;

public class FileVm : BaseViewModel, IFileVm
{
    private static class Fields
    {
        public const string FolderIcon = "FolderIcon";
        public const string ProgramIcon = "ProgramIcon";
    }
    
    private readonly IActionService _actionService;
    
    private readonly FileModel _model;

    public FileVm(IActionService actionService, FileModel model)
    {
        _actionService = actionService;
        
        _model = model;

        Icon = ResourcesRepository.GetGeometryGroup(_model.Type == FileTypes.Folder 
            ? Fields.FolderIcon
            : Fields.ProgramIcon);

        SingleClickAction = new RelayCommand(c => _actionService.UpdateSideSection?.Invoke(_model));
        DoubleClickAction = new RelayCommand(c => DoubleClickEvent());
    }

    public ICommand SingleClickAction { get; }

    public ICommand DoubleClickAction { get; }

    public GeometryGroup Icon { get; }

    public string FileName => _model.FileName;

    private void DoubleClickEvent()
    {
        if (_model.Type == FileTypes.Folder)
        {
            _actionService.UpdateMainSection?.Invoke(_model.FullPath);   
        }
        
        var process = new Process
        {
            StartInfo = new ProcessStartInfo(_model.FullPath),
            EnableRaisingEvents = true
        };
        process.Start();
    }
}