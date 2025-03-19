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

        public static SuggestionSummaryViewModel CreateSuggestionSummaryVM(Suggestion suggestion)
        {
            return new SuggestionSummaryViewModel
            {
                Id = suggestion.Id,
                Description = suggestion.Description ?? string.Empty,
                HasImage = suggestion.ImageId.HasValue
            };
        }
    }
}
