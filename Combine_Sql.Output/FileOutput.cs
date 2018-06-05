using System.IO;

namespace Combine_Sql.Output
{
    public class FileOutput:IFileOutput
    {
        public void Create(string path, string extension, string text, string fileName)
        {
            var fullName = $"{Path.Combine(path, fileName)}{extension}";
            
            using (var textWriter = new StreamWriter(fullName))
            {
                textWriter.Write(text);
                textWriter.Close();
            }
        }
    }
}