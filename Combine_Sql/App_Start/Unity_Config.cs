using Combine_Sql.Console;
using Combine_Sql.Core;
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
            container.RegisterType<ISqlRunner, MySqlRunner>();
            container.RegisterType<ISettingsService, SettingsService>();

            return container;
        }
    }
}