namespace Combine_Sql.Output
{
    public interface IFileOutput
    {
        void Create(string path, string extension, string text, string fileName);
    }
}