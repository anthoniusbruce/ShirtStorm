using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ShirtStormMvc.Database;
using ShirtStormMvc.Models;

namespace ShirtStormMvc.Controllers;

[AutoValidateAntiforgeryToken]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, ShirtStormDbContext dbContext)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult LoadFrontPageList()
    {
        return ViewComponent("FrontPageList");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
