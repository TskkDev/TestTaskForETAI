using FluentMigrator;

namespace GoodsService__DAL.Migrations;

public class CreateCategoryTable : Migration
{
    public override void Up()
    {
        Create.Table("Categories")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Name").AsString().NotNullable()
            .WithColumn("ParentCategoryId").AsInt32().Nullable();

        Create.ForeignKey("FK_Categories_Categories_ParentCategoryId")
            .FromTable("Categories").ForeignColumn("ParentCategoryId")
            .ToTable("Categories").PrimaryColumn("Id");
    }
    public override void Down()
    {
        Delete.Table("Categories");
    }
}
[Migration(20240428000001)]
public class CreateGoodTable : Migration
{
    public override void Up()
    {
        Create.Table("Goods")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Name").AsString().NotNullable()
            .WithColumn("Dics").AsString().NotNullable()
            .WithColumn("Price").AsDecimal().NotNullable()
            .WithColumn("CategoryId").AsInt32().NotNullable();
    }

    public override void Down()
    {
        Delete.Table("Goods");
    }
}