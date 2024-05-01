using CategoriesService__BLL.Managers;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using SharedModels.MessageModels;
using SharedModels.RequestModels;
using SharedModels.ResponseModels;


namespace CategoriesService__WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : Controller
{
    private readonly CategoryManager _categoryManager;    
    private readonly IPublishEndpoint _publishEndpoint;

    public CategoriesController(IConfiguration configuration, IPublishEndpoint publishEndpoint)
    {
        _categoryManager = new CategoryManager( configuration
            .GetConnectionString("DB") ?? throw new NullReferenceException());
        _publishEndpoint = publishEndpoint;
    }

    [HttpPost("/addCategory")]
    public async Task<IActionResult> AddCategory(CategoryRequestModel newCategory)
    {
        if (string.IsNullOrEmpty(newCategory.Name))
            return NoContent();

        var addCategory = _categoryManager.AddCategory(newCategory);
        await _publishEndpoint.Publish(addCategory);
        return Ok(addCategory);
    }

    [HttpPatch("/updateCategory/categoryId={categoryId:int}")]
    public async Task<IActionResult> UpdateCategory(int categoryId, CategoryRequestModel newCategory)
    {
        if (string.IsNullOrEmpty(newCategory.Name))
            return BadRequest();
        CategoryResponseModel updatedCategory;
        try
        {
           updatedCategory = _categoryManager.UpdateCategory(categoryId, newCategory);
        }
        catch(NullReferenceException ex)
        {
            return NotFound(ex.Message);
        }
        await _publishEndpoint.Publish(updatedCategory);
        return Ok(updatedCategory);
    }

    [HttpGet("/getCategoryById/categoryId={categoryId:int}")]
    public async Task<IActionResult> GetCategoryById(int categoryId)
    {
        CategoryResponseModel category;
        try
        {
            category = _categoryManager.GetCategoryById(categoryId);
        }
        catch (NullReferenceException ex)
        {
            return BadRequest(ex.Message);
        }
        await _publishEndpoint.Publish(category);
        return Ok(category);
    }

    [HttpGet("GetAllTopicCategory")]
    public async Task<IActionResult> GetAllTopicCategory()
    {
        List<CategoryResponseModel> categories;
        try
        {
            categories = _categoryManager.GetAllTopicCategory();
        }
        catch (NullReferenceException ex)
        {
            return BadRequest(ex.Message);
        }
        await _publishEndpoint.Publish(new CategoryListMessage() { Categories = categories });
        return Ok(categories);
    }
}