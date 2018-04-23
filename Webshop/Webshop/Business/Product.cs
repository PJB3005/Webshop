using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webshop.Business
{
    public class Product
    {
        private int id;
        private int categoryid;
        private string name;
        private double price;
        private string description;
        private int stock;
        private string picture;


        public int ID
        {
            set { id = value; }
            get { return id; }
        }

        public int Categoryid
        {
            set { categoryid = value; }
            get { return categoryid; }
        }

        public string Name
        {
            set { name = value; }
            get { return name; }
        }

        public double Price
        {
            set { price = value; }
            get { return price; }
        }

        public string Description
        {
            set { description = value; }
            get { return description; }
        }

        public int Stock
        {
            set { stock = value; }
            get { return stock; }
        }

        public string Picture
        {
            set { picture = value; }
            get { return picture; }
        }
    }
}