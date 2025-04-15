using Microsoft.AspNetCore.Mvc;
using ShirtStormMvc.Models;

namespace ShirtStormMvc.ViewComponents
{
    public class ProductsViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(Task<List<ProductViewModel>>? productsTask)
        {
            var products = new List<ProductViewModel>();

            if (productsTask != null)
            {
                products = await productsTask;
            }

            return View(products);
        }
    }
}
