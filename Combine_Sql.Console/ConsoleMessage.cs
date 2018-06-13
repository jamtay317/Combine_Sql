namespace Combine_Sql.Console
{
    public class ConsoleMessage:IMessage
    {
        public void Write(string message)
        {
            System.Console.WriteLine(message);
        }

        public void WriteError(string message)
        {
            System.Console.ForegroundColor = System.ConsoleColor.Red;
            Write(message);
            System.Console.ForegroundColor = System.ConsoleColor.White;
        }

        public void WriteWarning(string message)
        {
            System.Console.ForegroundColor = System.ConsoleColor.Yellow;
            Write(message);
            System.Console.ForegroundColor = System.ConsoleColor.White;
        }
    }
}