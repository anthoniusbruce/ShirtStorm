using Microsoft.AspNetCore.Mvc;

namespace ShirtStormMvc.ViewComponents
{
    public class AddressViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
