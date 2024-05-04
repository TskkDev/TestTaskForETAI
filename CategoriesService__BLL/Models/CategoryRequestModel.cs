
namespace CategoriesService__BLL.Models;

public class CategoryRequestModel
{
    public string Name { get; set; } = null!;
    public int? ParentCategoryId { get; set; } = null;
}