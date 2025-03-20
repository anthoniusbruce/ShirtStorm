using Microsoft.AspNetCore.Mvc;
using ShirtStormMvc.Models;

namespace ShirtStormMvc.ViewComponents
{
    public class SuggestionUpdateBlockViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(SuggestionViewModel model)
        {
            return View(model);
        }
    }
}
