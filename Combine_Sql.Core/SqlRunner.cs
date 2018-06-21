using System;
using System.IO;
using Combine_Sql.Console;

namespace Combine_Sql.Core
{
    public abstract class SqlRunner:ISqlRunner
    {
        protected string ConnectionString;

        protected IMessage Message;
        protected IInput Input;

        protected const string SucessMessage = "Executed {0} Sucessfully";

        protected SqlRunner(IMessage message, IInput input)
        {
            Message = message;
            Input = input;
        }

        protected abstract void RunCommand(string sql);
            
        public void Run(string sql, string fileName)
        {
            UpdateConnectionStringIfNull();

            try
            {
                RunCommand(sql);
            }
            catch (Exception e)
            {
                AllertError(fileName, e);
            }
            Message.Write(string.Format(SucessMessage, fileName));
        }

        public virtual void RunAll(string directoryName)
        {
            var dirInfo = new DirectoryInfo(directoryName);

            var files = dirInfo.GetFiles();
            foreach (var file in files)
            {
                var sql = File.ReadAllText(file.FullName);
                Run(sql, file.Name);
            }

            var directories = dirInfo.GetDirectories();
            foreach (var directory in directories)
            {
                RunAll(directory.FullName);
            }
        }

        public virtual void RunAll(string directoryPath, string connectionString)
        {
            ConnectionString = connectionString;
            RunAll(directoryPath);
        }
        protected void UpdateConnectionStringIfNull()
        {
            if (string.IsNullOrWhiteSpace(ConnectionString))
            {
                Message.Write("What is Connection String");
                ConnectionString = Input.Read();
            }
        }
        protected void AllertError(string fileName, Exception e)
        {
            Message.Write(e.Message);
            Message.WriteWarning($"The File is {fileName}");
            Message.Write("Press any Key to exit");

            Message.WriteError(e.ToString());

            Input.Read();
        }
    }
}