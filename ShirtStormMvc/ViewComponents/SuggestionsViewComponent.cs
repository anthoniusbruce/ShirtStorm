using Microsoft.AspNetCore.Mvc;
using ShirtStormMvc.Models;

namespace ShirtStormMvc.ViewComponents
{
    public class SuggestionsViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(List<SuggestionViewModel> suggestions)
        {
            return View(suggestions);
        }
    }
}
