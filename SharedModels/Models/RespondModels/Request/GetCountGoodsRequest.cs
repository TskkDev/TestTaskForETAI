
namespace SharedModels.Models.RespondModels.Request;

public class GetCountGoodsRequest
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int? ParentCategoryId { get; set; }
    public List<GetCountGoodsRequest> SubCategories { get; set; } = new List<GetCountGoodsRequest>();
}