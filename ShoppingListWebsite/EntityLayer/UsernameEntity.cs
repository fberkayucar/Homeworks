using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class UsernameEntity
    {
        private string username;
        private int customerID;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        public int CustomerID
        {
            get { return customerID; }
            set { customerID = value; }
        }
    }
}
