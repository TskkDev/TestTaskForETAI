using MassTransit;
using Microsoft.AspNetCore.Mvc;
using SharedModels.Enums;
using CategoriesService__BLL.Interfaces;
using SharedModels.MessageModels.NotifyModels;
using CategoriesService__BLL.Models;
using SharedModels.MessageModels.RespondModels.Response;
using CategoriesService__BLL.Services;
using SharedModels.MessageModels.RespondModels.Request;
using CategoriesService__DAL.Entities;

namespace CategoriesService__WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : Controller
{
    private readonly ICategoryManager _categoryManager;
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly IRequestClient<ListGetCountGoodsRequest> _requestClientList;
    private readonly IRequestClient<GetCountGoodsRequest> _requestClient;
    private readonly ConvertModelToEntityService _converter;

    public CategoriesController(ICategoryManager categoryManager,
        IPublishEndpoint publishEndpoint,
        IRequestClient<ListGetCountGoodsRequest> requestClientList,
        IRequestClient<GetCountGoodsRequest> requestClient)
    {
        _categoryManager = categoryManager;
        _publishEndpoint = publishEndpoint;
        _requestClientList = requestClientList;
        _requestClient = requestClient;
        _converter = new ConvertModelToEntityService();
    }

    [HttpPost("/category/add")]
    public async Task<IActionResult> AddCategory(CategoryRequestModel newCategory, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(newCategory.Name))
            return NoContent();

        var addCategory = _categoryManager.AddCategory(newCategory);

        var data = await _requestClient.GetResponse<GetCountGoodsResponse>
            (_converter.ResponseModelToGetCountGoodsRequest(addCategory), cancellationToken);
        await _publishEndpoint.Publish<CategoryMessage>(new CategoryMessage() { Category = data.Message, OperationType = CategoryOperationTypes.Add });
        
        
        return Ok(data.Message);
    }

    [HttpPatch("/category/{categoryId:int}/update")]
    public async Task<IActionResult> UpdateCategory(int categoryId, CategoryRequestModel newCategory
        , CancellationToken cancellationToken)
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


        var data = await _requestClient.GetResponse<GetCountGoodsResponse>(
            _converter.ResponseModelToGetCountGoodsRequest(updatedCategory), cancellationToken);
        await _publishEndpoint.Publish<CategoryMessage>( 
            new CategoryMessage() {Category = data.Message, OperationType = CategoryOperationTypes.Update });
        
        return Ok(data);
    }

    [HttpGet("/category/{categoryId:int}/getById")]
    public async Task<IActionResult> GetCategoryById(int categoryId, CancellationToken cancellationToken)
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

        var data = await _requestClient.GetResponse<GetCountGoodsResponse>(
            _converter.ResponseModelToGetCountGoodsRequest(category), cancellationToken);
        await _publishEndpoint.Publish<CategoryMessage>(new CategoryMessage()
        { Category = data.Message, OperationType = CategoryOperationTypes.Get });
        
        return Ok(data);
    }

    [HttpGet("/category/getAllTopicCategory")]
    public async Task<IActionResult> GetAllTopicCategory(CancellationToken cancellationToken)
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

        var data = await _requestClientList.GetResponse<ListGetCountGoodsResponse>(
            _converter.ListResponseModelToListGetCountGoodsRequest(categories), cancellationToken);
        
        return Ok(data.Message.Categories);
    }
}