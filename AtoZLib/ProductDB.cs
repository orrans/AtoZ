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
            var query = DataBase.Connection.Table<Product>();
            return query.ToList();
        }
    }
}
