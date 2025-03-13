using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShirtStormCommon.Models;
using ShirtStormMvc.Dtos;
using ShirtStormMvc.Database;

namespace ShirtStormMvc.Controllers
{
    [Authorize]
    [AutoValidateAntiforgeryToken]
    public class UpcomingDesignsController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ShirtStormDbContext _dbContext;
        private static List<AddressDto> _addresses = new List<AddressDto>();

        public UpcomingDesignsController(ILogger<HomeController> logger, ShirtStormDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

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

        public IActionResult AddressViewCrud()
        {
            var identityEmail = string.Empty;
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                identityEmail = User.FindFirstValue("emails");
            }

            ViewData["identityEmail"] = identityEmail;

            var addresses = new List<AddressDto>();

            addresses = _addresses;

            return ViewComponent("Address", addresses);
        }

        public IActionResult AddressUpdateBlock(Guid? id)
        {
            AddressDto addressDto;
            if (id.HasValue && _addresses.Exists(x => x.Id == id))
            {
                addressDto = _addresses.Find(x => x.Id == id)!;
            }
            else
            {
                addressDto = new AddressDto() { Alias = string.Empty, CityStateZip = string.Empty, Recipient = string.Empty, StreetAddress1 = string.Empty, Id = Guid.NewGuid() };
            }

            return ViewComponent("AddressUpdateBlock", addressDto);
        }

        [HttpPost]
        public IActionResult AddressUpdateBlock(AddressDto dto)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index), dto);
            }

            if (string.IsNullOrWhiteSpace(dto.Alias))
                dto.Alias = dto.Recipient;
            if (_addresses.Exists(x => x.Id == dto.Id))
            {
                var index = _addresses.FindIndex(x => x.Id == dto.Id);
                _addresses[index] = dto;
            }
            else
            {
                _addresses.Add(dto!);
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult AddressDelete(Guid id)
        {
            _addresses!.RemoveAll(x => x.Id == id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Cancel()
        {
            return RedirectToAction(nameof(Index));
        }
    }
}
