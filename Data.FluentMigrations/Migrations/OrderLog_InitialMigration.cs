using FluentMigrator;
using FluentMigrator.SqlServer;

namespace Data.FluentMigrations.Migrations
{
    [Tags("OrderLog")]
    [Migration(201804301218123)]
    public class OrderLog_InitialMigration : AutoReversingMigration
    {
        public override void Up()
        {
            for (int i = 0; i < 10; i++)
            {
                Create.Table($"OrderLog{i}")
                    .WithColumn("Id").AsInt32().PrimaryKey().Identity(0, 1)
                    .WithColumn("ClientId").AsString()
                    .WithColumn("OrderId").AsString()
                    .WithColumn("FulfillmentDate").AsString();

            }
        }
    }

}
