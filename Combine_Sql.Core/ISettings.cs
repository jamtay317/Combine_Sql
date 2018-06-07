using Combine_Sql.Core.Models;

namespace Combine_Sql.Core
{
    public interface ISettingsService
    {
        void SaveSettings();

        Settings GetSettings();
    }
}
