using System;
using System.IO;
using System.Runtime.InteropServices;
using Combine_Sql.Console;
using Combine_Sql.Output;

namespace Combine_Sql.Core
{
    public class FileCombiner:IFileCombiner
    {
        private readonly IInput _input;
        private readonly IMessage _message;
        private readonly IFileReader _fileReader;
        private readonly IFileOutput _output;
        private readonly ISqlRunner _sqlRunner;
        private readonly ISettingsService _settingsService;

        public FileCombiner(IInput input, IMessage message, IFileReader fileReader, IFileOutput output,ISqlRunner sqlRunner , ISettingsService settingsService)
        {
            _input = input;
            _message = message;
            _fileReader = fileReader;
            _output = output;
            _sqlRunner = sqlRunner;
            _settingsService = settingsService;
        }

        public void Run()
        {
            while (true)
            {
                var settings = _settingsService.GetSettings();

                if (Directory.Exists(settings.FilePath))
                {
                    var combinedFiles = _fileReader.Read(settings.FilePath);

                    if (settings.CreateFile)
                    {
                        _output.Create(settings.FilePath, ".sql", combinedFiles, "UpdateDatabase");
                        _message.Write($"The File Was Created at { settings.FilePath }");

                    }

                    while (settings.UsePreviousSettings)
                    {
                        _message.Write("Press any key to run");
                        _input.Read();

                        DeleteFileIfExists(settings.FilePath);
                        _sqlRunner.RunAll(settings.FilePath, settings.ConnectionString);
                    }
                }
                else
                {
                    _message.Write("That Directory doesnt exist, please try again");
                }
            }    
        }

        private static void DeleteFileIfExists(string directoryPath)
        {
            var filePath = Path.Combine(directoryPath, "UpdateDatabase.sql");
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}