using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using SQLiteNetExtensions;
using SQLite;


namespace AtoZLib
{
    public static class DataBase
    {

        public static string databasePath = Path.Combine(Directory.GetCurrentDirectory(), "DataBase.db");
        public static SQLiteConnection Connection { get; set; }
        static bool FE = File.Exists(databasePath); //delete after finish building

        static DataBase()
        {
            Connection = new SQLiteConnection(databasePath);
        }

        public static void CreateDB()
        {

            Connection.CreateTable<Store>();
            Connection.CreateTable<Cart>();
            Connection.CreateTable<Product>();
            Connection.CreateTable<User>();
            Connection.CreateTable<CartProduct>();
            Connection.CreateTable<Vendor>();
            Connection.CreateTable<VendorProduct>();

            if (!FE)  //delete after finish building
            {
                DummyData();
            }

        }
        public static void DummyData() //delete after finish building
        {
            #region DummyData
            var store = new Store();
            store.Name = "bok";
            Connection.Insert(store);

            var cart = new Cart();
            cart.StoreID = store.ID;
            Connection.Insert(cart);

            var product = new Product()
            {
                Description = "dasf",
                MSRP = 10,
                Name = "pen"
            };
            Connection.Insert(product);

            var user = new User()
            {
                UserName = "bok",
                FirstName = "komakti",
                LastName = "bealil",
                Password = "1234",
                Email = "fdasji@fgda.com",
                StoreID = store.ID
            };
            Connection.Insert(user);

            var vendor = new Vendor()
            {
                Name = "wowo",
                Commission = 0.7
            };
            Connection.Insert(vendor);

            var vendorProduct = new VendorProduct()
            {
                ProductID = product.ID,
                Price = 10m,
                VendorID = vendor.ID
            };
            Connection.Insert(vendorProduct);

            #endregion
        }
    }
}
