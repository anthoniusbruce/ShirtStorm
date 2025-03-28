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


        public async Task<IViewComponentResult> InvokeAsync(Task<List<FrontPageDesignViewModel>> task)
        {
            List<FrontPageDesignViewModel> designs = new List<FrontPageDesignViewModel>();
            if (task == null)
            {
                designs = new List<FrontPageDesignViewModel>();
            }
            else
            {
                designs = await task ?? new List<FrontPageDesignViewModel>();
            }

            return View(designs);
        }
    }
}
