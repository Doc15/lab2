using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Project1
{
    class Class2
    {
        public static MySqlConnection GetDbConnection()
        {
            string host = "192.168.70.5";
            int port = 3306;
            string database = "library";
            string username = "appuser";
            string password = "pass";

            return Class1.GetDBConnection(host, port, database, username, password);

        }
    }
}
