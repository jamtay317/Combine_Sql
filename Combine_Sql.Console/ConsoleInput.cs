namespace Combine_Sql.Console
{
    public class ConsoleInput:IInput
    {
        public string Read()
        {
            return System.Console.ReadLine();
        }
    }
}