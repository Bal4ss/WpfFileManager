using Autofac;
using FolderReader.ViewModels.Core.Files;
using FolderReader.ViewModels.Core.WorkingEnvironments;
using FolderReader.ViewModels.Files;
using FolderReader.ViewModels.WorkingEnvironments;
using Services.Actions;
using Services.Core.Actions;
using Services.Core.FileManagers;
using Services.Core.PathManagers;
using Services.FileManagers;
using Services.PathManagers;

namespace FolderReader.Extensions;

/// <summary>
/// DI
/// </summary>
public class AutoFac
{
    private AutoFac()
    {
        var builder = new ContainerBuilder();

        builder.RegisterType<WorkingEnvironmentVm>().As<IWorkingEnvironmentVm>();
        builder.RegisterType<FileVm>().As<IFileVm>();
        
        builder.RegisterType<FileManagerService>().As<IFileManagerService>();
        builder.RegisterType<PathManagerService>().As<IPathManagerService>();
        
        builder.RegisterType<ActionService>().As<IActionService>().SingleInstance();

        Container = builder.Build();
    }
    
    public static AutoFac Default { get; } = new();

    public IContainer Container { get; }
}