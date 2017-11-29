using System.Data.Entity;

namespace EFMigrationTableName.Repositories.EF
{
    public class ApplicationDbConfiguration : DbConfiguration
    {
        public ApplicationDbConfiguration()
        {
            SetHistoryContext("System.Data.SqlClient",
                (connection, defaultSchema) => new ApplicationHistoryContext(connection, defaultSchema));
        }
    }
}
