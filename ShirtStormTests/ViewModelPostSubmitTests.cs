using ShirtStormCommon.Models;
using ShirtStormMvc.Models;
using ShirtStormMvc.Rules;

namespace ShirtStormTests;

[TestClass]
public class ViewModelPostSubmitTests
{
    [TestMethod]
    public void TransferBackToAddress()
    {
        var id = Guid.NewGuid();
        var expectedCustomerId = Guid.NewGuid();
        var recipient = "recipient";
        var alias = "alias";
        var address1 = "streetaddress1";
        var address2 = "streetaddress2";
        var citystatezip = "citystatezip";
        var expectedId = Guid.NewGuid();
        var expectedRecipient = "expectedrecipient";
        var expectedAlias = "expectedalias";
        var expectedAddress1 = "expectedstreetaddress1";
        var expectedAddress2 = "expectedstreetaddress2";
        var expectedCitystatezip = "expectedcitystatezip";
        var model = new Address
        {
            Id = id,
            CustomerGuid = expectedCustomerId,
            Alias = alias,
            Recipient = recipient,
            StreetAddress1 = address1,
            StreetAddress2 = address2,
            CityStateZip = citystatezip,
        };
        var viewModel = new AddressViewModel
        {
            Id = expectedId,
            Alias = expectedAlias,
            Recipient = expectedRecipient,
            StreetAddress1 = expectedAddress1,
            StreetAddress2 = expectedAddress2,
            CityStateZip = expectedCitystatezip,
        };

        var actual = ViewModelPostSubmit.TransferBack(model, viewModel);

        Assert.AreEqual(expectedId, actual.Id);
        Assert.AreEqual(expectedRecipient, actual.Recipient);
        Assert.AreEqual(expectedAlias, actual.Alias);
        Assert.AreEqual(expectedAddress1, actual.StreetAddress1);
        Assert.AreEqual(expectedAddress2, actual.StreetAddress2);
        Assert.AreEqual(expectedCitystatezip, actual.CityStateZip);
        Assert.AreEqual(expectedCustomerId, actual.CustomerGuid);
    }

    [TestMethod]
    public void TransferBackToAddressOnlyOneChange()
    {
        var id = Guid.NewGuid();
        var expectedCustomerId = Guid.NewGuid();
        var recipient = "recipient";
        var expectedId = Guid.NewGuid();
        var expectedRecipient = "expectedrecipient";
        var expectedAlias = "expectedalias";
        var expectedAddress1 = "expectedstreetaddress1";
        var expectedAddress2 = "expectedstreetaddress2";
        var expectedCitystatezip = "expectedcitystatezip";
        var model = new Address
        {
            Id = id,
            CustomerGuid = expectedCustomerId,
            Alias = expectedAlias,
            Recipient = recipient,
            StreetAddress1 = expectedAddress1,
            StreetAddress2 = expectedAddress2,
            CityStateZip = expectedCitystatezip,
        };
        var viewModel = new AddressViewModel
        {
            Id = expectedId,
            Alias = expectedAlias,
            Recipient = expectedRecipient,
            StreetAddress1 = expectedAddress1,
            StreetAddress2 = expectedAddress2,
            CityStateZip = expectedCitystatezip,
        };

        var actual = ViewModelPostSubmit.TransferBack(model, viewModel);

        Assert.AreEqual(expectedId, actual.Id);
        Assert.AreEqual(expectedRecipient, actual.Recipient);
        Assert.AreEqual(expectedAlias, actual.Alias);
        Assert.AreEqual(expectedAddress1, actual.StreetAddress1);
        Assert.AreEqual(expectedAddress2, actual.StreetAddress2);
        Assert.AreEqual(expectedCitystatezip, actual.CityStateZip);
        Assert.AreEqual(expectedCustomerId, actual.CustomerGuid);
    }

