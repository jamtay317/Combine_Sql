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

        public FileCombiner(IInput input, IMessage message, IFileReader fileReader, IFileOutput output,ISqlRunner sqlRunner)
        {
            _input = input;
            _message = message;
            _fileReader = fileReader;
            _output = output;
            _sqlRunner = sqlRunner;
        }

        public void Run()
        {
            while (true)
            {
                _message.Write("What is the directory path?");
                var directoryPath = _input.Read();

                if (Directory.Exists(directoryPath))
                {
                    var combinedFiles = _fileReader.Read(directoryPath);

                    //_output.Create(directoryPath,".sql",combinedFiles,"UpdateDatabase");
                    //_message.Write($"The File Was Created at { directoryPath }");

                    _sqlRunner.RunAll(directoryPath);

                    
                }
                else
                {
                    _message.Write("That Directory doesnt exist, please try again");
                }


            }    
        }
    }
}