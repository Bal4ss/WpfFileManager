using System.Collections.ObjectModel;
using System.Linq;
using Autofac;
using Extensions;
using FolderReader.Extensions;
using FolderReader.ViewModels.Core.Files;
using FolderReader.ViewModels.Core.WorkingEnvironments;
using Services.Core.Actions;
using Services.Core.FileManagers;

namespace FolderReader.ViewModels.WorkingEnvironments;

public sealed class WorkingEnvironmentVm : BaseWindowViewModel, IWorkingEnvironmentVm
{
    private readonly IFileManagerService _fileManagerService;

    private string _search;
    private string _pathValue;
    private SmartCollection<IFileVm> _files;

    private const string TestPath = @"E:\Downloads";
    
    public WorkingEnvironmentVm(IFileManagerService fileManagerService, IActionService actionService)
    {
        _fileManagerService = fileManagerService;

        actionService.UpdateMainSection += UpdateMainSection;

        UpdateMainSection();
    }

    public ReadOnlyObservableCollection<IFileVm> Files => new(_files);

    public string Search
    {
        get => _search;
        set => SetProperty(ref _search, value, nameof(Search));
    }

    public string PathValue
    {
        get => _pathValue;
        set => SetProperty(ref _pathValue, value, nameof(PathValue));
    }

    private void UpdateMainSection(string path = null)
    {
        if (string.IsNullOrEmpty(path))
        {
            //TODO
            path = TestPath;
        }

        var files = _fileManagerService.GetFolderData(path)
            .OrderBy(c => c.Type).ThenBy(c => c.FileName).ToList();

        _files = new SmartCollection<IFileVm>();
        if (files.Any())
            _files.AddRange(files.Select(c => AutoFac.Default.Container.Resolve<IFileVm>(
                new TypedParameter(c.GetType(), c))));
    }
}