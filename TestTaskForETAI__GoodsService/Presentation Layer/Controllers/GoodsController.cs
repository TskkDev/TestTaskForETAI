using MassTransit;
using Microsoft.AspNetCore.Mvc;
using SharedModels.MessageModels;
using SharedModels.RequestModels;
using SharedModels.ResponseModels;
using TestTaskForETAI__GoodsService.Business_Logic_Layer.Services;
using TestTaskForETAI__GoodsService.Data_Access_Layer.Enities;
using TestTaskForETAI__GoodsService.Data_Access_Layer.Repositories;

namespace TestTaskForETAI__GoodsService.Presentation_Layer.Controllers;


[Route("api/[controller]")]
[ApiController]
public class GoodsController : Controller
{
    private readonly IConfiguration _configuration;
    private readonly ConvertModelToEntityService _converter;
    private readonly IPublishEndpoint _publishEndpoint;

    public GoodsController(IConfiguration configuration, IPublishEndpoint publishEndpoint)
    {
        _configuration = configuration;
        _publishEndpoint = publishEndpoint;
        _converter = new ConvertModelToEntityService();
    }

    [HttpPost("/addGood")]
    public async Task<IActionResult> AddGood(GoodRequestModel newGood)
    {
        GoodResponseModel addGood;
        if (String.IsNullOrEmpty(newGood.Name) || String.IsNullOrEmpty(newGood.Dics) 
                || newGood.Price <= 0 )
            return NoContent();
        if (newGood.CategoryId <= 0) return NotFound();
        using (var db = new DbConection(_configuration))
        {
            var repos = new GoodsRepostiry(db);
            addGood = _converter.EntityToResponseModel(
                repos.Add(_converter.RequestModelToEntity(newGood)));
        }
        await _publishEndpoint.Publish<GoodResponseModel>(addGood);
        return Ok(addGood);
    }
    
    [HttpPatch("/updateGood/goodId={goodId:int}")]
    public async Task<IActionResult> UpdateGood(int goodId,GoodRequestModel newGood)
    {
        if (String.IsNullOrEmpty(newGood.Name) || String.IsNullOrEmpty(newGood.Dics) 
                    || newGood.Price <= 0 ) return NoContent();
        if (newGood.CategoryId <= 0) return NotFound();
        GoodResponseModel updatedGood;
        using (var db = new DbConection(_configuration))
        {
            var repos = new GoodsRepostiry(db);
            var oldGood = repos.GetById(goodId);
            if (oldGood is null) return NotFound(); 
            updatedGood = _converter.EntityToResponseModel(
                repos.Update(oldGood, _converter.RequestModelToEntity(newGood))
                );
        }
        await _publishEndpoint.Publish<GoodRequestModel>(updatedGood);
        return Ok(updatedGood);
    }

    [HttpDelete("/deleteGood/goodId={goodId:int}")]
    public async Task<IActionResult> DeleteGood(int goodId)
    {
        using (var db = new DbConection(_configuration))
        {
            var repos = new GoodsRepostiry(db);
            var deletedGood = repos.GetById(goodId);
            if (deletedGood is null) return NotFound(); 
            repos.Delete(goodId);
        }
        return Ok();
    }

    [HttpGet("getAllGoodsFromCategory/categoryId={categoryId:int}")]
    public async Task<IActionResult> GetAllGoodsFromCategory(int categoryId)
    {
        List<GoodResponseModel> goods;
        using (var db = new DbConection(_configuration))
        {
            var repos = new GoodsRepostiry(db);
            goods = _converter.EntitiesToResponseModels(
                repos.GetAllGoodsFromCategory(categoryId).ToList());
            if (goods.Count() == 0) return BadRequest();
            await _publishEndpoint.Publish<GoodsListMessage>(new GoodsListMessage(){Goods = goods});
            return Ok(goods);
        }
    }
    [HttpGet("sortGoods/categoryId={categoryId:int}")]
    public async Task<IActionResult> SortGoods(int categoryId, 
        string fieldName, bool ascending)
    {
        List<GoodResponseModel> goods;
        using (var db = new DbConection(_configuration))
        {
            var repos = new GoodsRepostiry(db);
            goods = _converter.EntitiesToResponseModels(
                repos.SortGoods(categoryId, fieldName, ascending).ToList());
            if (goods.Count() == 0) return BadRequest();
            await _publishEndpoint.Publish<GoodsListMessage>(new GoodsListMessage(){Goods = goods});
            return Ok(goods);
        }
    }
}