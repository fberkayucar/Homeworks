using ShoppingListApp.Classes;
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
    /// Interaction logic for ESLPage.xaml
    /// </summary>
    public partial class ESLPage : Window
    {
        public ESLPage()
        {
            InitializeComponent();
        }

        private void VSL_closebt(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DiscardCB.FillDC(EditItemCB);
        }

        private void ItemDelBT_Click(object sender, RoutedEventArgs e)
        {
            if (EditItemCB.Items == null && QuantitytbID.Text == null)
            {
                MessageBox.Show("Please select an item or type quantity to delete");
            }
            else
            {
                DiscardCB.Discard(EditItemCB, QuantitytbID);
                MessageBox.Show("Item deleted");
            }
        }
    }
}
