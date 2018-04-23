using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webshop.Business
{
    public class Basket
    {
        private int clientid;
        private int productid;
        private int amount;

        public int Clientid
        {
            set { clientid = value; }
            get { return clientid; }
        }

        public int Productid
        {
            set { Productid = value; }
            get { return Productid; }
        }

        public int Amount
        {
            set { amount = value; }
            get { return amount; }
        }
    }
}