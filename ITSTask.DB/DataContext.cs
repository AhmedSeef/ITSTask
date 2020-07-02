using ITSTask.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITSTask.DB
{
    public class DataContext : DbContext
    {
       
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }

        public DbSet<Item> items { get; set; }
    }
}
