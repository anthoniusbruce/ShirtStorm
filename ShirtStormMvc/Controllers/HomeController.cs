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

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ShirtStormDbContext _dbContext;

    public HomeController(ILogger<HomeController> logger, ShirtStormDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    public IActionResult Index()
    {
        return View();
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
