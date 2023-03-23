using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using EntityLayer;

namespace BusinessLogicLayer
{
    public class BLLSLEntity
    {
        public static int AddSLEntityBLL(SLEntity p)
        {
            if (p.ProductName != null && p.CustomerID != 0 && p.ProductCount != 0)
            {
                return DALSLEntity.GetShoppingList(p);
            }
            
            return -1;
        }
        public static List<SLEntity> BllListSL()
        {
            return DALSLEntity.GetShoppingList();
        }
    }
}
