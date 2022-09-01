using System.Windows.Input;
using System.Windows.Media;

namespace WpfFileManager.ViewModels.Core.Files;

public interface IFileVm : IControlViewModel
{
    ICommand SingleClickAction { get; }
    ICommand DoubleClickAction { get; }
    GeometryGroup Icon { get; }
    string FileName { get; }
}