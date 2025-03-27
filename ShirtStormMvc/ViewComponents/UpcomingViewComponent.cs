using Microsoft.AspNetCore.Mvc;
using ShirtStormMvc.Models;

namespace ShirtStormMvc.ViewComponents
{
    public class UpcomingViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string? finalTagLine)
        {
            return View();
        }
    }
}
