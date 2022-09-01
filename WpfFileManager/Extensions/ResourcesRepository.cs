using System;
using System.Windows;
using System.Windows.Media;

namespace WpfFileManager.Extensions;

/// <summary>
///     Repository of resources
/// </summary>
public static class ResourcesRepository
{
    public static GeometryGroup GetGeometryGroup(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentNullException(nameof(name));
        return (GeometryGroup)Application.Current.Resources[name];
    }
}