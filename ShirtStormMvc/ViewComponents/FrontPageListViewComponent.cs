using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShirtStormCommon.Models;
using ShirtStormMvc.Controllers;
using ShirtStormMvc.Database;
using ShirtStormMvc.Dtos;

namespace ShirtStormMvc.ViewComponents
{
    public class FrontPageListViewComponent : ViewComponent
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ShirtStormDbContext _dbContext;

        public FrontPageListViewComponent(ILogger<HomeController> logger, ShirtStormDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }


        public IViewComponentResult Invoke()
        {
            var query = from design in _dbContext.Designs
                        where design.DisplayOnFrontPage == true
                        join image in _dbContext.Images
                            on design.ImageId equals image.Id
                        select CreateDto(design, image);

            var designs = query.ToList();

            return View(designs);
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
}
