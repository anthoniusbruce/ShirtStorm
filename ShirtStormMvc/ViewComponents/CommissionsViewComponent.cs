using Microsoft.AspNetCore.Mvc;
using ShirtStormMvc.Models;

namespace ShirtStormMvc.ViewComponents
{
    public class CommissionsViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(List<CommissionViewModel> commission)
        {
            return View(commission);
        }
    }
}
