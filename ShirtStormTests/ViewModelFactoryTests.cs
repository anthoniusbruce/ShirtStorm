using ShirtStormCommon.Models;
using ShirtStormMvc.Rules;

namespace ShirtStormTests
{
    [TestClass]
    public sealed class ViewModelFactoryTests
    {
        [TestMethod]
        public void AddressToAddressViewModel()
        {
            var idGuid = Guid.NewGuid();
            const string alias = "alias";
            const string citystatezip = "citystatezip";
            const string recipient = "recipient";
            const string address1 = "streetaddress1";
            const string address2 = "streetaddress2";
            var address = new Address 
            { 
                Alias = alias, 
                CityStateZip = citystatezip, 
                CustomerGuid = Guid.NewGuid(), 
                Id = idGuid, 
                Recipient = recipient, 
                StreetAddress1 = address1,
                StreetAddress2 = address2
            };

            var viewModel = ViewModelFactory.CreateAddressVM(address);

            Assert.AreEqual(idGuid, viewModel.Id);
            Assert.AreEqual(alias, viewModel.Alias);
            Assert.AreEqual(citystatezip, viewModel.CityStateZip);
            Assert.AreEqual(recipient, viewModel.Recipient);
            Assert.AreEqual(address1, viewModel.StreetAddress1);
            Assert.AreEqual(address2, viewModel.StreetAddress2);
        }

        [TestMethod]
        public void MinimalAddressToAddressViewModel()
        {
            var idGuid = Guid.NewGuid();
            const string citystatezip = "citystatezip";
            const string recipient = "recipient";
            const string address1 = "streetaddress1";
            var address = new Address
            {
                CityStateZip = citystatezip,
                CustomerGuid = Guid.NewGuid(),
                Id = idGuid,
                Recipient = recipient,
                StreetAddress1 = address1,
            };

            var viewModel = ViewModelFactory.CreateAddressVM(address);

            Assert.AreEqual(idGuid, viewModel.Id);
            Assert.IsTrue(string.IsNullOrEmpty(viewModel.Alias));
            Assert.AreEqual(citystatezip, viewModel.CityStateZip);
            Assert.AreEqual(recipient, viewModel.Recipient);
            Assert.AreEqual(address1, viewModel.StreetAddress1);
            Assert.IsTrue(string.IsNullOrEmpty(viewModel.StreetAddress2));
        }

        [TestMethod]
        public void NoAddressToAddressViewModel()
        {
            var viewModel = ViewModelFactory.CreateAddressVM();

            Assert.IsTrue(viewModel.Id != Guid.Empty);
            Assert.IsTrue(string.IsNullOrEmpty(viewModel.Alias));
            Assert.IsTrue(viewModel.CityStateZip == string.Empty);
            Assert.IsTrue(viewModel.Recipient == string.Empty);
            Assert.IsTrue(viewModel.StreetAddress1 == string.Empty);
            Assert.IsTrue(string.IsNullOrEmpty(viewModel.StreetAddress2));
        }
    }
}
