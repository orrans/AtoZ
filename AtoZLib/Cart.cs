using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using SQLiteNetExtensions;
using SQLiteNetExtensions.Attributes;

namespace AtoZLib
{
    class Cart
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ForeignKey(typeof(Store))]
        public int StoreID { get; set; }
        [OneToOne]
        public Store store { get; set; }

        [ManyToMany(typeof(CartProduct))]
        public List<CartProduct> Products { get; set; }
    }
}
