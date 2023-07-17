using FluentMigrator;

namespace MyCookbook.Infrastructure.Migrations.version;

[Migration((long)EMigrationVersions.CreateUserTable, "Create User Table")]
public class CreateUserTableMigration : Migration
{
    public override void Down()
    {
    }

    public override void Up()
    {
        BaseMigration.InsertColumnsDefalut(Create.Table("User"))
        .WithColumn("Name").AsString(100).NotNullable()
        .WithColumn("Email").AsString(100).NotNullable()
        .WithColumn("Phone").AsString(14).NotNullable()
        .WithColumn("Password").AsString(2000).NotNullable();       
    }
}