    [TestMethod]
    public void TransferBackToAddressNoChange()
    {
        var expectedCustomerId = Guid.NewGuid();
        var expectedId = Guid.NewGuid();
        var expectedRecipient = "expectedrecipient";
        var expectedAlias = "expectedalias";
        var expectedAddress1 = "expectedstreetaddress1";
        var expectedAddress2 = "expectedstreetaddress2";
        var expectedCitystatezip = "expectedcitystatezip";
        var model = new Address
        {
            Id = expectedId,
            CustomerGuid = expectedCustomerId,
            Alias = expectedAlias,
            Recipient = expectedRecipient,
            StreetAddress1 = expectedAddress1,
            StreetAddress2 = expectedAddress2,
            CityStateZip = expectedCitystatezip,
        };
        var viewModel = new AddressViewModel
        {
            Id = expectedId,
            Alias = expectedAlias,
            Recipient = expectedRecipient,
            StreetAddress1 = expectedAddress1,
            StreetAddress2 = expectedAddress2,
            CityStateZip = expectedCitystatezip,
        };

        var actual = ViewModelPostSubmit.TransferBack(model, viewModel);

        Assert.AreEqual(expectedId, actual.Id);
        Assert.AreEqual(expectedRecipient, actual.Recipient);
        Assert.AreEqual(expectedAlias, actual.Alias);
        Assert.AreEqual(expectedAddress1, actual.StreetAddress1);
        Assert.AreEqual(expectedAddress2, actual.StreetAddress2);
        Assert.AreEqual(expectedCitystatezip, actual.CityStateZip);
        Assert.AreEqual(expectedCustomerId, actual.CustomerGuid);
    }

    [TestMethod]
    public void TransferBackToAddressEmptyAddress()
    {
        var expectedCustomerId = Guid.NewGuid();
        var expectedId = Guid.NewGuid();
        var expectedRecipient = "expectedrecipient";
        var expectedAlias = "expectedalias";
        var expectedAddress1 = "expectedstreetaddress1";
        var expectedAddress2 = "expectedstreetaddress2";
        var expectedCitystatezip = "expectedcitystatezip";
        var model = new Address
        {
            CustomerGuid = expectedCustomerId,
        };
        var viewModel = new AddressViewModel
        {
            Id = expectedId,
            Alias = expectedAlias,
            Recipient = expectedRecipient,
            StreetAddress1 = expectedAddress1,
            StreetAddress2 = expectedAddress2,
            CityStateZip = expectedCitystatezip,
        };

        var actual = ViewModelPostSubmit.TransferBack(model, viewModel);

        Assert.AreEqual(expectedId, actual.Id);
        Assert.AreEqual(expectedRecipient, actual.Recipient);
        Assert.AreEqual(expectedAlias, actual.Alias);
        Assert.AreEqual(expectedAddress1, actual.StreetAddress1);
        Assert.AreEqual(expectedAddress2, actual.StreetAddress2);
        Assert.AreEqual(expectedCitystatezip, actual.CityStateZip);
        Assert.AreEqual(expectedCustomerId, actual.CustomerGuid);
    }

