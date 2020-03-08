using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AtoZLib
{
   public class Product
    {
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double MSRP { get; set; } // Minimum selling price

        [OneToMany]
        public List<VendorProduct> VendorProduct { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
