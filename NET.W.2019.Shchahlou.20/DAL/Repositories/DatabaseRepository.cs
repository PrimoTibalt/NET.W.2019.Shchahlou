using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using BLL.Interface.Entities;

namespace DAL.Repositories
{
    public class DatabaseRepository : DbContext
    {
        public DbSet<Account> accounts { get; set; }

        public DatabaseRepository() : base("NewDB")
        {
            Database.SetInitializer(new DatabaseInitializer());
        }
    }
}
