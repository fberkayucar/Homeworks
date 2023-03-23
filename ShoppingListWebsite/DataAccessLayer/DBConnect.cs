using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DBConnect
    {
        public static SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=DESKTOP-V2IEA5C\\MSSQLSERVER01;Initial Catalog=MyDB;Integrated Security=True;TrustServerCertificate=True";
            return conn;
        }
    }
}
