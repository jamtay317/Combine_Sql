using Combine_Sql.Console;
using MySql.Data.MySqlClient;

namespace Combine_Sql.Core
{
    public class MySqlRunner:SqlRunner ,ISqlRunner
    {

        public MySqlRunner(IMessage message, IInput input):base(message, input)
        {
        }

        protected override void RunCommand(string sql)
        {
            using (var sqlConnection = new MySqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                using (var command = new MySqlCommand(sql, sqlConnection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}