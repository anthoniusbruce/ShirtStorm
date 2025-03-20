using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShirtStormCommon.Models;
using ShirtStormMvc.Database;
using ShirtStormMvc.Models;
using ShirtStormMvc.Rules;

namespace ShirtStormMvc.Controllers
{
    [Authorize]
    [AutoValidateAntiforgeryToken]
    public class UpcomingDesignsController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ShirtStormDbContext _dbContext;
        private static readonly List<Suggestion> _suggestions =
        [
            new Suggestion {Id = Guid.NewGuid(), Description = "Get it right!", CustomerGuid = new Guid()},
            new Suggestion {Id = Guid.NewGuid(), Description = "You need a t-shirt design with feeling. In this case I'm thinking something blue with orange graphic like the picture posted. This one will be one for the ages. Everyone will want one, including your mother.", CustomerGuid=new Guid()},
            new Suggestion {Id = Guid.NewGuid(), Description = "More cowbell", CustomerGuid = new Guid()},
            new Suggestion {Id = Guid.NewGuid(), Description = "You got it right!", CustomerGuid = new Guid()},
        ];

        public UpcomingDesignsController(ILogger<HomeController> logger, ShirtStormDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index(string? addressType)
        {
            var upcomingModel = new UpcomingDesignsViewModel();

            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                var identityEmail = User.FindFirstValue("emails")!;
                var displayName = User.Identity.Name!;
                var firstName = User.FindFirstValue(ClaimTypes.GivenName)!;
                var surname = User.FindFirstValue(ClaimTypes.Surname)!;

                var customer = await (_dbContext.Customers.Where(s => s.IdentityEmail == identityEmail).FirstOrDefaultAsync<Customer>());

                if (customer == null)
                {
                    // add record
                    customer = new Customer { Id = Guid.NewGuid(), IdentityEmail = identityEmail, DisplayName = displayName, Surname = surname, FirstName = firstName, IsAMember = false };
                    _dbContext.Add(customer);
                    _dbContext.SaveChanges();
                }
                else
                {
                    // update record
                    customer.DisplayName = displayName;
                    customer.Surname = surname;
                    customer.FirstName = firstName;
                    _dbContext.Update(customer);
                    _dbContext.SaveChanges();

                    upcomingModel.IsAMember = customer.IsAMember;
                }
            }

            if (addressType == "Suggestions" || addressType == "Commissions")
            {
                ViewData["addressType"] = addressType;
            }

            return View(upcomingModel);
        }

        public async Task<IActionResult> AddressViewCrud()
        {
            var customerId = await GetCustomerId();
            var addresses = await _dbContext.Addresses.OrderBy(a => a.Alias).Where(a => a.CustomerGuid == customerId).ToListAsync()!;

            var addressViewModel = new List<AddressViewModel>();

            foreach (var address in addresses??new List<Address>())
            {
                addressViewModel.Add(ViewModelFactory.CreateAddressVM(address));
            }

            return ViewComponent("Address", addressViewModel);
        }

        public IActionResult SuggestionViewCrud()
        {
            var suggestionSummaryViewModel = new List<SuggestionViewModel>();

            foreach (var suggestion in _suggestions ?? new List<Suggestion>())
            {
                suggestionSummaryViewModel.Add(ViewModelFactory.CreateSuggestionVM(suggestion));
            }

            return ViewComponent("Suggestions", suggestionSummaryViewModel);
        }

        public async Task<IActionResult> AddressUpdateBlock(Guid? id)
        {
            AddressViewModel? addressViewModel = null;
            if (id.HasValue)
            {
                var address = await GetAddress(id, await GetCustomerId());
                if (address != null)
                {
                    addressViewModel = ViewModelFactory.CreateAddressVM(address);
                }
            }

            if (addressViewModel == null)
            {
                addressViewModel = ViewModelFactory.CreateAddressVM();
            }

            return ViewComponent("AddressUpdateBlock", addressViewModel);
        }

        public async Task<IActionResult> SuggestionUpdateBlock(Guid? id)
        {
            SuggestionViewModel? suggestionViewModel = null;
            if (id.HasValue)
            {
                var suggestion = await GetSuggestion(id, await GetCustomerId());
                if (suggestion != null)
                {
                    suggestionViewModel = ViewModelFactory.CreateSuggestionVM(suggestion);
                }
            }

            if (suggestionViewModel == null)
            {
                suggestionViewModel = ViewModelFactory.CreateSuggestionVM();
            }

            return ViewComponent("SuggestionUpdateBlock", suggestionViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddressUpdateBlock(AddressViewModel viewModel)
        {
            var customerId = await GetCustomerId();
            var address = await GetAddress(viewModel.Id, customerId);

            if (address == null)
            {
                address = ViewModelPostSubmit.TransferBack(new Address { CustomerGuid = customerId}, viewModel);
                _dbContext.Add(address);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                address = ViewModelPostSubmit.TransferBack(address, viewModel);

                _dbContext.Update(address);
                await _dbContext.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> SuggestionUpdateBlock(SuggestionViewModel viewModel)
        {
            var customerId = await GetCustomerId();
            var suggestion = await GetSuggestion(viewModel.Id, customerId);

            if (suggestion == null)
            {
                suggestion = ViewModelPostSubmit.TransferBack(new Suggestion { CustomerGuid = customerId }, viewModel);
                _suggestions.Add(suggestion);
                //_dbContext.Add(suggestion);
                //await _dbContext.SaveChangesAsync();
            }
            else
            {
                suggestion = ViewModelPostSubmit.TransferBack(suggestion, viewModel);

                for (int i = 0; i < _suggestions.Count(); i++)
                {
                    if (_suggestions[i].Id == suggestion.Id)
                        _suggestions[i] = suggestion;
                }

                //_dbContext.Update(suggestion);
                //await _dbContext.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index), new { addressType = "Suggestions" });
        }

        public async Task<IActionResult> AddressDelete(Guid id)
        {
            var address = await GetAddress(id, await GetCustomerId());
            if (address != null)
            {
                _dbContext.Remove(address);
                await _dbContext.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> SuggestionDelete(Guid id)
        {
            //var suggestion = await GetSuggestion(id, await GetCustomerId());
            //if (suggestion != null)
            //{
            //    _dbContext.Remove(suggestion);
            //    await _dbContext.SaveChangesAsync();
            //}

            var i = _suggestions.FindIndex(x => x.Id == id);
            if (i >= 0) 
            {
                _suggestions.RemoveAt(i);
            }

            return RedirectToAction(nameof(Index), new {addressType = "Suggestions"});
        }

        public IActionResult Cancel()
        {
            return RedirectToAction(nameof(Index));
        }

        private async Task<Address?> GetAddress(Guid? id, Guid customerId)
        {
            return await _dbContext.Addresses.Where(a => a.CustomerGuid == customerId && a.Id == id).FirstOrDefaultAsync();
        }

        private async Task<Suggestion?> GetSuggestion(Guid? id, Guid customerId)
        {
            //            return await _dbContext.Suggestions.Where(a => a.CustomerGuid == customerId && a.Id == id).FirstOrDefaultAsync();
            var task = Task.Run(() => _suggestions.Find(x => x.Id == id));
            return await task;
        }

        private async Task<Guid> GetCustomerId()
        {
            var identityEmail = string.Empty;
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                identityEmail = User.FindFirstValue("emails");
            }

            return await _dbContext.Customers.Where(s => s.IdentityEmail == identityEmail).Select(x => x.Id).FirstAsync()!;
        }
    }
}
