using FluentMigrator.Builders.Create.Table;

namespace MyCookbook.Infrastructure.Migrations;

public static class BaseMigration
{
    public static ICreateTableColumnOptionOrWithColumnSyntax InsertColumnsDefalut(ICreateTableWithColumnOrSchemaOrDescriptionSyntax table)
    {
       return table.WithColumn("Id").AsInt64().PrimaryKey().Identity()
            .WithColumn("DateTimeCreate").AsDateTime().NotNullable();
    }
}
