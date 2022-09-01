using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Autofac;
using Extensions;
using Services.Core.Actions;
using Services.Core.FileManagers;
using Services.Core.PathManagers;
using WpfFileManager.Extensions;
using WpfFileManager.ViewModels.Core.Files;
using WpfFileManager.ViewModels.Core.WorkingEnvironments;

namespace WpfFileManager.ViewModels.WorkingEnvironments;

public sealed class WorkingEnvironmentVm : BaseWindowViewModel, IWorkingEnvironmentVm
{
    private readonly IActionService _actionService;
    private readonly IFileManagerService _fileManagerService;
    private readonly IPathManagerService _pathManagerService;

    private ICommand _doubleClickAction;
    private SmartCollection<IFileVm> _files;
    private string _pathValue;

    private string _search;
    private ICommand _selectPathAction;

    public WorkingEnvironmentVm(IFileManagerService fileManagerService, IPathManagerService pathManagerService,
        IActionService actionService)
    {
        _fileManagerService = fileManagerService;
        _pathManagerService = pathManagerService;
        _actionService = actionService;

        _actionService.UpdateMainSection += UpdateMainSection;

        _actionService.UpdateMainSection?.Invoke(null);
    }

    public ICommand DoubleClickAction
        => _doubleClickAction ??= new RelayCommand(c
            => _actionService.UpdateMainSection?.Invoke(_pathManagerService.CurrentPathFolder));

    public ICommand SelectPathAction
        => _selectPathAction ??= new RelayCommand(c => _actionService.UpdateMainSection?.Invoke(PathValue));

    public ReadOnlyObservableCollection<IFileVm> Files
    {
        get
        {
            if (string.IsNullOrEmpty(_search))
                return new ReadOnlyObservableCollection<IFileVm>(_files);

            var filesSearchResult = new SmartCollection<IFileVm>();

            var files = _files.Where(c
                => c.FileName.IndexOf(_search, StringComparison.InvariantCultureIgnoreCase) != -1).ToList();
            if (files?.Any() == true)
                filesSearchResult.AddRange(files);

            return new ReadOnlyObservableCollection<IFileVm>(filesSearchResult);
        }
    }

    public string Search
    {
        get => _search;
        set
        {
            SetProperty(ref _search, value);
            RaisePropertyChanged(nameof(Files));
        }
    }

    public string PathValue
    {
        get => _pathValue;
        set => SetProperty(ref _pathValue, value);
    }

    private void UpdateMainSection(string path = null)
    {
        if (string.IsNullOrEmpty(path)) path = _pathManagerService.DefaultPath;

        var files = _fileManagerService.GetFolderData(path)
            .OrderBy(c => c.Type).ThenBy(c => c.FileName).ToList();

        _files = new SmartCollection<IFileVm>();
        if (files.Any())
            _files.AddRange(files.Select(c => AutoFac.Default.Container.Resolve<IFileVm>(
                new TypedParameter(c.GetType(), c))));

        PathValue = path;

        RaisePropertyChanged(nameof(Files));
    }
}