using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShirtStormMvc.Database;
using ShirtStormMvc.Models;
using ShirtStormMvc.Rules;

namespace ShirtStormMvc.Controllers;

[AutoValidateAntiforgeryToken]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ShirtStormDbContext _dbContext;

    public HomeController(ILogger<HomeController> logger, ShirtStormDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult LoadFrontPageList()
    {
        var query = from design in _dbContext.Designs
                    where design.DisplayOnFrontPage == true
                    join image in _dbContext.Images
                        on design.ImageId equals image.Id
                    select ViewModelFactory.CreateFrontPageDesignVM(design, image);

        var designs = query.ToListAsync();


        return ViewComponent("FrontPageList", designs);
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
