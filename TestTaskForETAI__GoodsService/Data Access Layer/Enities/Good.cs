using LinqToDB.Mapping;

namespace TestTaskForETAI__GoodsService.Data_Access_Layer.Enities;


[Table(Name = "Goods")]
public class Good
{
    [PrimaryKey, Identity] public int Id { get; set; }
    [Column] public string Name { get; set; } = null!;
    [Column] public string Dics { get; set; } = null!;
    [Column] public decimal Price { get; set; }
    [Column] public int CategoryId { get; set; }
}