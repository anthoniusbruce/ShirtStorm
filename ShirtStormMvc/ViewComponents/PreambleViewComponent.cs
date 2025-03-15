using Microsoft.AspNetCore.Mvc;
using ShirtStormMvc.Models;

namespace ShirtStormMvc.ViewComponents
{
    public class PreambleViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string? finalTagLine)
        {
            return View(new PreambleViewModel { FinalTagLine = finalTagLine });
        }
    }
}
