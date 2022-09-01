using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Markup;
using Extensions;

namespace FolderReader.ViewModels;

/// <summary>
/// Base View Model Logic
/// </summary>
public class BaseViewModel : INotifyPropertyChanging, INotifyPropertyChanged
{
    public event PropertyChangingEventHandler PropertyChanging;
    public event PropertyChangedEventHandler PropertyChanged;
    
    /// <summary>
    /// Changed trigger
    /// </summary>
    /// <param name="propertyName">field name</param>
    [NotifyPropertyChangedInvocator]
    protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    /// <summary>
    /// Changing trigger
    /// </summary>
    /// <param name="propertyName">field name</param>
    [NotifyPropertyChangingInvocator]
    protected virtual void RaisePropertyChanging([CallerMemberName] string propertyName = null)
    {
        PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(propertyName));
    }
    
    /// <summary>
    /// Set property value 
    /// </summary>
    /// <param name="storage">target object</param>
    /// <param name="value">new value</param>
    /// <param name="propertyName">field name</param>
    /// <typeparam name="T">object type</typeparam>
    /// <returns>set value status</returns>
    protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = "")
    {
        if (EqualityComparer<T>.Default.Equals(storage, value))
            return false;
        RaisePropertyChanging(propertyName);
        storage = value;
        RaisePropertyChanged(propertyName);
        return true;
    }
}