using FolderReader.Extensions.Windows;
using FolderReader.ViewModels.Core.WorkingEnvironments;

namespace FolderReader.UI.Forms;

public partial class WorkingEnvironmentWindow : BaseWindow<IWorkingEnvironmentVm>
{
    public WorkingEnvironmentWindow() : base()
    {
        InitializeComponent();
    }
}