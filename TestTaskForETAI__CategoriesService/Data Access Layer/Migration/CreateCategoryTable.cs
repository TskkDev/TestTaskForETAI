namespace TestTaskForETAI__CategoriesService.Migration;
using FluentMigrator;

[Migration(20240427000001)]
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