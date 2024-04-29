using MassTransit;
using Microsoft.AspNetCore.Mvc;
using SharedModels.MessageModels;
using SharedModels.RequestModels;
using SharedModels.ResponseModels;
using TestTaskForETAI__CategoriesService.Business_Logic_Layer.Services;
using TestTaskForETAI__CategoriesService.Data_Access_Layer.Entities;
using TestTaskForETAI__CategoriesService.Data_Access_Layer.Repositories;

namespace TestTaskForETAI__CategoriesService.Presentation_Layer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : Controller
{
    private readonly IConfiguration _configuration;
    private readonly ConvertModelToEntityService _converter;
    private readonly IPublishEndpoint _publishEndpoint;
    
    public CategoriesController(IConfiguration configuration, IPublishEndpoint publishEndpoint)
    {
        _configuration = configuration;
        _publishEndpoint = publishEndpoint;
        _converter = new ConvertModelToEntityService();
    }
    
    [HttpPost("/addCategory")]
    public async Task<IActionResult> AddCategory(CategoryRequestModel newCategory)
    {
        CategoryResponseModel addCategory;
        if (String.IsNullOrEmpty(newCategory.Name))
            return NoContent();
        using (var db = new DbConection(_configuration))
        {
            var repos = new CategoriesRepository(db);
            addCategory = _converter.EntityToResponseModel(
                repos.Add(_converter.RequestModelToEntity(newCategory)));
        }
        await _publishEndpoint.Publish<CategoryResponseModel>(addCategory);
        return Ok(addCategory);
    }

    [HttpPatch("/updateCategory/categoryId={categoryId:int}")]
    public async Task<IActionResult> UpdateCategory(int categoryId,CategoryRequestModel newCategory)
    {
        if (String.IsNullOrEmpty(newCategory.Name))
            return BadRequest();
        CategoryResponseModel updatedCategory;
        using (var db = new DbConection(_configuration))
        {
            var repos = new CategoriesRepository(db);
            var oldCategory = repos.GetById(categoryId);
            if (oldCategory is null) return NotFound(); 
            updatedCategory = _converter.EntityToResponseModel(
                repos.Update(oldCategory, _converter.RequestModelToEntity(newCategory)));
        }
        await _publishEndpoint.Publish<CategoryResponseModel>(updatedCategory);
        return Ok(updatedCategory);
    }

    [HttpGet("/getCategoryById/categoryId={categoryId:int}")]
    public async Task<IActionResult> GetCategoryById(int categoryId)
    {
        CategoryResponseModel? category;
        using (var db = new DbConection(_configuration))
        {
            var repos = new CategoriesRepository(db);
            category = _converter.EntityToResponseModel(
                repos.GetById(categoryId));
            if (category is null) return NotFound();
        }
        await _publishEndpoint.Publish<CategoryResponseModel>(category);
        return Ok(category);
    }

    [HttpGet("GetAllTopicCategory")]
    public async Task<IActionResult> GetAllTopicCategory()
    {
        List<CategoryResponseModel> categories;
        using (var db = new DbConection(_configuration))
        {
            var repos = new CategoriesRepository(db);
            categories = _converter.EntitiesToResponseModels(
                repos.GetAllTopicCategories().ToList());
            if (categories.Count() == 0) return BadRequest();
            await _publishEndpoint.Publish<CategoryListMessage>(new CategoryListMessage() {Categories = categories});
            return Ok(categories);
        }
    }
}