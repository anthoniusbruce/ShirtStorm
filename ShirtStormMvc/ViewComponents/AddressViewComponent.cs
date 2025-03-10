using Microsoft.AspNetCore.Mvc;
using ShirtStormMvc.Database;
using ShirtStormMvc.Dtos;

namespace ShirtStormMvc.ViewComponents
{
    public class AddressViewComponent : ViewComponent
    {
        private readonly ShirtStormDbContext _dbContext;
        private List<AddressDto> _addresses;

        public AddressViewComponent(ShirtStormDbContext dbContext)
        {
            _dbContext = dbContext;
            _addresses = new List<AddressDto>
                {
                    new AddressDto {Id = Guid.NewGuid(), Alias = "Home", Recipient="Andy Collins", StreetAddress1="46594 Gunnery Drive", CityStateZip="Canton, MI 48487" },
                    new AddressDto {Id = Guid.NewGuid(), Alias = "Home2", Recipient="Jennifer Collins", StreetAddress1="46594 Gunnery DR", CityStateZip="Canton MI 48487" },
                    new AddressDto {Id = Guid.NewGuid(), Alias = "Cape", Recipient="Alex Collins", StreetAddress1="103 International Drive", StreetAddress2="Apt 803", CityStateZip="Cape Canaveral, FL 99088" },
                    new AddressDto {Id = Guid.NewGuid(), Alias = "WH", Recipient="John Collins", StreetAddress1="1600 Pennsylvania Avenue", CityStateZip="Washington, DC 10001" },
                };
        }

        public IViewComponentResult Invoke()
        {
            var addresses = new List<AddressDto>();

            if (User.Identity != null && User.Identity.IsAuthenticated && !string.IsNullOrWhiteSpace(ViewData["identityEmail"] as string))
            {
                //var identityEmail = ViewData["identityEmail"] as string;

                //var customer = _dbContext.Customers.Where(s => s.IdentityEmail == identityEmail).FirstOrDefault();

                addresses = _addresses;
            }

            return View(addresses);
        }
    }
}
