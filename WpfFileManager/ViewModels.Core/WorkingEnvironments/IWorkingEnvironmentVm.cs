using System.Collections.ObjectModel;
using System.Windows.Input;
using WpfFileManager.ViewModels.Core.Files;

namespace WpfFileManager.ViewModels.Core.WorkingEnvironments;

/// <summary>
///     Working environment view model
/// </summary>
public interface IWorkingEnvironmentVm : IWindowViewModel
{
    ICommand DoubleClickAction { get; }
    ICommand SelectPathAction { get; }
    ReadOnlyObservableCollection<IFileVm> Files { get; }
    string Search { get; set; }
    string PathValue { get; set; }
}