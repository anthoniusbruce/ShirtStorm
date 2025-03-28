using Microsoft.AspNetCore.Mvc;
using ShirtStormMvc.Models;

namespace ShirtStormMvc.ViewComponents
{
    public class ComingUpViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(Task<List<ComingUpViewModel>>? task)
        {
            List<ComingUpViewModel> model;
            if (task == null)
            {
                model = new List<ComingUpViewModel>();
            }
            else
            {
                model = await task ?? new List<ComingUpViewModel>();
            }

            return View(model);
        }
    }
}
