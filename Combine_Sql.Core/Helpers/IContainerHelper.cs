using System;

namespace Combine_Sql.Core.Helpers
{
    public interface IContainerHelper
    {
        T Create<T>(Type type);
    }
}