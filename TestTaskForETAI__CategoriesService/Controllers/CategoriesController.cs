using MassTransit;
using Microsoft.AspNetCore.Mvc;
using SharedModels.MessageModels;
using SharedModels.RequestModels;
using SharedModels.ResponseModels;
using SharedModels.Enums;
using CategoriesService__BLL.Interfaces;

namespace CategoriesService__WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : Controller
{
    private readonly ICategoryManager _categoryManager;
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly IRequestClient<CategoryListMessage> _requestClientList;
    private readonly IRequestClient<CategoryResponseModel> _requestClient;

    public CategoriesController(ICategoryManager categoryManager,
        IPublishEndpoint publishEndpoint,
        IRequestClient<CategoryListMessage> requestClientList,
        IRequestClient<CategoryResponseModel> requestClient
        )
    {
        _categoryManager = categoryManager;
        _publishEndpoint = publishEndpoint;
        _requestClientList = requestClientList;
        _requestClient = requestClient;
    }

    [HttpPost("/category/add")]
    public async Task<IActionResult> AddCategory(CategoryRequestModel newCategory)
    {
        if (string.IsNullOrEmpty(newCategory.Name))
            return NoContent();

        var addCategory = _categoryManager.AddCategory(newCategory);

        await _publishEndpoint.Publish<CategoryMessage>(new CategoryMessage() { Category = addCategory, OperationType = CategoryOperationTypes.Add });
        return Ok(addCategory);
    }

    [HttpPatch("/category/{categoryId:int}/update")]
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
        var data = await _requestClient.GetResponse<CategoryResponseModel>(updatedCategory);

        await _publishEndpoint.Publish<CategoryMessage>( new CategoryMessage() {Category = data.Message, OperationType = CategoryOperationTypes.Update });
        
        return Ok(data);
    }

    [HttpGet("/category/{categoryId:int}/getById")]
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

        var data = await _requestClient.GetResponse<CategoryResponseModel>(category);
        await _publishEndpoint.Publish<CategoryMessage>(new CategoryMessage() { Category = data.Message, OperationType = CategoryOperationTypes.Get });
        
        return Ok(data);
    }

    [HttpGet("/category/getAllTopicCategory")]
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
        var data = await _requestClientList.GetResponse<CategoryListMessage>(new CategoryListMessage() { Categories = categories});
        return Ok(data.Message.Categories);
    }
}