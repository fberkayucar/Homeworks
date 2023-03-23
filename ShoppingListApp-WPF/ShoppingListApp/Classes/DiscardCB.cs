using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using ShoppingListApp.NewFolder;
using ShoppingListApp.Classes.Parameters;

namespace ShoppingListApp.Classes
{
    public class DiscardCB
    {
        public static bool Discard(ComboBox cmb, TextBox txt)
        {
            int i = 0;
            using (SqlConnection con = new SqlConnection(DBConnection.connectionString))
            {
                con.Open();
                string productName = cmb.Text;
                int productCount = int.Parse(txt.Text);
                int customerID = Prm.CustomerID;

                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM ShoppingList WHERE ProductName = @ProductName", con);
                cmd.Parameters.AddWithValue("@ProductName", productName);
                int count = (int)cmd.ExecuteScalar();
                if (count > 0)
                {
                    cmd = new SqlCommand("UPDATE ShoppingList SET ProductCount = ProductCount - @ProductCount WHERE ProductName = @ProductName", con);
                    cmd.Parameters.AddWithValue("@ProductCount", productCount);
                    cmd.Parameters.AddWithValue("@ProductName", productName);
                    i = cmd.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("There is no such product in the list");
                }
            }
            return i > 0;
        }
        public static bool FillDC(ComboBox cmb)
        {
            
            int cstid = Prm.CustomerID;
            string query = "SELECT ProductName, ProductCount FROM ShoppingList WHERE CustomerID = @cstid";
            sbyte i = 0;
            using (SqlConnection con = new SqlConnection(DBConnection.connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                try
                {
                    cmd.Parameters.AddWithValue("@cstid", cstid);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        int rowsAffected = adapter.Fill(dataTable);
                        cmb.ItemsSource = dataTable.DefaultView;
                        return rowsAffected > 0;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
                finally
                {
                    con.Dispose();
                }
                return i > 0;

            }
        }
        
    }
}
