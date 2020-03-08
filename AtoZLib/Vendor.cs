using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AtoZLib
{
   public class Vendor
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public double Commission { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.CascadeRead)]
        public List<VendorProduct> Products { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
