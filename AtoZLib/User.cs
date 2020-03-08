using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;


namespace AtoZLib
{
    public class User
    {
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        [ForeignKey(typeof(Store))]
        public int StoreID { get; set; }

        [ManyToOne]
        public Store Store { get; set; }
    }
}
