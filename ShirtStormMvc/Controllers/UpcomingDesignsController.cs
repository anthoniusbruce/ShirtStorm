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

        public async Task<IActionResult> AddressViewCrud()
        {
            var customerId = await GetCustomerId();
            var addresses = await _dbContext.Addresses.Where(a => a.CustomerGuid == customerId).ToListAsync()!;

            var addressDtos = new List<AddressDto>();

            foreach (var address in addresses??new List<Address>())
            {
                addressDtos.Add(new AddressDto
                {
                    Id = address.Id,
                    Recipient = address.Recipient ?? string.Empty,
                    StreetAddress1 = address.StreetAddress1 ?? string.Empty,
                    StreetAddress2 = address.StreetAddress2,
                    CityStateZip = address.CityStateZip ?? string.Empty,
                    Alias = address.Alias
                });
            }

            return ViewComponent("Address", addressDtos);
        }

        public async Task<IActionResult> AddressUpdateBlock(Guid? id)
        {
            AddressDto? addressDto = null;
            if (id.HasValue)
            {
                var address = await GetAddress(id);
                if (address != null)
                {
                    addressDto = new AddressDto()
                    {
                        Id = address.Id,
                        Alias = address.Alias,
                        Recipient = address.Recipient ?? string.Empty,
                        StreetAddress1 = address.StreetAddress1 ?? string.Empty,
                        StreetAddress2 = address.StreetAddress2,
                        CityStateZip = address.CityStateZip ?? string.Empty
                    };
                }
            }

            if (addressDto == null)
            {
                addressDto = new AddressDto() 
                { 
                    Alias = string.Empty, 
                    CityStateZip = string.Empty, 
                    Recipient = string.Empty,
                    StreetAddress1 = string.Empty,
                    StreetAddress2 = string.Empty, 
                    Id = Guid.NewGuid() 
                };
            }

            return ViewComponent("AddressUpdateBlock", addressDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddressUpdateBlock(AddressDto dto)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index), dto);
            }

            if (string.IsNullOrWhiteSpace(dto.Alias))
                dto.Alias = dto.Recipient;

            var address = await GetAddress(dto.Id);

            if (address == null)
            {
                _dbContext.Add(new Address
                {
                    Id = dto.Id,
                    CustomerGuid = await GetCustomerId(),
                    Alias = dto.Alias,
                    Recipient = dto.Recipient,
                    StreetAddress1 = dto.StreetAddress1,
                    StreetAddress2 = dto.StreetAddress2,
                    CityStateZip = dto.CityStateZip
                });
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                address.Alias = dto.Alias;
                address.Recipient = dto.Recipient;
                address.StreetAddress1 = dto.StreetAddress1;
                address.StreetAddress2 = dto.StreetAddress2;
                address.CityStateZip = dto.CityStateZip;
                _dbContext.Update(address);
                await _dbContext.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> AddressDelete(Guid id)
        {
            var address = await GetAddress(id);
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

        private async Task<Address?> GetAddress(Guid? id)
        {
            var customerId = await GetCustomerId();
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
