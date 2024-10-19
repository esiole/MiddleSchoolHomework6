using FluentMigrator;

namespace MiddleSchool.Homework6.Migrator.Migrations._202410;

[Migration(202410192014)]
public class AddTodoTable : Migration
{
    private const string Table = "todos";

    public override void Up()
    {
        Create.Table(Table)
            .WithColumn("Id").AsGuid().PrimaryKey()
            .WithColumn("Title").AsCustom("varchar(255)").NotNullable()
            .WithColumn("Description").AsCustom("varchar(255)").NotNullable()
            .WithColumn("CreatedAtUtc").AsDateTime().NotNullable()
            .WithColumn("UpdatedAtUtc").AsDateTime().NotNullable();
    }

    public override void Down()
    {
        Delete.Table(Table);
    }
}