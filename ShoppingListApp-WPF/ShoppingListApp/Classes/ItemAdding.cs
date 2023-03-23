using Microsoft.Data.SqlClient;
using ShoppingListApp.Classes.Parameters;
using ShoppingListApp.NewFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using static System.Net.Mime.MediaTypeNames;

namespace ShoppingListApp.Classes
{
    public class ItemAdding
    {
        public static void ItemAdd(TextBox ProductName)
        {
            SqlConnection con = new SqlConnection(DBConnection.connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Products (ProductName) VALUES (@ProductName)", con);
            cmd.Parameters.AddWithValue("@ProductName", ProductName.Text);
            cmd.ExecuteScalar();
            con.Close();
        }
    }
}
