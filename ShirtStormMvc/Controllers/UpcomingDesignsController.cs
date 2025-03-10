using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShirtStormCommon.Models;
using ShirtStormMvc.Dtos;
using ShirtStormMvc.Database;

namespace ShirtStormMvc.Controllers
{
    public class UpcomingDesignsController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ShirtStormDbContext _dbContext;
        private static List<AddressDto> _addresses = new List<AddressDto>
        {
        new AddressDto {Id = Guid.NewGuid(), Alias = "Home", Recipient="Andy Collins", StreetAddress1="46594 Gunnery Drive", CityStateZip="Canton, MI 48487" },
        new AddressDto {Id = Guid.NewGuid(), Alias = "Home2", Recipient="Jennifer Collins", StreetAddress1="46594 Gunnery DR", CityStateZip="Canton MI 48487" },
        new AddressDto {Id = Guid.NewGuid(), Alias = "Cape", Recipient="Alex Collins", StreetAddress1="103 International Drive", StreetAddress2="Apt 803", CityStateZip="Cape Canaveral, FL 99088" },
        new AddressDto {Id = Guid.NewGuid(), Alias = "WH", Recipient="John Collins", StreetAddress1="1600 Pennsylvania Avenue", CityStateZip="Washington, DC 10001" },
        };

        public UpcomingDesignsController(ILogger<HomeController> logger, ShirtStormDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var upcoming = new UpcomingDesignsDto();

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

                    upcoming.IsAMember = customer.IsAMember;
                }
            }

            return View(upcoming);
        }

        [Authorize]
        public IActionResult AddressViewCrud()
        {
            var identityEmail = string.Empty;
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                identityEmail = User.FindFirstValue("emails");
            }

            ViewData["identityEmail"] = identityEmail;

            var addresses = new List<AddressDto>();

            //addresses = _addresses;

            return ViewComponent("Address", addresses);
        }

        [Authorize]
        public IActionResult AddressDelete(Guid id)
        {
            _addresses!.RemoveAll(x => x.Id == id);
            return RedirectToAction(nameof(Index));
        }
    }
}
