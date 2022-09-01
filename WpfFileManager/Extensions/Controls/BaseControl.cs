using System.Windows.Controls;
using Autofac;
using FolderReader.ViewModels.Core;

namespace FolderReader.Extensions.Controls;

public abstract class BaseControl<T> : Control where T : IControlViewModel
{
    protected BaseControl() : base()
    {
        ViewModel = AutoFac.Default.Container.Resolve<T>();
    }

    protected T ViewModel
    {
        get => (T)DataContext;
        private init => DataContext = value;
    }
}