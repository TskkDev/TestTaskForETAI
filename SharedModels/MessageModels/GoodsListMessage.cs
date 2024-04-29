using SharedModels.ResponseModels;

namespace SharedModels.MessageModels;

public class GoodsListMessage
{
    public List<GoodResponseModel> Goods { get; set; }

}