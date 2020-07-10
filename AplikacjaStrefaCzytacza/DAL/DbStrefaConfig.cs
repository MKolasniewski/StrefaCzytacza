using AplikacjaStrefaCzytacza.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace AplikacjaStrefaCzytacza.DAL
{
    public class DbStrefaConfig : DbContext
    {
        public DbStrefaConfig() : base("dbConnections")
        {

        }
        static DbStrefaConfig()
        {
            Database.SetInitializer<DbStrefaConfig>(new DbStrefaConfigInitializer());
        }


        public DbSet<Ksiazka> Ksiazkas { get; set; }
        public DbSet<Kategoria> Kategorias { get; set; }
        public DbSet<Cytat> Cytats { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}