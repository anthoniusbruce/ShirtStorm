using Microsoft.AspNetCore.Mvc;
using ShirtStormMvc.Dtos;

namespace ShirtStormMvc.ViewComponents
{
    public class AddressViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(List<AddressDto> addresses)
        {
            return View(addresses);
        }
    }
}
