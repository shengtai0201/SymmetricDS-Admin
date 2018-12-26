using Microsoft.Extensions.Options;
using Shengtai.Data;
using SymmetricDS.Admin.Master;
using System.Data.SqlClient;

namespace SymmetricDS.Admin.ConsoleApp.Service
{
    public class SqlInitializationService : InitializationService
    {
        public SqlInitializationService(IOptions<AppSettings> options, MasterDbContext dbContext, IClient client,
            Server.IInitializationService serverInitializationService) : base(options, dbContext, client, serverInitializationService)
        {
        }

        public override bool CheckTables()
        {
            string cmdText = @"SELECT COUNT(*)
                FROM
	                information_schema.tables
                WHERE
	                table_schema = 'dbo'
	                AND table_type = 'BASE TABLE'
	                AND TABLE_NAME LIKE'sym_%'";
            var result = this.ExecuteScalar<SqlConnection, SqlCommand, SqlParameter, int>(cmdText);

            return result == 47;
        }
    }
}