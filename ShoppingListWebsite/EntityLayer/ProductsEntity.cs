using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class ProductsEntity
    {
        private string productName;
        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }
    }
}
