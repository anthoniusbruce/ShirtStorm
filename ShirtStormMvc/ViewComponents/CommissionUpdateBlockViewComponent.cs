using Microsoft.AspNetCore.Mvc;
using ShirtStormMvc.Models;

namespace ShirtStormMvc.ViewComponents
{
    public class CommissionUpdateBlockViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(CommissionViewModel model)
        {
            return View(model);
        }
    }
}
