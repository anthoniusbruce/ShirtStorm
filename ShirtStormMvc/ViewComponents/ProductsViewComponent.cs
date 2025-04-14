using Microsoft.AspNetCore.Mvc;
using ShirtStormMvc.Models;

namespace ShirtStormMvc.ViewComponents
{
    public class ProductsViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(Task<List<ProductViewModel>>? task)
        {
            List<ProductViewModel> model;
            if (task == null)
            {
                model = new List<ProductViewModel>();
            }
            else
            {
                model = await task ?? new List<ProductViewModel>();
            }

            return View(model);
        }
    }
}
