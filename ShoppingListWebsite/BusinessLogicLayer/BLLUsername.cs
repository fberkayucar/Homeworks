using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using EntityLayer;

namespace BusinessLogicLayer
{
    public class BLLUsername
    {
        public static int AddUsernameBLL(UsernameEntity p)
        {
            if (p.Username != null)
            {
                return DALUsername.SetUsername(p);
            }
            return -1;
        }
        public static List<UsernameEntity> BllList()
        {
            return DALUsername.GetUsernameID();
        }
    }
}
