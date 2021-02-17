using FluentMigrator;
using System;
using System.Data.SqlClient;

namespace Data.FluentMigrations.Migrations
{
    [Tags("Master")]
    [Migration(1)]
    public class SetupMigration: Migration
    {
        public override void Up()
        {
            using var sql = new SqlConnection(ConnectionString);
            using var command = sql.CreateCommand();
            command.CommandText = @"
                IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'Core')
                  BEGIN
                    CREATE DATABASE [Core]
                    END
                IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'OrderLog')
                  BEGIN
                    CREATE DATABASE [OrderLog]
                    END
                IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'OrderLog2')
                  BEGIN
                    CREATE DATABASE [OrderLog2]
                    END
            ";
            sql.Open();

            command.ExecuteNonQuery();
            sql.Close();
        }
        public override void Down()
        {
            throw new NotImplementedException();
        }
    }
}
