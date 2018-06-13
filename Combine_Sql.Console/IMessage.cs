namespace Combine_Sql.Console
{
    public interface IMessage
    {
        void Write(string message);

        void WriteWarning(string message);

        void WriteError(string message);
    }
}