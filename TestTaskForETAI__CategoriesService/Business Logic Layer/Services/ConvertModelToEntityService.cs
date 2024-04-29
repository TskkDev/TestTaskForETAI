using SharedModels.RequestModels;
using SharedModels.ResponseModels;
using TestTaskForETAI__CategoriesService.Data_Access_Layer.Entities;

namespace TestTaskForETAI__CategoriesService.Business_Logic_Layer.Services;

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

    public CategoryResponseModel EntityToResponseModel(Category category)
    {
        return new CategoryResponseModel()
        {
            Id = category.Id,
            Name = category.Name,
            ParentCategoryId = category.ParentCategoryId,
            SubCategories = category.SubCategories.Select(c=>new CategoryResponseModel()
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