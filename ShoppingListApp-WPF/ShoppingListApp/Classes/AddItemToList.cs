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

namespace ShoppingListApp.Classes
{
    class AddItemToList
    {
        public static bool AddItem(ComboBox cmb, TextBox txt, int customerID)
        {
            using (SqlConnection con = new SqlConnection(DBConnection.connectionString))
            {
                con.Open();
                string productName = cmb.Text;
                int productCount = int.Parse(txt.Text);

                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM ShoppingList WHERE ProductName = @ProductName and CustomerID = @customerID", con);
                cmd.Parameters.AddWithValue("@ProductName", productName);
                cmd.Parameters.AddWithValue("@customerID", customerID);
                int count = (int)cmd.ExecuteScalar();

                if (count > 0)
                {
                    SqlCommand cmdUpdate = new SqlCommand("UPDATE ShoppingList SET ProductCount = ProductCount + @productCount WHERE ProductName = @ProductName and CustomerID = @customerID", con);
                    cmdUpdate.Parameters.AddWithValue("@ProductName", productName);
                    cmdUpdate.Parameters.AddWithValue("@productCount", productCount);
                    cmdUpdate.Parameters.AddWithValue("@customerID", customerID);
                    cmdUpdate.ExecuteNonQuery();
                }
                else
                {
                    SqlCommand insertCommand = new SqlCommand("INSERT INTO ShoppingList (ProductName, ProductCount, CustomerID) VALUES (@productName, @productCount, @customerID)", con);
                    insertCommand.Parameters.AddWithValue("@productName", productName);
                    insertCommand.Parameters.AddWithValue("@productCount", productCount);
                    insertCommand.Parameters.AddWithValue("@customerID", customerID);
                    insertCommand.ExecuteNonQuery();
                }
            }
            return true;
        }


    }
}


