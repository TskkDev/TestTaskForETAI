
namespace SharedModels.Models.RespondModels.Response;

public class GetCountGoodsResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int? ParentCategoryId { get; set; }
    public int CountGoods { get; set; } = 0;
    public List<GetCountGoodsResponse> SubCategories { get; set; } = new List<GetCountGoodsResponse>();
}