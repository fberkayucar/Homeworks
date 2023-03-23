using Microsoft.Data.SqlClient;
using ShoppingListApp.Classes.Parameters;
using ShoppingListApp.NewFolder;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ShoppingListApp.Classes
{
    public class VSLgrdFill
    {
        public static void FillVSLgrd(DataGrid dataGrid, int customerID)
        {
            using (SqlConnection con = new SqlConnection(DBConnection.connectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT ProductName, ProductCount FROM ShoppingList WHERE CustomerID = @customerID", con);
                cmd.Parameters.AddWithValue("@customerID", customerID);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("ShoppingList");
                sda.Fill(dt);

                dataGrid.ItemsSource = dt.DefaultView;
            }
        }
    }
}
