using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using Webshop.Business;


namespace Webshop.Persistence
{
    public class PersistenceCode
    {
        //connection string
        private string conn = "server=localhost;user id=root;password=Test123;database=dbwebshop";

        //
        // FUNCTIONALITY CATALOGUE
        //

        //Get all products
        public List<Product> GetProduct()
        {
            List<Product> list = new List<Product>();
            MySqlConnection sqlcon = new MySqlConnection(conn);
            sqlcon.Open();
            string querry = "select * from tblproduct";
            MySqlCommand sqlcom = new MySqlCommand(querry, sqlcon);
            MySqlDataReader reader = sqlcom.ExecuteReader();
            while (reader.Read())
            {
                Product product = new Product();
                product.ID = Convert.ToInt32(reader["ID"]);
                product.Categoryid = Convert.ToInt32(reader["categoryid"]);
                product.Name = Convert.ToString(reader["name"]);
                product.Price = Convert.ToDouble(reader["price"]);
                product.Description = Convert.ToString(reader["description"]);
                product.Stock = Convert.ToInt32(reader["stock"]);
                product.Picture = Convert.ToString(reader["picture"]);
                list.Add(product);
            }
            sqlcon.Close();
            return list;
        }

        //Get specified product information
        public Product GetSelectedProduct(int productid)
        {
            MySqlConnection sqlcon = new MySqlConnection(conn);
            sqlcon.Open();
            string querry = "select * from tblproduct where id=" + productid;
            MySqlCommand sqlcom = new MySqlCommand(querry, sqlcon);
            MySqlDataReader reader = sqlcom.ExecuteReader();
            Product product = new Product();
            while (reader.Read())
            {
                product.ID = Convert.ToInt32(reader["ID"]);
                product.Categoryid = Convert.ToInt32(reader["categoryid"]);
                product.Name = Convert.ToString(reader["name"]);
                product.Price = Convert.ToDouble(reader["price"]);
                product.Description = Convert.ToString(reader["description"]);
                product.Stock = Convert.ToInt32(reader["stock"]);
                product.Picture = Convert.ToString(reader["picture"]);
            }
            sqlcon.Close();
            return product;
        }

        //Check stock
        public bool CheckStock(int productid)
        {
            MySqlConnection sqlcon = new MySqlConnection(conn);
            sqlcon.Open();
            string querry = "select stock from tblproduct where id=" + productid;
            MySqlCommand sqlcom = new MySqlCommand(querry, sqlcon);
            MySqlDataReader reader = sqlcom.ExecuteReader();
            reader.Read();
            int stock = Convert.ToInt32(reader["stock"]);
            sqlcon.Close();
            return stock == 0;
        }

        //
        // END OF FUNCTIONALITY CATALOGUE
        //


        //
        // CLIENT fUNCTIONALITY AND INFORMATION
        //

        //Get active client information
        public Client GetClient(string username)
        {
            MySqlConnection sqlcon = new MySqlConnection(conn);
            sqlcon.Open();
            string querry = "select * from tblclient where username='" + username + "'";
            MySqlCommand sqlcom = new MySqlCommand(querry, sqlcon);
            MySqlDataReader reader = sqlcom.ExecuteReader();
            Client client = new Client();
            while (reader.Read())
            {
                client.ID = Convert.ToInt32(reader["ID"]);
                client.Name = Convert.ToString(reader["name"]);
                client.Prename = Convert.ToString(reader["prename"]);
                client.VAT = Convert.ToInt32(reader["VAT"]);
                client.Mail = Convert.ToString(reader["mail"]);
                client.Adress = Convert.ToString(reader["adress"]);
            }
            sqlcon.Close();
            return client;
        }

        //Check login credentials 
        public bool CheckCredentials(string username, string password)
        {
            MySqlConnection sqlcon = new MySqlConnection(conn);
            sqlcon.Open();
            string querry = "select * from tblclient where username='" + username + "' and password='" + password + "'";
            MySqlCommand sqlcom = new MySqlCommand(querry, sqlcon);
            MySqlDataReader reader = sqlcom.ExecuteReader();
            bool control = reader.HasRows;
            sqlcon.Close();
            return control;
        }

        //
        // END OF CLIENT fUNCTIONALITY AND INFORMATION
        //


        //
        // BASKET FUNCTIONALITY
        //

        //Add item to basket
        public void AddToBasket(int clientid, int productid, int amount)
        {
            MySqlConnection sqlcon = new MySqlConnection(conn);
            sqlcon.Open();
            string querry = "insert into tblbasket (clientid,productid,amount) values (" + clientid + "," + productid + "," + amount + ")";
            MySqlCommand sqlcom = new MySqlCommand(querry, sqlcon);
            sqlcom.ExecuteNonQuery();
            sqlcon.Close();
        }

