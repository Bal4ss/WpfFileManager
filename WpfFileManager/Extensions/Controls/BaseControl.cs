using System.Windows.Controls;
using Autofac;
using WpfFileManager.ViewModels.Core;

namespace WpfFileManager.Extensions.Controls;

public abstract class BaseControl<T> : UserControl where T : IControlViewModel
{
    protected BaseControl() : base()
    {
        ViewModel = AutoFac.Default.Container.Resolve<T>();
    }

    protected T ViewModel
    {
        get => (T)DataContext;
        private set => DataContext = value;
    }
}