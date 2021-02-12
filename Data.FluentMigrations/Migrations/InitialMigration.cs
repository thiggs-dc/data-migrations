using FluentMigrator;
using FluentMigrator.SqlServer;

namespace Data.FluentMigrations.Migrations
{
    [Tags("Core")]
    [Migration(20180430121800)]
    public class InitialMigration : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("Client")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity(0, 1)
                .WithColumn("Name").AsString()
                .WithColumn("ClientOrderConnectionName").AsString()
                .WithColumn("Motto").AsString();

            Create.Table("Customer")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity(0, 1)
                .WithColumn("ClientId").AsInt32().NotNullable()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("Weakness").AsString();

            Create.Table("CustomerClient")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity(0, 1)
                .WithColumn("ClientId").AsInt32().NotNullable()
                .WithColumn("CustomerId").AsInt32().NotNullable();

            Create.ForeignKey()
                .FromTable("CustomerClient").ForeignColumn("CustomerId")
                .ToTable("Customer").PrimaryColumn("Id");

            Create.ForeignKey()
                .FromTable("CustomerClient").ForeignColumn("ClientId")
                .ToTable("Client").PrimaryColumn("Id");

            Create.Table("Order")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity(0, 1)
                .WithColumn("CustomerId").AsInt32().NotNullable()
                .WithColumn("Total").AsDouble().NotNullable()
                .WithColumn("Fulfilled").AsBoolean().NotNullable();

            Create.ForeignKey()
                .FromTable("Order").ForeignColumn("CustomerId")
                .ToTable("Customer").PrimaryColumn("Id");

            Create.Table("Product")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity(0, 1)
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("Description").AsString().NotNullable()
                .WithColumn("Price").AsDouble().NotNullable();

            Create.Table("OrderProduct")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity(0, 1)
                .WithColumn("OrderId").AsInt32().NotNullable()
                .WithColumn("ProductId").AsInt32().NotNullable();

            Create.ForeignKey()
                .FromTable("OrderProduct").ForeignColumn("OrderId")
                .ToTable("Order").PrimaryColumn("Id");

            Create.ForeignKey()
                .FromTable("OrderProduct").ForeignColumn("ProductId")
                .ToTable("Product").PrimaryColumn("Id");
        }
    }

}
