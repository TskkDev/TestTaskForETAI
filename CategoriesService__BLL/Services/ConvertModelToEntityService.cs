using CategoriesService__DAL.Entities;
using SharedModels.Models.RequestModels;
using SharedModels.Models.RespondModels.Request;

namespace CategoriesService__BLL.Services;

public class ConvertModelToEntityService
{
    public Category RequestModelToEntity(CategoryRequestModel categoryReq)
    {
        return new Category()
        {
            Name = categoryReq.Name,
            ParentCategoryId = categoryReq.ParentCategoryId,
        };
    }
    public GetCountGoodsRequest EntityToGetCountGoodsRequest(Category category)
    {
        return new GetCountGoodsRequest()
        {
            Id = category.Id,
            Name = category.Name,
            ParentCategoryId = category.ParentCategoryId,
            SubCategories = category.SubCategories.Select(c => new GetCountGoodsRequest()
            {
                Id = c.Id,
                Name = c.Name,
                ParentCategoryId = c.ParentCategoryId,
            }).ToList()
        };
    }
    public ListGetCountGoodsRequest EntitiesToListGetCountGoodsRequest(List<Category> categories)
    {
        return new ListGetCountGoodsRequest()
        {
            Categories = categories.Select(c => EntityToGetCountGoodsRequest(c)).ToList()
        };
    }
}