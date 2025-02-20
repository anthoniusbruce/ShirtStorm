using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ShirtStormCommon.Models;
using ShirtStormMvc.Database;
using ShirtStormMvc.Dtos;
using ShirtStormMvc.Models;

namespace ShirtStormMvc.Controllers;

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
        var designs = new List<FrontPageDesignDto>();

        var query = from design in _dbContext.Designs
                    where design.DisplayOnFrontPage == true
                    join image in _dbContext.Images
                        on design.ImageId equals image.Id
                    select CreateDto(design, image);

        designs = query.ToList();

        return View(designs);
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

    private static FrontPageDesignDto CreateDto(Design design, Image image)
    {
        var imageSrc = Convert.ToBase64String(image.Bytes!);
        var imageDataURL = $"data:image/jpeg;base64,{imageSrc}";

        var dto = new FrontPageDesignDto
        {
            Title = design.Title!,
            Description = design.Description!,
            ImageSource = imageDataURL
        };

        return dto;
    }
}
