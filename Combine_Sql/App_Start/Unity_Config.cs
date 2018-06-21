using Combine_Sql.Console;
using Combine_Sql.Core;
using Combine_Sql.Core.Factories;
using Combine_Sql.Core.Helpers;
using Combine_Sql.Helpers;
using Combine_Sql.Output;
using Microsoft.Practices.Unity;

namespace Combine_Sql
{
    public static class Unity_Config
    {
        public static IUnityContainer RegisterInstances(this IUnityContainer container)
        {
            container.RegisterType<IFileCombiner, FileCombiner>();
            container.RegisterType<IInput, ConsoleInput>();
            container.RegisterType<IMessage, ConsoleMessage>();
            container.RegisterType<IFileReader, FileReader>();
            container.RegisterType<IFileBuiler, FileBuiler>();
            container.RegisterType<IFileOutput, FileOutput>();
            container.RegisterType<ISqlRunnerFacory, SqlRunnerFactory>();
            container.RegisterType<ISettingsService, SettingsService>();
            container.RegisterType<IContainerHelper, ContainerHelper>();

            return container;
        }
    }
}