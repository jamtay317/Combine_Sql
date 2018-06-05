namespace Combine_Sql.Console
{
    public class ConsoleMessage:IMessage
    {
        public void Write(string message)
        {
            System.Console.WriteLine(message);
        }
    }
}