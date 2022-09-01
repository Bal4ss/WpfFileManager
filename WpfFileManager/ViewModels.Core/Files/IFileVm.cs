using System.Windows.Input;
using System.Windows.Media;

namespace WpfFileManager.ViewModels.Core.Files;

/// <summary>
///     File view model
/// </summary>
public interface IFileVm : IControlViewModel
{
    ICommand SingleClickAction { get; }
    ICommand DoubleClickAction { get; }
    GeometryGroup Icon { get; }
    string FileName { get; }
}