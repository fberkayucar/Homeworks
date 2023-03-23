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
    /// Interaction logic for SL_AddItem.xaml
    /// </summary>
    public partial class SL_AddItem : Window
    {
        public SL_AddItem()
        {
            InitializeComponent();
        }

        private void SLAdd_closeBT(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Add_ItemBT_Click(object sender, RoutedEventArgs e)
        {
            ItemAdding.ItemAdd(TB_sladditem);
            MessageBox.Show("Item added! After you restart the program items will be saved");
        }
    }
}
