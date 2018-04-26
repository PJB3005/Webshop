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

        //
        // FUNCTIONALITY CATALOGUE
        //

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

        //
        // END OF FUNCTIONALITY CATALOGUE
        //


        //
        // CLIENT fUNCTIONALITY AND INFORMATION
        //

        public Client GetClinet(string username)
        {
            return persistence.GetClient(username);
        }

        public bool CheckCredentials(string username, string password)
        {
            return persistence.CheckCredentials(username, password);
        }

        //
        // END OF CLIENT fUNCTIONALITY AND INFORMATION
        //


        //
        // BASKET FUNCTIONALITY
        //

        public void AddToBasket(int clientid, int productid, int amount)
        {
            persistence.AddToBasket(clientid, productid, amount);
        }

        public List<Basket> GetBasket(int id)
        {
            return persistence.GetBasket(id);
        }

        //
        // END OF BASKET FUNCTIONALITY
        //


        //
        // MAKING THE ORDER
        //

        public void MakeOrder(int clientid)
        {
            persistence.MakeOrder(clientid);
        }

        public double GetTotalPrice(int clientid)
        {
            return persistence.GetTotalPrice(clientid);
        }

        public List<ProductPerOrder> GetOrderInfo(int clientid)
        {
            return persistence.GetOrderInfo(clientid);
        }

        public void SaveOrderedProducts(int userid)
        {
            persistence.SaveOrderedProducts(userid);
        }

        public int BasketVolume(int clientid)
        {
            return persistence.GetBasketVolume(clientid);
        }

        public void DeleteFromBasket(int clientid, int productid)
        {
            persistence.DeleteFromBasket(clientid, productid);
        }

        //
        // END OF MAKING THE ORDER
        //
    }
}