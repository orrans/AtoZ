using SQLite;
using SQLiteNetExtensions;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace AtoZLib
{
    public class ProductDB
    {
        public static List<Product> GetAllVendorProducts()
        {
            var query = DataBase.Connection.GetAllWithChildren<Product>(recursive: true);
            return query;
        }
    }
}
