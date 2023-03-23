using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class SLEntity
    {
        private int customerID;
        private string productName;
        private int productCount;
        public int CustomerID
        {
            get { return customerID; }
            set { customerID = value; }
        }
        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }
        public int ProductCount
        {
            get { return productCount; }
            set { productCount = value; }

        }
    }
}
