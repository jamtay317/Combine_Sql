using System.IO;

namespace Combine_Sql.Core
{
    public class FileReader:IFileReader
    {
        private readonly IFileBuiler _fileBuiler;

        public FileReader(IFileBuiler fileBuiler)
        {
            _fileBuiler = fileBuiler;
        }

        public string Read(string directoryPath)
        {
            foreach (var file in Directory.GetFiles(directoryPath))
            {
                _fileBuiler.Append(file);
            }

            foreach (var directory in Directory.GetDirectories(directoryPath))
            {
                Read(directory);
            }

            return _fileBuiler.ToString();
        }
    }
}