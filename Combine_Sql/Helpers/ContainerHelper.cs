using System;
using Combine_Sql.Core.Helpers;
using Microsoft.Practices.Unity;

namespace Combine_Sql.Helpers
{
    public class ContainerHelper:IContainerHelper
    {
        private readonly IUnityContainer _container;

        public ContainerHelper(IUnityContainer container)
        {
            _container = container;
        }
        public T Create<T>(Type type)
        {
            return (T) _container.Resolve(type);
        }
    }
}