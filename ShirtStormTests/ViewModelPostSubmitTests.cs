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
        var created = DateTime.MaxValue;
        var expectedCreated = DateTime.MinValue;
        var expectedCustomerId = Guid.NewGuid();
        var description = "description";
        var expectedId = Guid.NewGuid();
        var expectedDescription = "expectedDescription";
        var model = new Suggestion
        {
            Id = id,
            CustomerGuid = expectedCustomerId,
            Description = description,
            CreatedDate = created
        };
        var viewModel = new SuggestionViewModel
        {
            Id = expectedId,
            Description = expectedDescription,
            CreatedDate = expectedCreated
        };

        var actual = ViewModelPostSubmit.TransferBack(model, viewModel);

        Assert.AreEqual(expectedId, actual.Id);
        Assert.AreEqual(expectedCustomerId, actual.CustomerGuid);
        Assert.AreEqual(expectedDescription, actual.Description);
        Assert.AreEqual(expectedCreated, actual.CreatedDate);
    }

    [TestMethod]
    public void TransferBackToSuggestionOnlyOneChange()
    {
        var expectedCustomerId = Guid.NewGuid();
        var description = "description";
        var expectedId = Guid.NewGuid();
        var expectedDescription = "expectedDescription";
        var expectedCreated = DateTime.MinValue;
        var model = new Suggestion
        {
            Id = expectedId,
            CustomerGuid = expectedCustomerId,
            Description = description,
            CreatedDate = expectedCreated
        };
        var viewModel = new SuggestionViewModel
        {
            Id = expectedId,
            Description = expectedDescription,
            CreatedDate = expectedCreated
        };

        var actual = ViewModelPostSubmit.TransferBack(model, viewModel);

        Assert.AreEqual(expectedId, actual.Id);
        Assert.AreEqual(expectedCustomerId, actual.CustomerGuid);
        Assert.AreEqual(expectedCreated, actual.CreatedDate);
        Assert.AreEqual(expectedDescription, actual.Description);
    }

    [TestMethod]
    public void TransferBackToSuggestionNoChange()
    {
        var expectedCustomerId = Guid.NewGuid();
        var expectedId = Guid.NewGuid();
        var expectedDescription = "expectedDescription";
        var expectedCreatedDate = DateTime.MinValue;
        var model = new Suggestion
        {
            Id = expectedId,
            CustomerGuid = expectedCustomerId,
            Description = expectedDescription,
            CreatedDate = expectedCreatedDate
        };
        var viewModel = new SuggestionViewModel
        {
            Id = expectedId,
            Description = expectedDescription,
            CreatedDate= expectedCreatedDate
        };

        var actual = ViewModelPostSubmit.TransferBack(model, viewModel);

        Assert.AreEqual(expectedId, actual.Id);
        Assert.AreEqual(expectedCustomerId, actual.CustomerGuid);
        Assert.AreEqual(expectedDescription, actual.Description);
        Assert.AreEqual(expectedCreatedDate, actual.CreatedDate);
    }

    [TestMethod]
    public void TransferBackToSuggestionEmptySuggestion()
    {
        var expectedCreatedDate = DateTime.MinValue;
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
            Description= expectedDescription,
            CreatedDate = expectedCreatedDate
        };

        var actual = ViewModelPostSubmit.TransferBack(model, viewModel);

        Assert.AreEqual(expectedId, actual.Id);
        Assert.AreEqual(expectedCustomerId, actual.CustomerGuid);
        Assert.AreEqual(expectedDescription, actual.Description);
        Assert.AreEqual(expectedCreatedDate, actual.CreatedDate);
    }

    [TestMethod]
    public void TransferBackToCommission()
    {
        var id = Guid.NewGuid();
        var created = DateTime.MaxValue;
        var expectedCreated = DateTime.MinValue;
        var expectedCustomerId = Guid.NewGuid();
        var description = "description";
        var expectedId = Guid.NewGuid();
        var expectedDescription = "expectedDescription";
        var model = new Commission
        {
            Id = id,
            CustomerId = expectedCustomerId,
            Description = description,
            CreatedDate = created
        };
        var viewModel = new CommissionViewModel
        {
            Id = expectedId,
            Description = expectedDescription,
            CreatedDate = expectedCreated
        };

        var actual = ViewModelPostSubmit.TransferBack(model, viewModel);

        Assert.AreEqual(expectedId, actual.Id);
        Assert.AreEqual(expectedCustomerId, actual.CustomerId);
        Assert.AreEqual(expectedDescription, actual.Description);
        Assert.AreEqual(expectedCreated, actual.CreatedDate);
    }

    [TestMethod]
    public void TransferBackToCommissionOnlyOneChange()
    {
        var expectedCustomerId = Guid.NewGuid();
        var description = "description";
        var expectedId = Guid.NewGuid();
        var expectedDescription = "expectedDescription";
        var expectedCreated = DateTime.MinValue;
        var model = new Commission
        {
            Id = expectedId,
            CustomerId = expectedCustomerId,
            Description = description,
            CreatedDate = expectedCreated
        };
        var viewModel = new CommissionViewModel
        {
            Id = expectedId,
            Description = expectedDescription,
            CreatedDate = expectedCreated
        };

        var actual = ViewModelPostSubmit.TransferBack(model, viewModel);

        Assert.AreEqual(expectedId, actual.Id);
        Assert.AreEqual(expectedCustomerId, actual.CustomerId);
        Assert.AreEqual(expectedCreated, actual.CreatedDate);
        Assert.AreEqual(expectedDescription, actual.Description);
    }

    [TestMethod]
    public void TransferBackToCommissionNoChange()
    {
        var expectedCustomerId = Guid.NewGuid();
        var expectedId = Guid.NewGuid();
        var expectedDescription = "expectedDescription";
        var expectedCreatedDate = DateTime.MinValue;
        var model = new Commission
        {
            Id = expectedId,
            CustomerId = expectedCustomerId,
            Description = expectedDescription,
            CreatedDate = expectedCreatedDate
        };
        var viewModel = new CommissionViewModel
        {
            Id = expectedId,
            Description = expectedDescription,
            CreatedDate = expectedCreatedDate
        };

        var actual = ViewModelPostSubmit.TransferBack(model, viewModel);

        Assert.AreEqual(expectedId, actual.Id);
        Assert.AreEqual(expectedCustomerId, actual.CustomerId);
        Assert.AreEqual(expectedDescription, actual.Description);
        Assert.AreEqual(expectedCreatedDate, actual.CreatedDate);
    }

    [TestMethod]
    public void TransferBackToCommissionEmptySuggestion()
    {
        var expectedCreatedDate = DateTime.MinValue;
        var expectedCustomerId = Guid.NewGuid();
        var expectedId = Guid.NewGuid();
        var expectedDescription = "expectedDescription";
        var model = new Commission
        {
            CustomerId = expectedCustomerId,
        };
        var viewModel = new CommissionViewModel
        {
            Id = expectedId,
            Description = expectedDescription,
            CreatedDate = expectedCreatedDate
        };

        var actual = ViewModelPostSubmit.TransferBack(model, viewModel);

        Assert.AreEqual(expectedId, actual.Id);
        Assert.AreEqual(expectedCustomerId, actual.CustomerId);
        Assert.AreEqual(expectedDescription, actual.Description);
        Assert.AreEqual(expectedCreatedDate, actual.CreatedDate);
    }
}
