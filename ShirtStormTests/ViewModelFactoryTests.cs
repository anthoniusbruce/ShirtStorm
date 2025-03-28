using System.Text;
using ShirtStormCommon.Models;
using ShirtStormMvc.Rules;

namespace ShirtStormTests
{
    [TestClass]
    public sealed class ViewModelFactoryTests
    {
        [TestMethod]
        public void CreateUpcomingnModel()
        {
            var imageId = Guid.NewGuid();
            var bytes = Encoding.UTF8.GetBytes("Bytes");
            var expectedImageSource = $"data:image/jpeg;base64,{Convert.ToBase64String(bytes)}";
            var designId = new Guid();
            var expDescription = "description";
            var displayOnFrontPage = true;
            var expTitle = "title";
            var releaseDate = DateTime.Now;
            var expectedOrderTotal = 0;
            var image = new Image
            {
                Id = imageId,
                Bytes = bytes
            };
            var design = new Design
            {
                Id = designId,
                Description = expDescription,
                DisplayOnFrontPage = displayOnFrontPage,
                Title = expTitle,
                ImageId = imageId,
                ReleaseDate = releaseDate,
            };

            var actual = ViewModelFactory.CreateComingUpVM(design, image);

            Assert.AreEqual(expDescription, actual.Design.Description);
            Assert.AreEqual(expTitle, actual.Design.Title);
            Assert.AreEqual(expectedImageSource, actual.Design.ImageSource);
            Assert.AreEqual(expectedOrderTotal, actual.OrderTotal);
        }

        [TestMethod]
        public void CreateCommissionViewModel()
        {
            var expectedId = Guid.NewGuid();
            var expectedDescription = "expectedDescription";
            var expectedCreatedDate = DateTime.MinValue;
            var commission = new Commission
            {
                Id = expectedId,
                CustomerId = new Guid(),
                Description = expectedDescription,
                CreatedDate = expectedCreatedDate
            };
         
            var actual = ViewModelFactory.CreateCommissionVM(commission);

            Assert.AreEqual(expectedId, actual.Id);
            Assert.AreEqual(expectedDescription, actual.Description);
            Assert.AreEqual(expectedCreatedDate, actual.CreatedDate);
        }

        [TestMethod]
        public void NoCommissionToCommisionViewModel()
        {
            var viewModel = ViewModelFactory.CreateCommissionVM();

            Assert.IsFalse(viewModel.Id == Guid.Empty);
            Assert.IsTrue(string.IsNullOrEmpty(viewModel.Description));
            Assert.AreEqual(DateTime.Today, viewModel.CreatedDate);
        }

        [TestMethod]
        public void CreateSuggestionViewModel()
        {
            var expectedId = Guid.NewGuid();
            var expectedDescription = "expectedDescription";
            var expectedCreatedDate = DateTime.MinValue;
            var suggestion = new Suggestion
            {
                Id = expectedId,
                CustomerGuid = new Guid(),
                Description = expectedDescription,
                CreatedDate = expectedCreatedDate
            };

            var actual = ViewModelFactory.CreateSuggestionVM(suggestion);

            Assert.AreEqual(expectedId, actual.Id);
            Assert.AreEqual(expectedDescription, actual.Description);
            Assert.AreEqual(expectedCreatedDate, actual.CreatedDate);
        }

        [TestMethod]
        public void NoSuggestionToSuggestionViewModel()
        {
            var viewModel = ViewModelFactory.CreateSuggestionVM();

            Assert.IsFalse(viewModel.Id == Guid.Empty);
            Assert.IsTrue(string.IsNullOrEmpty(viewModel.Description));
            Assert.AreEqual(DateTime.Today, viewModel.CreatedDate);
        }

        [TestMethod]
        public void CreateFrontPageDesignModel()
        {
            var imageId = Guid.NewGuid();
            var bytes = Encoding.UTF8.GetBytes("Bytes");
            var expectedImageSource = $"data:image/jpeg;base64,{Convert.ToBase64String(bytes)}";
            var designId = new Guid();
            var expDescription = "description";
            var displayOnFrontPage = true;
            var expTitle = "title";
            var releaseDate = DateTime.Now;
            var image = new Image
            {
                Id = imageId,
                Bytes = bytes
            };
            var design = new Design
            {
                Id = designId,
                Description = expDescription,
                DisplayOnFrontPage = displayOnFrontPage,
                Title = expTitle,
                ImageId = imageId,
                ReleaseDate = releaseDate,
            };

            var actual = ViewModelFactory.CreateFrontPageDesignVM(design, image);

            Assert.AreEqual(expDescription, actual.Description);
            Assert.AreEqual(expTitle, actual.Title);
            Assert.AreEqual(expectedImageSource, actual.ImageSource);
        }

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
