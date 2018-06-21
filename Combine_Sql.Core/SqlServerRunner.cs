using System.Data.SqlClient;
using Combine_Sql.Console;

namespace Combine_Sql.Core
{
    public class SqlServerRunner:SqlRunner,ISqlRunner
    {
        public SqlServerRunner(IMessage message, IInput input) : base(message, input)
        {
        }

        protected override void RunCommand(string sql)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                using (var command = new SqlCommand(sql, sqlConnection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}