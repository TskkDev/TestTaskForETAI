namespace SharedModels.ResponseModels;

public class GoodResponseModel
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Dics { get; set; } = null!;
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
}