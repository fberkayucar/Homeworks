using DataAccessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class BLLProducts
    {
        public static int AddBLLProducts(ProductsEntity p)
        {
            if (p.ProductName != null)
            {
                return DALProducts.GetProduct(p);
            }

            return -1;
        }
        public List<ProductsEntity> BllList()
        {
            return DALProducts.GetProducts();
        }
    }
}
