using System.Collections.ObjectModel;
using FolderReader.ViewModels.Core.Files;

namespace FolderReader.ViewModels.Core.WorkingEnvironments;

public interface IWorkingEnvironmentVm : IWindowViewModel
{
    ReadOnlyObservableCollection<IFileVm> Files { get; }
    string Search { get; set; }
    string PathValue { get; set; }
}