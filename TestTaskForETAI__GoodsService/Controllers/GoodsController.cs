using GoodsService__BLL.Managers;
using GoodsService__BLL.Services;
using LinqToDB.Common;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using SharedModels.MessageModels;
using SharedModels.RequestModels;
using SharedModels.ResponseModels;
using SharedModels.Enums;
using GoodsService__BLL.Interface;
using MassTransit.Clients;
using static LinqToDB.Common.Configuration;

namespace GoodsService__WebApi.Controllers;


[Route("api/[controller]")]
[ApiController]
public class GoodsController : Controller
{
    private readonly IGoodManager _goodManager;
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly IRequestClient<GoodsListMessage> _requestClientList;
    private readonly IRequestClient<GoodResponseModel> _requestClient;

    public GoodsController(IGoodManager goodManager, 
        IPublishEndpoint publishEndpoint,
        IRequestClient<GoodsListMessage> requestClientList,
        IRequestClient<GoodResponseModel> requestClient)
    {
        _goodManager = goodManager;
        _publishEndpoint = publishEndpoint;
        _requestClientList = requestClientList;
        _requestClient = requestClient;

    }

    [HttpPost("/good/add")]
    public async Task<IActionResult> AddGood(GoodRequestModel newGood)
    {
        GoodResponseModel addGood;
        Response<GoodResponseModel> data;
        if (string.IsNullOrEmpty(newGood.Name) || string.IsNullOrEmpty(newGood.Dics)
                || newGood.Price <= 0)
            return BadRequest();
        if (newGood.CategoryId <= 0) return NotFound();
        try
        {
            data = await _requestClient.GetResponse<GoodResponseModel>(newGood);
        }
        catch (MassTransitException ex)
        {
            return BadRequest(ex.Message);
        }

        addGood = _goodManager.AddGood(newGood);
        addGood.CategoryName = data.Message.CategoryName;

        await _publishEndpoint.Publish<GoodMessage>(new GoodMessage() { Good = addGood, OperationType = GoodOperationTypes.Add });
        return Ok(addGood);
    }

    [HttpPatch("/goods/{goodId:int}/update")]
    public async Task<IActionResult> UpdateGood(int goodId, GoodRequestModel newGood)
    {
        GoodResponseModel updatedGood;
        Response<GoodResponseModel> data;

        if (string.IsNullOrEmpty(newGood.Name) || string.IsNullOrEmpty(newGood.Dics)
                    || newGood.Price <= 0) return BadRequest();
        if (newGood.CategoryId <= 0) return NotFound();

        try
        {
            data = await _requestClient.GetResponse<GoodResponseModel>(newGood);
            updatedGood = _goodManager.UpdateGood(goodId, newGood);
        }
        catch (NullReferenceException ex) 
        {
            return NotFound(ex.Message);
        }
        catch (MassTransitException ex)
        {
            return BadRequest(ex.Message);
        }

        updatedGood.CategoryName = data.Message.CategoryName;
        await _publishEndpoint.Publish<GoodMessage>(new GoodMessage() { Good = updatedGood, OperationType= GoodOperationTypes.Update});
        return Ok(updatedGood);
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
        await _publishEndpoint.Publish<GoodMessage>(new GoodMessage() { Good = new GoodResponseModel(){Id = goodId} ,OperationType = GoodOperationTypes.Delete});
        return Ok();
    }

    [HttpGet("/caregory/{categoryId:int}/goods")]
    public async Task<IActionResult> GetAllGoodsFromCategory(int categoryId)
    {
        List<GoodResponseModel> goods;

        try
        {
            goods = _goodManager.GetAllGoodsFromCategory(categoryId);

        }
        catch (NullReferenceException ex)
        {
            return BadRequest(ex.Message);
        }
        
        var data = await _requestClient.GetResponse<GoodsListMessage>(goods);
        await _publishEndpoint.Publish<GoodsListMessage>(new GoodsListMessage() { Goods = data.Message.Goods });
        
        return Ok(data.Message.Goods);
    }
    [HttpGet("/caregory/{categoryId:int}/sortGoods")]
    public async Task<IActionResult> SortGoods(int categoryId,
        string fieldName, bool ascending)
    {
        List<GoodResponseModel> goods;

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

        var data = await _requestClient.GetResponse<GoodsListMessage>(goods);
        await _publishEndpoint.Publish<GoodsListMessage>(new GoodsListMessage() { Goods = data.Message.Goods });
        
        return Ok(data.Message.Goods);
    }
}