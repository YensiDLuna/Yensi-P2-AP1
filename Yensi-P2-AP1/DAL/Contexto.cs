using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Yensi_P2_AP1.DAL
{
    public class Contexto : DbContext
    {

        public DbSet<>  { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = Data\Control.db");
        }

    }
}
