using WpfFileManager.Extensions.Controls;
using WpfFileManager.ViewModels.Core.SideSections;

namespace WpfFileManager.UI.Controls;

public partial class SideSectionControl : BaseControl<ISideSectionVm>
{
    public SideSectionControl()
    {
        InitializeComponent();
    }
}