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
            var path = Assembly.GetExecutingAssembly().CodeBase;
            var filePath = Path.Combine(path, "settings.json");

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            var builder = new JsonBuilder();
            builder.AddProperty(nameof(_settings.FilePath), _settings.FilePath)
                .AddProperty(nameof(_settings.ConnectionString), _settings.ConnectionString)
                .AddProperty(nameof(_settings.CreateFile), _settings.CreateFile.ToString())
                .AddProperty(nameof(_settings.UsePreviousSettings), _settings.UsePreviousSettings.ToString());

            using (var writer = File.CreateText(filePath))
            {
                writer.Write(builder.ToString());
            }
        }
    }
}
