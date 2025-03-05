using Microsoft.AspNetCore.Mvc;

namespace ShirtStormMvc.ViewComponents
{
    public class PreambleViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
