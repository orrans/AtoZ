using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AtoZLib
{
    class CartProduct
    {
        [ForeignKey(typeof(VendorProduct))]
        public int VendorProductID { get; set; }

        [ManyToOne]
        public VendorProduct VendorProduct { get; set; }
        public int Quantity { get; set; }
    }
}
