using Combine_Sql.Core.Models;
using Newtonsoft.Json;
using System.IO;

namespace Combine_Sql.Core.Builders
{
    public class SettingsBuilder
    {
        

        public Settings Settings = new Settings();

        public SettingsBuilder ConnectionString(string connectionString)
        {
            Settings.ConnectionString = connectionString;
            return this;
        }

        public SettingsBuilder WhereAreFiles(string filePath)
        {
            Settings.FilePath = filePath;
            return this;
        }

        public SettingsBuilder ShouldCreateFile(bool shouldCreateSqlFile)
        {
            Settings.CreateFile = shouldCreateSqlFile;

            return this;
        }

        public SettingsBuilder UsePreviousSettitngs(bool usePreviousSettings)
        {
            Settings.UsePreviousSettings = usePreviousSettings;
            return this;
        }

        public SettingsBuilder LoadFromFile(string filePath)
        {
            var jsonText = File.ReadAllText(filePath);
            Settings = JsonConvert.DeserializeObject<Settings>(jsonText);
            return this;
        }
    }
}
