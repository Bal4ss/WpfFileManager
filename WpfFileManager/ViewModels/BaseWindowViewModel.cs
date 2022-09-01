using WpfFileManager.ViewModels.Core;

namespace WpfFileManager.ViewModels;

public class BaseWindowViewModel : BaseViewModel, IWindowViewModel
{
    public string Title { get; set; }
}