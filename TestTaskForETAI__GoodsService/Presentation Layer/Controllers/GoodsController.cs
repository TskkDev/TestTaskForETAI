using Microsoft.AspNetCore.Mvc;

namespace TestTaskForETAI__GoodsService.Presentation_Layer.Controllers;

public class GoodsController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}