        //Get basket from specified client
        public List<Basket> GetBasket(int id)
        {
            List<Basket> list = new List<Basket>();
            MySqlConnection sqlcon = new MySqlConnection(conn);
            sqlcon.Open();
            string querry = "select * from tblbasket where id= " + id;
            MySqlCommand sqlcom = new MySqlCommand(querry, sqlcon);
            MySqlDataReader reader = sqlcom.ExecuteReader();
            while (reader.Read())
            {
                Basket basket = new Basket();
                basket.Productid = Convert.ToInt32(reader["productid"]);
                basket.Clientid = Convert.ToInt32(reader["clientid"]);
                basket.Amount = Convert.ToInt32(reader["amount"]);
                list.Add(basket);
            }
            sqlcon.Close();
            return list;
        }

        //
        // END OF BASKET FUNCTIONALITY
        //


        //
        // MAKING THE ORDER
        //

        //Make new order
        public void MakeOrder(int clientid)
        {
            MySqlConnection sqlcon = new MySqlConnection(conn);
            sqlcon.Open();
            string date = DateTime.Today.Year + "-" + DateTime.Today.Month + "-" + DateTime.Today.Day;
            string querry = "insert into tblorder (orderdate,clientid) values('" + date + "'," + clientid + ")";
            MySqlCommand sqlcom = new MySqlCommand(querry, sqlcon);
            sqlcom.ExecuteNonQuery();
            sqlcon.Close();
        }

        //Total price of order
        public double GetTotalPrice(int clientid)
        {
            MySqlConnection sqlcon = new MySqlConnection(conn);
            sqlcon.Open();
            string querry = "select sum(price) as total from tblbasket where clientid=" + clientid + " order by productid";
            MySqlCommand sqlcom = new MySqlCommand(querry, sqlcon);
            MySqlDataReader reader = sqlcom.ExecuteReader();
            reader.Read();
            double total = Convert.ToDouble(reader["total"]);
            sqlcon.Close();
            return total;
        }

        //Get all the needed information to fill out ProductPerOrder
        public ProductPerOrder GetOrderInfo(int clientid)
        {
            ProductPerOrder productperorder = new ProductPerOrder();
            MySqlConnection sqlcon = new MySqlConnection(conn);
            sqlcon.Open();
            string querry = "select orderid, productid, amount, price from tblbasket inner join tblproduct on productid = tblproduct.id inner join tblorder on orderid = tblorder.id where value in (select id from tblorder where clientid = " + clientid + "order by id desc limit 1) limit 1";
            MySqlCommand sqlcom = new MySqlCommand(querry, sqlcon);
            MySqlDataReader reader = sqlcom.ExecuteReader();
            while(reader.Read())
            {
                productperorder.Orderid = Convert.ToInt32(reader["orderid"]);
                productperorder.Productid = Convert.ToInt32(reader["productid"]);
                productperorder.Price = Convert.ToDouble(reader["price"]);
                productperorder.Amount = Convert.ToInt32(reader["amount"]);
            }
            sqlcon.Close();
            return productperorder;
        }

        //public int GetLatestOrderid(int clientid)
        //{
        //    MySqlConnection sqlcon = new MySqlConnection(conn);
        //    sqlcon.Open();
        //    string querry = "select id from tblorder where clientid = " + clientid + "order by id desc limit 1";
        //    MySqlCommand sqlcom = new MySqlCommand(querry, sqlcon);
        //    MySqlDataReader reader = sqlcom.ExecuteReader();
        //    reader.Read();
        //    int id = Convert.ToInt32(reader["id"]);
        //    sqlcon.Close();
        //    return id;
        //}

        //Products per order !!!
        public void SaveOrderedProducts(int clientid)
        {
            MySqlConnection sqlcon = new MySqlConnection(conn);
            sqlcon.Open();
            string price = GetOrderInfo(clientid).Price.ToString().Replace(",", ".");
            string querry = "insert into tblproductperorder (orderid, productid, price, amount) values ( ";
            MySqlCommand sqlcom = new MySqlCommand(querry, sqlcon);
            sqlcom.ExecuteNonQuery();
            sqlcon.Close();
        }

        //Get amount of different items in basket
        public int GetBasketVolume(int clientid)
        {
            MySqlConnection sqlcon = new MySqlConnection(conn);
            sqlcon.Open();
            string querry = "select count(productid) as volume from tblbasket where clientid=" + clientid + " order by clientid";
            MySqlCommand sqlcom = new MySqlCommand(querry, sqlcon);
            MySqlDataReader reader = sqlcom.ExecuteReader();
            int volume = Convert.ToInt32(reader["volume"]);
            sqlcon.Close();
            return volume;
        }

        //Delete item from basket
        public void DeleteFromBasket(int clientid, int productid)
        {
            MySqlConnection sqlcon = new MySqlConnection(conn);
            sqlcon.Open();
            string querry = "delete from tblbasket where clientid= " + clientid + " and productid=" + productid;
            MySqlCommand sqlcom = new MySqlCommand(querry, sqlcon);
            sqlcom.ExecuteNonQuery();
            sqlcon.Close();
        }

        //
        // END OF MAKING THE ORDER
        //
    }
}