    [TestMethod]
    public void TransferBackToAddressRecipientToAlias()
    {
        var id = Guid.NewGuid();
        var expectedCustomerId = Guid.NewGuid();
        var recipient = "recipient";
        var alias = "alias";
        var address1 = "streetaddress1";
        var address2 = "streetaddress2";
        var citystatezip = "citystatezip";
        var expectedId = Guid.NewGuid();
        var expectedRecipient = "expectedrecipient";
        var expectedAddress1 = "expectedstreetaddress1";
        var expectedAddress2 = "expectedstreetaddress2";
        var expectedCitystatezip = "expectedcitystatezip";
        var model = new Address
        {
            Id = id,
            CustomerGuid = expectedCustomerId,
            Alias = alias,
            Recipient = recipient,
            StreetAddress1 = address1,
            StreetAddress2 = address2,
            CityStateZip = citystatezip,
        };
        var viewModel = new AddressViewModel
        {
            Id = expectedId,
            Recipient = expectedRecipient,
            StreetAddress1 = expectedAddress1,
            StreetAddress2 = expectedAddress2,
            CityStateZip = expectedCitystatezip,
        };

        var actual = ViewModelPostSubmit.TransferBack(model, viewModel);

        Assert.AreEqual(expectedId, actual.Id);
        Assert.AreEqual(expectedRecipient, actual.Recipient);
        Assert.AreEqual(expectedRecipient, actual.Alias);
        Assert.AreEqual(expectedAddress1, actual.StreetAddress1);
        Assert.AreEqual(expectedAddress2, actual.StreetAddress2);
        Assert.AreEqual(expectedCitystatezip, actual.CityStateZip);
        Assert.AreEqual(expectedCustomerId, actual.CustomerGuid);
    }
    [TestMethod]
    public void TransferBackToSuggestion()
    {
        var id = Guid.NewGuid();
        var expectedCustomerId = Guid.NewGuid();
        var description = "description";
        var expectedId = Guid.NewGuid();
        var expectedDescription = "expectedDescription";
        var model = new Suggestion
        {
            Id = id,
            CustomerGuid = expectedCustomerId,
            Description = description,
        };
        var viewModel = new SuggestionViewModel
        {
            Id = expectedId,
            Description = expectedDescription
        };

        var actual = ViewModelPostSubmit.TransferBack(model, viewModel);

        Assert.AreEqual(expectedId, actual.Id);
        Assert.AreEqual(expectedCustomerId, actual.CustomerGuid);
        Assert.AreEqual(expectedDescription, actual.Description);
    }

    [TestMethod]
    public void TransferBackToSuggestionOnlyOneChange()
    {
        var expectedCustomerId = Guid.NewGuid();
        var description = "description";
        var expectedId = Guid.NewGuid();
        var expectedDescription = "expectedDescription";
        var model = new Suggestion
        {
            Id = expectedId,
            CustomerGuid = expectedCustomerId,
            Description = description
        };
        var viewModel = new SuggestionViewModel
        {
            Id = expectedId,
            Description = expectedDescription
        };

        var actual = ViewModelPostSubmit.TransferBack(model, viewModel);

        Assert.AreEqual(expectedId, actual.Id);
        Assert.AreEqual(expectedCustomerId, actual.CustomerGuid);
        Assert.AreEqual(expectedDescription, actual.Description);
    }

    [TestMethod]
    public void TransferBackToSuggestionNoChange()
    {
        var expectedCustomerId = Guid.NewGuid();
        var expectedId = Guid.NewGuid();
        var expectedDescription = "expectedDescription";
        var model = new Suggestion
        {
            Id = expectedId,
            CustomerGuid = expectedCustomerId,
            Description = expectedDescription,
        };
        var viewModel = new SuggestionViewModel
        {
            Id = expectedId,
            Description = expectedDescription
        };

        var actual = ViewModelPostSubmit.TransferBack(model, viewModel);

        Assert.AreEqual(expectedId, actual.Id);
        Assert.AreEqual(expectedCustomerId, actual.CustomerGuid);
        Assert.AreEqual(expectedDescription, actual.Description);
    }

    [TestMethod]
    public void TransferBackToSuggestionEmptySuggestion()
    {
        var expectedCustomerId = Guid.NewGuid();
        var expectedId = Guid.NewGuid();
        var expectedDescription = "expectedDescription";
        var model = new Suggestion
        {
            CustomerGuid = expectedCustomerId,
        };
        var viewModel = new SuggestionViewModel
        {
            Id = expectedId,
            Description= expectedDescription
        };

        var actual = ViewModelPostSubmit.TransferBack(model, viewModel);

        Assert.AreEqual(expectedId, actual.Id);
        Assert.AreEqual(expectedCustomerId, actual.CustomerGuid);
        Assert.AreEqual(expectedDescription, actual.Description);
    }
}
