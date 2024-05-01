using GoodsService__BLL.Interfaces;
using GoodsService__BLL.Managers;
using GoodsService__BLL.Services;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using SharedModels.MessageModels;
using SharedModels.RequestModels;
using SharedModels.ResponseModels;


namespace GoodsService__WebApi.Controllers;


[Route("api/[controller]")]
[ApiController]
public class GoodsController : Controller
{
    private readonly IGoodManager _goodManager;
    private readonly IPublishEndpoint _publishEndpoint;

    public GoodsController(IGoodManager goodManager, IPublishEndpoint publishEndpoint)
    {
        _goodManager = goodManager;
        _publishEndpoint = publishEndpoint;
    }

    [HttpPost("/addGood")]
    public async Task<IActionResult> AddGood(GoodRequestModel newGood)
    {
        GoodResponseModel addGood;
        if (string.IsNullOrEmpty(newGood.Name) || string.IsNullOrEmpty(newGood.Dics)
                || newGood.Price <= 0)
            return NoContent();
        if (newGood.CategoryId <= 0) return NotFound();
        addGood = _goodManager.AddGood(newGood);
        await _publishEndpoint.Publish(addGood);
        return Ok(addGood);
    }

    [HttpPatch("/updateGood/goodId={goodId:int}")]
    public async Task<IActionResult> UpdateGood(int goodId, GoodRequestModel newGood)
    {
        if (string.IsNullOrEmpty(newGood.Name) || string.IsNullOrEmpty(newGood.Dics)
                    || newGood.Price <= 0) return NoContent();
        if (newGood.CategoryId <= 0) return NotFound();
        GoodResponseModel updatedGood;
        try
        {
            updatedGood = _goodManager.UpdateGood(goodId, newGood);
        }
        catch (NullReferenceException ex) 
        {
            return NotFound(ex.Message);
        }
        await _publishEndpoint.Publish<GoodRequestModel>(updatedGood);
        return Ok(updatedGood);
    }

    [HttpDelete("/deleteGood/goodId={goodId:int}")]
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
        return Ok();
    }

    [HttpGet("getAllGoodsFromCategory/categoryId={categoryId:int}")]
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
        await _publishEndpoint.Publish(new GoodsListMessage() { Goods = goods });
        return Ok(goods);
    }
    [HttpGet("sortGoods/categoryId={categoryId:int}")]
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
        await _publishEndpoint.Publish(new GoodsListMessage() { Goods = goods });
        return Ok(goods);
    }
}