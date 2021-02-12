using FluentMigrator;
using System.Data.SqlClient;

namespace Data.FluentMigrations.Migrations
{
    [Tags("OrderLog")]
    [Migration(201804301219000)]
    public class OrderLog_DynamicNameChangeMigration : AutoReversingMigration
    {
        public override void Up()
        {
            using var sql =  new SqlConnection(ConnectionString);
            using var command = sql.CreateCommand();
            command.CommandText = "SELECT * FROM INFORMATION_SCHEMA.TABLES;";
            sql.Open();
            
            using var reader = command.ExecuteReader();
            while (reader.Read()) {
                var table = reader[2].ToString();
                if (table.Contains("OrderLog"))
                    Rename.Column("FulfillmentDate").OnTable(table).To("FulFilled");
            }
            sql.Close();
        }
    }

}