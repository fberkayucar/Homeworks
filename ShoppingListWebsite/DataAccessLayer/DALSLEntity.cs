using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace DataAccessLayer
{
    public class DALSLEntity
    {
        public static int GetShoppingList(SLEntity prm)
        {
            string Productname = prm.ProductName;
            int ProductCount = prm.ProductCount;
            SqlCommand com = new SqlCommand("insert into ShoppingList(ProductName, ProductCount) values (Productname, ProductCount)", DBConnect.GetConnection());
            if (com.Connection.State != ConnectionState.Open)
            {
                com.Connection.Open();
            }
            com.Parameters.AddWithValue("@Productname", Productname);
            com.Parameters.AddWithValue("@ProductCount", ProductCount);
            return com.ExecuteNonQuery();
        }
        public static List<SLEntity> GetShoppingList()
        {
            List<SLEntity> list = new List<SLEntity>();
            SqlCommand com = new SqlCommand("select * from ShoppingList", DBConnect.GetConnection());
            if (com.Connection.State != ConnectionState.Open)
            {
                com.Connection.Open();
            }
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                SLEntity p = new SLEntity();
                p.ProductName = dr["ProductName"].ToString();
                p.ProductCount = Convert.ToInt32(dr["ProductCount"]);
                list.Add(p);
            }
            
            dr.Close();
            return list;
        }
    }
}
