using Combine_Sql.Console;
using Combine_Sql.Core.Builders;
using Combine_Sql.Core.Models;
using System;
using System.IO;
using System.Reflection;

namespace Combine_Sql.Core
{
    public class SettingsService : ISettingsService
    {
        public SettingsService(IInput input, IMessage message)
        {
            _input = input;
            _message = message;
        }

        private readonly IInput _input;
        private readonly IMessage _message;

        private Settings _settings;

        public Settings GetSettings()
        {
            if(_settings == null || !_settings.UsePreviousSettings)
            {
                var settingsBuilder = new SettingsBuilder();

                _message.Write("What is the directory path?");
                var directoryPath = _input.Read();

                _message.Write("Would you like to create the file too? (True/False)");
                var shouldCreateFile = _input.Read();                

                Boolean.TryParse(shouldCreateFile, out var createFileValue);

                _message.Write("What Is The ConnectionString?");
                var connectionString = _input.Read();

                settingsBuilder.ConnectionString(connectionString);
                _settings = settingsBuilder.Settings;

                SaveSettings();
            }
            return _settings;
        }

        public void SaveSettings()
        {
            var path = Assembly.GetExecutingAssembly().Location;
            var filePath = Path.Combine(path, "settings.xml");

            if (!File.Exists(filePath))
            {
                var xmlBuilder = new XmlBuilder();
                //TODO: save xml file of settings
            }
        }
    }
}
