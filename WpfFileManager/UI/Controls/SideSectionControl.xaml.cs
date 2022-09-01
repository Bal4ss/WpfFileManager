using WpfFileManager.Extensions.Controls;
using WpfFileManager.ViewModels.Core.SideSections;

namespace WpfFileManager.UI.Controls;

/// <summary>
///     Side section control
/// </summary>
public partial class SideSectionControl : BaseControl<ISideSectionVm>
{
    public SideSectionControl()
    {
        InitializeComponent();
    }
}