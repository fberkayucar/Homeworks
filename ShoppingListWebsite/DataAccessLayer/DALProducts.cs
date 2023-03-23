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
    public class DALProducts
    {
        public static int GetProduct(ProductsEntity prm)
        {
            string Productname = prm.ProductName;
            SqlCommand com = new SqlCommand("insert into Products(ProductName) values (Productname)", DBConnect.GetConnection());
            if (com.Connection.State != ConnectionState.Open)
            {
                com.Connection.Open();
            }
            com.Parameters.AddWithValue("@Productname", Productname);
            return com.ExecuteNonQuery();
        }
        public static List<ProductsEntity> GetProducts()
        {
            List<ProductsEntity> list = new List<ProductsEntity>();
            SqlCommand com = new SqlCommand("select * from Products", DBConnect.GetConnection());
            if (com.Connection.State != ConnectionState.Open)
            {
                com.Connection.Open();
            }
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                ProductsEntity p = new ProductsEntity();
                p.ProductName = dr["ProductName"].ToString();
                list.Add(p);
            }
            dr.Close();
            return list;
        }
    }
}
