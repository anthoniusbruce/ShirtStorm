using Microsoft.AspNetCore.Mvc;
using ShirtStormMvc.Controllers;
using ShirtStormMvc.Models;

namespace ShirtStormMvc.ViewComponents
{
    public class FrontPageListViewComponent : ViewComponent
    {
        private readonly ILogger<HomeController> _logger;

        public FrontPageListViewComponent(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public IViewComponentResult Invoke(List<FrontPageDesignViewModel> designs)
        {
            return View(designs);
        }
    }
}
