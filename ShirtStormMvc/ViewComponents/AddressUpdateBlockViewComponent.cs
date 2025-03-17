using Microsoft.AspNetCore.Mvc;
using ShirtStormMvc.Models;

namespace ShirtStormMvc.ViewComponents
{
    public class AddressUpdateBlockViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(AddressViewModel model)
        {
            return View(model);
        }
    }
}
