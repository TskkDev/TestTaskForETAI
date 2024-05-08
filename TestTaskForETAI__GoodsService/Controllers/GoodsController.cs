using MassTransit;
using Microsoft.AspNetCore.Mvc;
using SharedModels.Enums;
using GoodsService__BLL.Interface;
using GoodsService__BLL.Models;
using GoodsService__BLL.Services;
using SharedModels.Models.MessageModels.NotifyModels;
using SharedModels.Models.RespondModels.Request;
using SharedModels.Models.RespondModels.Response;

namespace GoodsService__WebApi.Controllers;


[Route("api/[controller]")]
[ApiController]
public class GoodsController : Controller
{
    private readonly IGoodManager _goodManager;
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly IRequestClient<ListGetCategoryNameRequest> _requestClientList;
    private readonly IRequestClient<GetCategoryNameRequest> _requestClient;
    private readonly ConvertModelToEntityService _converter;

    public GoodsController(IGoodManager goodManager, 
        IPublishEndpoint publishEndpoint,
        IRequestClient<ListGetCategoryNameRequest> requestClientList,
        IRequestClient<GetCategoryNameRequest> requestClient)
    {
        _goodManager = goodManager;
        _publishEndpoint = publishEndpoint;
        _requestClientList = requestClientList;
        _requestClient = requestClient;
        _converter = new ConvertModelToEntityService();

    }

    [HttpPost("/good/add")]
    public async Task<IActionResult> AddGood(GoodRequestModel newGood, CancellationToken cancellationToken)
    {
        GetCategoryNameRequest addGood;
        Response<GetCategoryNameResponse> data;

        if (string.IsNullOrEmpty(newGood.Name) || string.IsNullOrEmpty(newGood.Dics)
                || newGood.Price <= 0)
            return BadRequest();
        if (newGood.CategoryId <= 0) return NotFound();

        try
        {
            data = await _requestClient.GetResponse<GetCategoryNameResponse>(
                _converter.RequestModelToGetCategoryNameRequest(newGood), cancellationToken);
        }
        catch (MassTransitException ex)
        {
            return BadRequest("Invalid categoryId");
        }

        addGood = _goodManager.AddGood(newGood);


        data.Message.Id = addGood.Id;

        await _publishEndpoint.Publish<GoodMessage>(new GoodMessage() { Good = data.Message,
            OperationType = GoodOperationTypes.Add });


        return Ok(data.Message);
    }

    [HttpPatch("/goods/{goodId:int}/update")]
    public async Task<IActionResult> UpdateGood(int goodId, GoodRequestModel newGood, CancellationToken cancellationToken)
    {
        GetCategoryNameRequest updatedGood;
        Response<GetCategoryNameResponse> data;

        if (string.IsNullOrEmpty(newGood.Name) || string.IsNullOrEmpty(newGood.Dics)
                    || newGood.Price <= 0) return BadRequest();
        if (newGood.CategoryId <= 0) return NotFound();

        try
        {
            data = await _requestClient.GetResponse<GetCategoryNameResponse>(
                _converter.RequestModelToGetCategoryNameRequest(newGood), cancellationToken);
            updatedGood = _goodManager.UpdateGood(goodId, newGood);
        }
        catch (NullReferenceException ex) 
        {
            return NotFound(ex.Message);
        }
        catch (MassTransitException ex)
        {
            return BadRequest("Invalid categoryId");
        }

        data.Message.Id = updatedGood.Id;
        await _publishEndpoint.Publish<GoodMessage>(new GoodMessage() { Good = data.Message, OperationType= GoodOperationTypes.Update});
        return Ok(data.Message);
    }

    [HttpDelete("/goods/{goodId:int}/delete")]
    public async Task<IActionResult> DeleteGood(int goodId)
    {
        try
        {
            _goodManager.DeleteGood(goodId);
        }
        catch (NullReferenceException ex)
        {
            return NotFound(ex.Message);
        }
        await _publishEndpoint.Publish<GoodMessage>(new GoodMessage() { Good = new GetCategoryNameResponse(){Id = goodId} ,OperationType = GoodOperationTypes.Delete});
        return Ok();
    }

    [HttpGet("/caregory/{categoryId:int}/goods")]
    public async Task<IActionResult> GetAllGoodsFromCategory(int categoryId, CancellationToken cancellationToken)
    {
        ListGetCategoryNameRequest goods;

        try
        {
            goods = _goodManager.GetAllGoodsFromCategory(categoryId);

        }
        catch (NullReferenceException ex)
        {
            return BadRequest(ex.Message);
        }

        var data = await _requestClientList.GetResponse<ListGetCategoryNameResponse>(
            goods, cancellationToken);
        
        return Ok(data.Message.Goods);
    }
    [HttpGet("/caregory/{categoryId:int}/sortGoods")]
    public async Task<IActionResult> SortGoods(int categoryId,
        string fieldName, bool ascending, CancellationToken cancellationToken)
    {
        ListGetCategoryNameRequest goods;

        try
        {
            goods = _goodManager.SortGoods(categoryId, fieldName, ascending);
        }
        catch(NullReferenceException nullEx)
        {
            return NotFound(nullEx.Message);
        }
        catch (InvalidDataException invalidEx)
        {
            return BadRequest(invalidEx.Message);
        }
        var data = await _requestClientList.GetResponse<ListGetCategoryNameResponse>(
            goods, cancellationToken);
        
        return Ok(data.Message.Goods);
    }
}