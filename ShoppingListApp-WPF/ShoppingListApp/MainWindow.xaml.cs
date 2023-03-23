using Microsoft.Data.SqlClient;
using ShoppingListApp.Classes;
using ShoppingListApp.Classes.Parameters;
using ShoppingListApp.NewFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ShoppingListApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }



        private void button_closemain_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void VSLB_Click(object sender, RoutedEventArgs e)
        {
            VSLPage vslpage = new();
            vslpage.Show();
        }

        private void ESL_open_Click(object sender, RoutedEventArgs e)
        {
            ESLPage eslpage = new();
            eslpage.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CBFill.FillCB(ComboboxItems);
        }

        private void SL_addItem_Click(object sender, RoutedEventArgs e)
        {
            SL_AddItem sl_additem = new();
            sl_additem.Show();
        }

        public void LoginUsername_Click(object sender, RoutedEventArgs e)
        {


            if (fullnamex.Text == "")
            {
                MessageBox.Show("Please enter your username");
            }
            else
            {
                string fullname = fullnamex.Text;

                using (SqlConnection con = new SqlConnection(DBConnection.connectionString))
                {
                    con.Open();


                    using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Username WHERE Username = @fullname", con))
                    {
                        command.Parameters.AddWithValue("@fullname", fullname);
                        int count = (int)command.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("Welcome back, " + fullname + "!");
                        }
                        else
                        {
                            using (SqlCommand insertCommand = new SqlCommand("INSERT INTO Username (Username) VALUES (@fullname)", con))
                            {
                                insertCommand.Parameters.AddWithValue("@fullname", fullname);
                                insertCommand.ExecuteNonQuery();
                            }
                            MessageBox.Show("Welcome, " + fullname + "!");
                            
                        }
                    }
                    using (SqlCommand command = new SqlCommand("SELECT TOP 1 CustomerID FROM Username ORDER BY CustomerID DESC", con))
                    {
                        int customerID = (int)command.ExecuteScalar();
                        Prm.CustomerID = customerID;
                    }
                    LoggedUser.Text = fullname;
                    
                }
                
            }
        }

        private void AddItemButton_Click(object sender, RoutedEventArgs e)
        {
            if (ComboboxItems.Text == "" || itemquantityx.Text == "")
            {
                MessageBox.Show("Please enter an item and quantity");
            }
            else
            {
                    AddItemToList.AddItem(ComboboxItems, itemquantityx,Prm.CustomerID);
                    MessageBox.Show("Item added to list");
            }
        }
    }
}

