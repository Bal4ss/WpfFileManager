using Autofac;
using Services.Actions;
using Services.Core.Actions;
using Services.Core.DB;
using Services.Core.FileManagers;
using Services.Core.Json;
using Services.Core.Languages;
using Services.Core.PathManagers;
using Services.Core.Settings;
using Services.DB;
using Services.FileManagers;
using Services.Json;
using Services.Languages;
using Services.PathManagers;
using Services.Settings;
using WpfFileManager.ViewModels.Core.Files;
using WpfFileManager.ViewModels.Core.SideSections;
using WpfFileManager.ViewModels.Core.WorkingEnvironments;
using WpfFileManager.ViewModels.Files;
using WpfFileManager.ViewModels.SideSections;
using WpfFileManager.ViewModels.WorkingEnvironments;

namespace WpfFileManager.Extensions;

/// <summary>
///     DI
/// </summary>
public class AutoFac
{
    private AutoFac()
    {
        var builder = new ContainerBuilder();

        builder.RegisterType<WorkingEnvironmentVm>().As<IWorkingEnvironmentVm>();
        builder.RegisterType<SideSectionVm>().As<ISideSectionVm>();
        builder.RegisterType<FileVm>().As<IFileVm>();

        builder.RegisterType<FileManagerService>().As<IFileManagerService>();
        builder.RegisterType<PathManagerService>().As<IPathManagerService>();
        builder.RegisterType<GlobalSettings>().As<IGlobalSettings>();
        builder.RegisterType<JsonService>().As<IJsonService>();

        builder.RegisterType<ActionService>().As<IActionService>().SingleInstance();
        builder.RegisterType<LanguageService>().As<ILanguageService>().SingleInstance();
        builder.RegisterType<MySqlService>().As<IMySqlService>().SingleInstance();

        Container = builder.Build();
    }

    public static AutoFac Default { get; } = new();

    public IContainer Container { get; }
}