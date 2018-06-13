using System;
using System.IO;
using Combine_Sql.Console;
using MySql.Data.MySqlClient;

namespace Combine_Sql.Core
{
    public class MySqlRunner:ISqlRunner
    {
        private readonly IMessage _message;
        private readonly IInput _input;
        private string _connectionString;

        public MySqlRunner(IMessage message, IInput input)
        {
            _message = message;
            _input = input;
        }

        public void RunAll(string directoryPath, string connectionString)
        {
            _connectionString = connectionString;
            RunAll(directoryPath);
        }

        public void RunAll(string directoryPath)
        {
            var dirInfo = new DirectoryInfo(directoryPath);

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
        

        public void Run(string sql, string fileName)
        {
            if (string.IsNullOrWhiteSpace(_connectionString))
            {
                _message.Write("What is Connection String");
                _connectionString = _input.Read();
            }

            try
            {
                using (var sqlConnection = new MySqlConnection(_connectionString))
                {
                    sqlConnection.Open();
                    using (var command = new MySqlCommand(sql, sqlConnection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                _message.Write(e.Message);
                _message.WriteWarning($"The File is {fileName}");
                _message.Write("Press any Key to exit");

                _message.WriteError(e.ToString());

                _input.Read();
                

            }
            _message.Write($"executed {fileName} sucessfully");
        }

        
    }
}