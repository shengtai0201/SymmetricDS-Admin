using System.Data.SqlClient;

namespace SymmetricDS.Admin.ConsoleApp.Service
{
    public class SqlInitializationService : InitializationService
    {
        public SqlInitializationService(Server.IInitializationService serverInitializationService) : base(serverInitializationService)
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
            var result = this.ExecuteScalar<SqlConnection, SqlCommand, SqlParameter, int>(cmdText, this.AppSettings.ConnectionStrings.DefaultConnection);

            return result == 47;
        }
    }
}