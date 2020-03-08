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

        [ManyToOne(CascadeOperations = CascadeOperation.CascadeRead)]
        public Product Product { get; set; }

        [ForeignKey(typeof(Vendor))]
        public int VendorID { get; set; }

        [ManyToOne(CascadeOperations = CascadeOperation.CascadeRead)]
        public Vendor Vendor { get; set; }

        public decimal Price { get; set; }

        public VendorProductDetails Details()
        {
            return new VendorProductDetails() {
                ProductID = ProductID,
                Vendor = Vendor.Name,
                Product = Product.Name,
                Price = $@"${Price}",
                Commission = $@"{Vendor.Commission}%",
            };
        }
    }
    
    public class VendorProductDetails
    {
        public int ProductID { get; internal set; }
        public string Product { get; internal set; }
        public string Vendor { get; internal set; }
        public string Price { get; internal set; }
        public string Commission { get; internal set; }
        public int Quantity { get; set; }
    }
}
