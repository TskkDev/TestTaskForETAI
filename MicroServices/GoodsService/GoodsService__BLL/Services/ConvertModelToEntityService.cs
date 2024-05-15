using GoodsService__DAL.Enities;
using SharedModels.Models.RequestModels;
using SharedModels.Models.RespondModels.Request;

namespace GoodsService__BLL.Services;

public class ConvertModelToEntityService
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


    public GetCategoryNameRequest RequestModelToGetCategoryNameRequest(GoodRequestModel good)
    {
        return new GetCategoryNameRequest()
        {
            Id = 0,
            Name = good.Name,
            Dics = good.Dics,
            Price = good.Price,
            CategoryId = good.CategoryId
        };
    }

    public GetCategoryNameRequest EntityToGetCategoryNameResponse(Good good)
    {
        return new GetCategoryNameRequest()
        {
            Id = good.Id,
            Name = good.Name,
            Dics = good.Dics,
            Price = good.Price,
            CategoryId = good.CategoryId
        };
    }

    public ListGetCategoryNameRequest EntitiesToListGetCategoryNameRequest(List<Good> goods)
    {
        return new ListGetCategoryNameRequest()
        {
            Goods = goods.Select(g => EntityToGetCategoryNameResponse(g)).ToList()
        };
    }
}