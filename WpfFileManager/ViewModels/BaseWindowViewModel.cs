using FolderReader.ViewModels.Core;

namespace FolderReader.ViewModels;

public class BaseWindowViewModel : BaseViewModel, IWindowViewModel
{
    public string Title { get; set; }
}