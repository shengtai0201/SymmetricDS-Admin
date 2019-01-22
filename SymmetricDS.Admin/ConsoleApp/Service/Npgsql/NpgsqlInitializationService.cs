using Npgsql;

namespace SymmetricDS.Admin.ConsoleApp.Service
{
    public class NpgsqlInitializationService : InitializationService
    {
        public NpgsqlInitializationService(Server.IInitializationService serverInitializationService) : base(serverInitializationService)
        {
        }

        public override bool CheckTables()
        {
            string cmdText = @"SELECT COUNT(*)
                FROM
	                information_schema.tables
                WHERE
	                table_schema = 'public'
	                AND table_type = 'BASE TABLE'
	                AND TABLE_NAME LIKE'sym_%'";
            var result = this.ExecuteScalar<NpgsqlConnection, NpgsqlCommand, NpgsqlParameter, int>(cmdText);

            return result == 47;
        }
    }
}