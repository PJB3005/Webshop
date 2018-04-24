using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Webshop.Persistence;

namespace Webshop.Business
{
    public class Controller
    {
        PersistenceCode persistence = new PersistenceCode();

        public List<Product> GetProduct()
        {
            return persistence.GetProduct();
        }

        public Product GetSelectedProduct(int id)
        {
            return persistence.GetSelectedProduct(id);
        }

        public bool CheckStock(int productid)
        {
            return persistence.CheckStock(productid);
        }
    }
}