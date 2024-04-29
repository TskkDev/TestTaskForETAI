using LinqToDB.Mapping;

namespace TestTaskForETAI__CategoriesService.Data_Access_Layer.Entities;

[Table(Name = "Categories")]
public class Category
{
    [PrimaryKey, Identity] public int Id { get; set; }
    [Column] public string Name { get; set; } = null!;
    [Column] public int? ParentCategoryId { get; set; }
    [Association(ThisKey = "Id", OtherKey = "ParentCategoryId")]
    public List<Category> SubCategories { get; set; } = new List<Category>();

}