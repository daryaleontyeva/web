using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace StudentCard.Models
{
    public class DataBaseForStudContext : DbContext
    {
        public DbSet<DataBaseForStud> DataBase { get; set; }
    }
}