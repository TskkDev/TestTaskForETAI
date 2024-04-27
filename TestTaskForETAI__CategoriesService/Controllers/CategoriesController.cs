using LinqToDB;
using Microsoft.AspNetCore.Mvc;
using TestTaskForETAI__CategoriesService.Entity;
using TestTaskForETAI__CategoriesService.Models.RequestModel;
using TestTaskForETAI__CategoriesService.Repositories;
using TestTaskForETAI__CategoriesService.Service;

namespace TestTaskForETAI__CategoriesService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : Controller
{
    private readonly IConfiguration _configuration;
    private readonly ConvertModelToEntityService _converter;

    public CategoriesController(IConfiguration configuration)
    {
        _configuration = configuration;
        _converter = new ConvertModelToEntityService();
    }
    
    [HttpPost("/addCategory")]
    public async Task<IActionResult> AddCategory(CategoryRequestModel newCategory)
    {
        if (String.IsNullOrEmpty(newCategory.Name))
            return NoContent();
        using (var db = new DbConection(_configuration))
        {
            var repos = new CategoryRepository(db);
            repos.Add(_converter.RequestModelToEntity(newCategory));
        }
        return Ok();
    }

    [HttpPatch("/updateCategory/categoryId={categoryId:int}")]
    public async Task<IActionResult> UpdateCategory(int categoryId,CategoryRequestModel newCategory)
    {
        if (String.IsNullOrEmpty(newCategory.Name))
            return BadRequest();
        Category updatedCategory;
        using (var db = new DbConection(_configuration))
        {
            var repos = new CategoryRepository(db);
            var oldCategory = repos.GetById(categoryId);
            if (oldCategory is null) return NotFound(); 
            updatedCategory = repos.Update(oldCategory, _converter.RequestModelToEntity(newCategory));
        }
        return Ok(_converter.EntityToResponseModel(updatedCategory));
    }

    [HttpGet("/getCategoryById/categoryId={categoryId:int}")]
    public async Task<IActionResult> GetCategoryById(int categoryId)
    {
        Category? category;
        using (var db = new DbConection(_configuration))
        {
            var repos = new CategoryRepository(db);
            category = repos.GetById(categoryId);
            if (category is null) return NotFound();
        }
        return Ok(_converter.EntityToResponseModel(category));
    }

    [HttpGet("GetAllTopicCategory")]
    public async Task<IActionResult> GetAllTopicCategory()
    {
        using (var db = new DbConection(_configuration))
        {
            var repos = new CategoryRepository(db);
            var categories = repos.GetAllTopicCategories().ToList();
            if (categories.Count() == 0) return BadRequest();
            return Ok(_converter.EntitiesToResponseModels(categories));
        }
    }
}