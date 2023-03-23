using ShoppingListApp.Classes;
using ShoppingListApp.Classes.Parameters;
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
using System.Windows.Shapes;

namespace ShoppingListApp
{
    /// <summary>
    /// Interaction logic for VSLPage.xaml
    /// </summary>
    public partial class VSLPage : Window
    {
        public VSLPage()
        {
            InitializeComponent();
        }

        private void VSL_closebt(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            VSLgrdFill.FillVSLgrd(VSLDatagrid,Prm.CustomerID);
        }
    }
}
