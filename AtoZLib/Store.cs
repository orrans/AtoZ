using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AtoZLib
{
    public class Store
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
