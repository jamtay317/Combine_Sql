using Combine_Sql.Core;
using Microsoft.Practices.Unity;

namespace Combine_Sql
{
    class Program
    {
        static void Main(string[] args)
        {

            var container = new UnityContainer();
            container.RegisterInstances();

            var fileCombiner = container.Resolve<IFileCombiner>();
            fileCombiner.Run();
        }
    }
}
