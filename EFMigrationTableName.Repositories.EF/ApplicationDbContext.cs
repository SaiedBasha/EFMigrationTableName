using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using EFMigrationTableName.Models;
using EFMigrationTableName.Repositories.EF.Configuration;

namespace EFMigrationTableName.Repositories.EF
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("name=DefaultConnection")
        {
            Configuration.LazyLoadingEnabled = false;
#if DEBUG
            Database.Log = Console.Write;
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;
#endif
            Database.SetInitializer(new NullDatabaseInitializer<ApplicationDbContext>());
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new UserConfiguration());
        }
    }
}