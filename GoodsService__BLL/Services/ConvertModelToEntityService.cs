using GoodsService__BLL.Models;
using GoodsService__DAL.Enities;
using SharedModels.MessageModels.RespondModels.Request;
using SharedModels.MessageModels.RespondModels.Response;

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


    public GetCategoryNameRequest ResponseModelToGetCategoryNameResponse(GoodResponseModel good)
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
    public ListGetCategoryNameRequest ListResponseModelToListGetCategoryNameRequest(List<GoodResponseModel> goods)
    {
        return new ListGetCategoryNameRequest()
        {
            Goods = goods.Select(g => ResponseModelToGetCategoryNameResponse(g)).ToList()
        };
    }
    public GetCategoryNameRequest RequestModelToGetCategoryNameResponse(GoodRequestModel good)
    {
        return new GetCategoryNameRequest()
        {
            Id = 0,
            Name = good.Name,
            Dics= good.Dics,
            Price= good.Price,
            CategoryId= good.CategoryId
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