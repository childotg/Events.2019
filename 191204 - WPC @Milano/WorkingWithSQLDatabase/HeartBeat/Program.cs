using System;
using System.Data.SqlClient;
using System.Threading;

namespace HeartBeat
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Thread.Sleep(1000);
                try
                {
                    SqlHeartBeat();
                }
                catch (Exception ex)
                {
                    //do nothing
                }
                
            }
        }

        private static void SqlHeartBeat()
        {
            var serverName = "wwsd";
            var query = "SELECT *,@@SERVERNAME FROM sys.database_service_objectives";
            var password = "[removed]";
            var connsStr = string.Format(
                "Server=tcp:{1}.database.windows.net,1433;Initial Catalog=dtu-based;Persist Security Info=False;User ID=wwsdAdmin;Password={0};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;",
                password,serverName);
            using (var conn=new SqlConnection(connsStr))
            {
                conn.Open();
                var command = conn.CreateCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = query;
                var reader = command.ExecuteReader();
                reader.Read();
                Console.WriteLine($"{DateTime.UtcNow}: {reader[0]} - {reader[1]} - {reader[2]} - {reader[4]}");
            }
        }
    }
}
