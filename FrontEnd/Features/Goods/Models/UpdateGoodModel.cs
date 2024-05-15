using SharedModels.Models.RequestModels;

namespace FrontEnd.Features.Goods.Models
{
    public class UpdateGoodModel
    {
        public int GoodId { get; set; }
        public GoodRequestModel NewGood { get; set; }
    }
}
