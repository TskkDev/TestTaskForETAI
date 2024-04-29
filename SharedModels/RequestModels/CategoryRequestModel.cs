namespace TestTaskForETAI__CategoriesService.Models.RequestModel;

public class CategoryRequestModel
{
    public string Name { get; set; } = null!;
    public int? ParentCategoryId { get; set; } = null;
}