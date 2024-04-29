using SharedModels.RequestModels;
using SharedModels.ResponseModels;
using TestTaskForETAI__GoodsService.Data_Access_Layer.Enities;

namespace TestTaskForETAI__GoodsService.Business_Logic_Layer.Services;

public class ConvertModelToEntityService_
{
    public Good RequestModelToEntity(GoodRequestModel goodReq)
    {
        return new Good()
        {
            Name = goodReq.Name,
            Dics = goodReq.Dics,
            Price = goodReq.Price,
            CategoryId = goodReq.CategoryId
        };
    }

    public GoodResponseModel EntityToResponseModel(Good good)
    {
        return new GoodResponseModel()
        {
            Id = good.Id,
            Name = good.Name,
            Dics = good.Dics,
            Price = good.Price,
            CategoryId = good.CategoryId
        };
    }

    public List<GoodResponseModel> EntitiesToResponseModels(List<Good> goods)
    {
        return goods.Select(g => new GoodResponseModel()
        {
            Id = g.Id,
            Name = g.Name,
            Dics = g.Dics,
            Price = g.Price,
            CategoryId = g.CategoryId
        }).ToList();
    }
}