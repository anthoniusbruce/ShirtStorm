using Microsoft.AspNetCore.Mvc;
using ShirtStormMvc.Models;

namespace ShirtStormMvc.ViewComponents
{
    public class AddressViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(List<AddressViewModel> addresses)
        {
            return View(addresses);
        }
    }
}
