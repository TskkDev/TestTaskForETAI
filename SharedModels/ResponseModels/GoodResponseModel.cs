namespace TestTaskForETAI__CategoriesService.Models.RequestModel;

public class GoodRequestModel
{
    public string Name { get; set; } = null!;
    public string Dics { get; set; } = null!;
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
}