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

        [HttpPost]
        public async Task<IActionResult> AddressUpdateBlock(AddressViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index), viewModel);
            }

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

        public IActionResult Cancel()
        {
            return RedirectToAction(nameof(Index));
        }

        private async Task<Address?> GetAddress(Guid? id, Guid customerId)
        {
            return await _dbContext.Addresses.Where(a => a.CustomerGuid == customerId && a.Id == id).FirstOrDefaultAsync();
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
