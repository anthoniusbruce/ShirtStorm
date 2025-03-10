using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShirtStormCommon.Models;
using ShirtStormMvc.Database;
using ShirtStormMvc.Dtos;
using ShirtStormMvc.Models;

namespace ShirtStormMvc.Controllers;

[AutoValidateAntiforgeryToken]
public class HomeController : Controller
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

    public HomeController(ILogger<HomeController> logger, ShirtStormDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult LoadFrontPageList()
    {
        return ViewComponent("FrontPageList");
    }

    [Authorize]
    public async Task<IActionResult> UpcomingDesignsAsync()
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

        return ViewComponent("Address", _addresses);
    }

    [Authorize]
    public IActionResult AddressDelete(Guid id)
    {
        _addresses!.RemoveAll(x => x.Id == id);
        return RedirectToAction("UpcomingDesigns");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
