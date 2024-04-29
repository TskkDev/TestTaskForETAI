namespace SharedModels.ResponseModels;

public class CategoryResponseModel
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int? ParentCategoryId { get; set; }
    public List<CategoryResponseModel> SubCategories { get; set; } = new List<CategoryResponseModel>();
}