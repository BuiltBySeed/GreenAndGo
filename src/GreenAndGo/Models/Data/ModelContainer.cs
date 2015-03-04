using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GreenAndGo.Models.Data
{
    public class ModelContainer: DbContext
    {
        public ModelContainer() : base("ModelContainer") { }

        public DbSet<User> Users {get;set;}
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}