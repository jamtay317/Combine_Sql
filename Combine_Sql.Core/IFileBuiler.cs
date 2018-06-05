namespace Combine_Sql.Core
{
    public interface IFileBuiler
    {
        IFileBuiler Append(string path);

        void Clear();
    }
}