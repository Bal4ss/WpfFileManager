using Autofac;
using Services.Core.Actions;
using WpfFileManager.Extensions;
using WpfFileManager.Extensions.Windows;
using WpfFileManager.ViewModels.Core.WorkingEnvironments;

namespace WpfFileManager.UI.Forms;

/// <summary>
///     Main window
/// </summary>
public partial class WorkingEnvironmentWindow : BaseWindow<IWorkingEnvironmentVm>
{
    public WorkingEnvironmentWindow()
    {
        InitializeComponent();

        var actionService = AutoFac.Default.Container.Resolve<IActionService>();

        actionService.UpdateMainSection += c => MainSectionScroll.ScrollToTop();
    }
}