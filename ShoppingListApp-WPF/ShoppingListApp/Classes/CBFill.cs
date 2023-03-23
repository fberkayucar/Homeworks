using Microsoft.Data.SqlClient;
using ShoppingListApp.NewFolder;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ShoppingListApp
{
    class CBFill
    {
        public static bool FillCB(ComboBox cmb)
        {
            sbyte i = 0;
            using (SqlConnection con = new SqlConnection(DBConnection.connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select ProductName from Products", con);
                try
                {
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    cmb.ItemsSource = null;
                    cmb.ItemsSource = dt.DefaultView;
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
