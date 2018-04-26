using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webshop.Business
{
    public class ProductPerOrder
    {
        private int orderid;
        private int productid;
        private double price;
        private int amount;

        public int Orderid
        {
            set { orderid = value; }
            get { return orderid; }
        }

        public int Productid
        {
            set { productid = value; }
            get { return productid; }
        }

        public double Price
        {
            set { price = value; }
            get { return price; }
        }

        public int Amount
        {
            set { amount = value; }
            get { return amount; }
        }
    }
}