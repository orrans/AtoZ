using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AtoZLib
{
    public class VendorProduct
    {
        [ForeignKey(typeof(Product))]
        public int ProductID { get; set; }

        [OneToOne]
        public Product Product { get; set; }

        [ForeignKey(typeof(Vendor))]
        public int VendorID { get; set; }

        [OneToOne]
        public Vendor Vendor { get; set; }

        public decimal Price { get; set; }
    }
}
