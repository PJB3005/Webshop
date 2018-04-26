using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webshop.Business
{
    public class Client
    {
        private int id;
        private string name;
        private string prename;
        private int vat;
        private string adress;
        private string mail;

        public int ID
        { 
            set { id = value; }
            get { return id; }
        }

        public string Name
        {
            set { name = value; }
            get { return name; }
        }

        public string Prename
        {
            set { prename = value; }
            get { return prename; }
        }

        public int VAT
        {
            set { vat = value; }
            get { return vat; }
        }

        public string Adress
        {
            set { adress = value; }
            get { return adress; }
        }

        public string Mail  
        {
            set { mail = value; }
            get { return mail; }
        }
    }
}