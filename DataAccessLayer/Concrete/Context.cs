﻿using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context: DbContext
    {
      

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host = localhost; Database= osmapp; Username=postgres; Password=berkin123");
           // optionsBuilder.UseNpgsql(_Configuration.GetConnectionString("WebApiDatabase"));
        }
        public DbSet<Point>Points { get; set; }
    }
}
