using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Yensi_P2_AP1.Entidades;

namespace Yensi_P2_AP1.DAL
{
    public class Contexto : DbContext
    {

        public DbSet<Proyecto> Proyectos { get; set; }
        public DbSet<Tipo> Tipos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = Data\ProyectoControl.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Tipo>().HasData(new Tipo() { TipoID = 2, tipo = "APrender Css" });
            modelBuilder.Entity<Tipo>().HasData(new Tipo() { TipoID = 3, tipo = "APrender JS" });
            modelBuilder.Entity<Tipo>().HasData(new Tipo() { TipoID = 4, tipo = "APrender C#" });
        }


    }
}
