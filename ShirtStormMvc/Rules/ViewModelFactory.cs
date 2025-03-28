using ShirtStormCommon.Models;
using ShirtStormMvc.Models;

namespace ShirtStormMvc.Rules
{
    public static class ViewModelFactory
    {
        public static AddressViewModel CreateAddressVM(Address address)
        {
            var viewModel = new AddressViewModel
            {
                Alias = address.Alias,
                CityStateZip = address.CityStateZip??string.Empty,
                Recipient = address.Recipient??string.Empty,
                StreetAddress1 = address.StreetAddress1??string.Empty,
                StreetAddress2 = address.StreetAddress2,
                Id = address.Id,
            };

            return viewModel;
        }

        public static AddressViewModel CreateAddressVM()
        {
            var viewModel = new AddressViewModel
            {
                CityStateZip = string.Empty,
                Recipient = string.Empty,
                StreetAddress1 = string.Empty,
                Id = Guid.NewGuid(),
            };

            return viewModel;
        }

        public static FrontPageDesignViewModel CreateFrontPageDesignVM(Design design, Image image)
        {
            var imageSrc = Convert.ToBase64String(image.Bytes!);
            var imageDataURL = $"data:image/jpeg;base64,{imageSrc}";

            var viewModel = new FrontPageDesignViewModel
            {
                Description = design.Description ?? string.Empty,
                Title = design.Title,
                ImageSource = imageDataURL
            }
            ;
            return viewModel;
        }

        public static SuggestionViewModel CreateSuggestionVM(Suggestion suggestion)
        {
            return new SuggestionViewModel
            {
                Id = suggestion.Id,
                Description = suggestion.Description ?? string.Empty,
                CreatedDate = suggestion.CreatedDate ?? DateTime.Today
            };
        }

        public static SuggestionViewModel CreateSuggestionVM()
        {
            return new SuggestionViewModel { Id = Guid.NewGuid(), Description = string.Empty, CreatedDate = DateTime.Today };
        }

        public static CommissionViewModel CreateCommissionVM(Commission commission)
        {
            return new CommissionViewModel 
            {
                Id = commission.Id,
                Description = commission.Description ?? string.Empty,
                CreatedDate = commission.CreatedDate ?? DateTime.Today
            };
        }

        public static CommissionViewModel CreateCommissionVM()
        {
            return new CommissionViewModel { Id = Guid.NewGuid(), Description = string.Empty, CreatedDate = DateTime.Today };
        }

        public static ComingUpViewModel CreateComingUpVM(Design design, Image image)
        {
            var ret = new ComingUpViewModel
            {
                Design = CreateFrontPageDesignVM(design, image),
                DesignId = design.Id,
            };

            return ret;
        }

        public static OrderItemSummaryViewModel CreateOrderItemSummaryViewModel(OrderItem orderItem, List<Shirt> shirts, List<Address> addresses)
        {
            var model = new OrderItemSummaryViewModel
            {
                Id = orderItem.Id,
                WhoFor = orderItem.WhoFor
            };

            var shirt = shirts.Find(x => x.Id == orderItem.ShirtId);
            model.Size = shirt!.Size;
            var address = addresses.Find(x => x.Id == orderItem.AddressId);
            model.AddressAlias = address!.Alias;

            return model;
        }
    }
}
