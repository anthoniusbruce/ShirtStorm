using ShirtStormCommon.Models;
using ShirtStormMvc.Models;

namespace ShirtStormMvc.Rules
{
    public static class ViewModelPostSubmit
    {
        public static Address TransferBack(Address model, AddressViewModel viewModel)
        {
            model.Id = viewModel.Id;
            model.Recipient = viewModel.Recipient;
            model.StreetAddress1 = viewModel.StreetAddress1;
            model.StreetAddress2 = viewModel.StreetAddress2;
            model.CityStateZip = viewModel.CityStateZip;

            if (string.IsNullOrWhiteSpace(viewModel.Alias))
            {
                model.Alias = viewModel.Recipient;
            }
            else
            {
                model.Alias = viewModel.Alias;
            }

                return model;
        }
        public static Suggestion TransferBack(Suggestion model, SuggestionViewModel viewModel)
        {
            model.Id = viewModel.Id;
            model.Description = viewModel.Description;
            model.CreatedDate = viewModel.CreatedDate;

            return model;
        }

        public static Commission TransferBack(Commission model, CommissionViewModel viewModel)
        {
            model.Id = viewModel.Id;
            model.Description = viewModel.Description;
            model.CreatedDate = viewModel.CreatedDate;

            return model;
        }
    }
}
