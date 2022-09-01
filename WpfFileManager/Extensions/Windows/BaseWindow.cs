using System.Windows;
using System.Windows.Markup;
using Autofac;
using FolderReader.ViewModels.Core;

namespace FolderReader.Extensions.Windows;

/// <summary>
/// Base window logic
/// </summary>
/// <typeparam name="T">window view model</typeparam>
public abstract class BaseWindow<T> : Window where T : IWindowViewModel
{
    protected BaseWindow() : base()
    {
        ViewModel = AutoFac.Default.Container.Resolve<T>();
    }

    protected BaseWindow(string title) : this()
    {
        ViewModel.Title = title;
    }

    protected T ViewModel
    {
        get => (T)DataContext;
        private init => DataContext = value;
    }
}