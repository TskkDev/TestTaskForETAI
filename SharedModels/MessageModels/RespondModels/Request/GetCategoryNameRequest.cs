
namespace SharedModels.MessageModels.RespondModels.Request
{
    public class GetCategoryNameRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Dics { get; set; } = null!;
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}