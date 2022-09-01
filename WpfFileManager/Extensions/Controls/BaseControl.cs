using System.Windows.Controls;
using Autofac;
using WpfFileManager.ViewModels.Core;

namespace WpfFileManager.Extensions.Controls;

/// <summary>
///     Base control logic
/// </summary>
/// <typeparam name="T">control view model</typeparam>
public abstract class BaseControl<T> : UserControl where T : IControlViewModel
{
    protected BaseControl()
    {
        ViewModel = AutoFac.Default.Container.Resolve<T>();
    }

    protected T ViewModel
    {
        get => (T)DataContext;
        private set => DataContext = value;
    }
}