using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace DataAccessLayer
{
    public class Equalize
    {
        public static void Equalizer(SLEntity sL)
        {

            using (SqlCommand command = new SqlCommand("SELECT TOP 1 CustomerID FROM Username ORDER BY CustomerID DESC", DBConnect.GetConnection()))
            {
                int customerID = (int)command.ExecuteScalar();
                sL.CustomerID = customerID;
            }
        }
    }
}
