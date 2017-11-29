using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Migrations.History;

namespace EFMigrationTableName.Repositories.EF
{
    public class ApplicationHistoryContext : HistoryContext
    {
        public ApplicationHistoryContext(DbConnection dbConnection, string defaultSchema)
            : base(dbConnection, defaultSchema)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<HistoryRow>().ToTable("RenamedMigrationHistory");
        }
    }
}
