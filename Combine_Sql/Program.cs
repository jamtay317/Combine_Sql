using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
