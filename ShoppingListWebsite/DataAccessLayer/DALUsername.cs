using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace DataAccessLayer
{
    public class DALUsername
    {
        public static int SetUsername(UsernameEntity prm)
        {
            string Username = prm.Username;
            SqlCommand com = new SqlCommand("insert into Username(Username) values (UserName)", DBConnect.GetConnection());
            if (com.Connection.State != ConnectionState.Open)
            {
                com.Connection.Open();
            }
            com.Parameters.AddWithValue("@Username", Username);
            return com.ExecuteNonQuery();
        }
        public static List<UsernameEntity> GetUsernameID()
        {
            List<UsernameEntity> list = new List<UsernameEntity>();
            SqlCommand com = new SqlCommand("insert into Username(Username) values (@UserName)", DBConnect.GetConnection());
            if (com.Connection.State != ConnectionState.Open)
            {
                com.Connection.Open();
            }
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                UsernameEntity p = new UsernameEntity();
                p.CustomerID = Convert.ToInt32(dr["CustomerID"]);
                p.Username = dr["Username"].ToString();
                list.Add(p);
            }
            dr.Close();
            return list;
        }
    }
}
