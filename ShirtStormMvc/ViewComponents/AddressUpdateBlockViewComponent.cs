using Microsoft.AspNetCore.Mvc;
using ShirtStormMvc.Dtos;

namespace ShirtStormMvc.ViewComponents
{
    public class AddressUpdateBlockViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(AddressDto dto)
        {
            return View(dto);
        }
    }
}
