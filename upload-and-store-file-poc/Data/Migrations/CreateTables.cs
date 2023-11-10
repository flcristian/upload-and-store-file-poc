using FluentMigrator;

namespace upload_and_store_file_poc.Data.Migrations;

[Migration(110112023)]
public class CreateTables : Migration
{
    public override void Up()
    {
        Create.Table("Templates")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Name").AsString(128).NotNullable();
    }

    public override void Down()
    {
        Delete.Table("Templates");
    }
}