using CategoriesService__BLL.Models;
using CategoriesService__DAL.Entities;
using SharedModels.MessageModels.RespondModels.Request;

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



    public GetCountGoodsRequest ResponseModelToGetCountGoodsRequest(CategoryResponseModel category)
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
    public ListGetCountGoodsRequest ListResponseModelToListGetCountGoodsRequest(List<CategoryResponseModel> categories)
    {
        return new ListGetCountGoodsRequest()
        {
            Categories = categories.Select(c => ResponseModelToGetCountGoodsRequest(c)).ToList()
        };
    }



    public CategoryResponseModel EntityToResponseModel(Category category)
    {
        return new CategoryResponseModel()
        {
            Id = category.Id,
            Name = category.Name,
            ParentCategoryId = category.ParentCategoryId,
            SubCategories = category.SubCategories.Select(c => new CategoryResponseModel()
            {
                Id = c.Id,
                Name = c.Name,
                ParentCategoryId = c.ParentCategoryId,
            }).ToList()
        };
    }
    public List<CategoryResponseModel> EntitiesToResponseModels(List<Category> category)
    {
        return category.Select(cat => new CategoryResponseModel()
        {
            Id = cat.Id,
            Name = cat.Name,
            ParentCategoryId = cat.ParentCategoryId,
            SubCategories = cat.SubCategories.Select(c => new CategoryResponseModel()
            {
                Id = c.Id,
                Name = c.Name,
                ParentCategoryId = c.ParentCategoryId,
            }).ToList()
        }).ToList();
    }
}