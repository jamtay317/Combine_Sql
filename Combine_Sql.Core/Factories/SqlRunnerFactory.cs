using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Combine_Sql.Core.Helpers;

namespace Combine_Sql.Core.Factories
{
    public class SqlRunnerFactory:ISqlRunnerFacory
    {
        private readonly IContainerHelper _containerHelper;
        private Dictionary<string, ISqlRunner> runners = new Dictionary<string, ISqlRunner>();


        public SqlRunnerFactory(IContainerHelper containerHelper)
        {
            _containerHelper = containerHelper;
            LoadRunners();
        }

        private void LoadRunners()
        {
            var assembly = Assembly.Load("Combine_Sql.Core");
            var runnerTypes = assembly.GetTypes()
                .Where(x => x.IsClass)
                .Where(x => !x.IsAbstract)
                .Where(x => typeof(ISqlRunner).IsAssignableFrom(x))
                .ToList();

            foreach (var runnerType in runnerTypes)
            {
                runners.Add(runnerType.Name, _containerHelper.Create<ISqlRunner>(runnerType));
            }
        }

        public ISqlRunner GetRunner(SqlRunnerType runnerType)
        {
            var name = $"{runnerType}Runner";
            if(!runners.ContainsKey(name))throw new NullReferenceException();
            return runners[name];
        }
    }
}