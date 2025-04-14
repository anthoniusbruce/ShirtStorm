using System.Text;
using ShirtStormCommon.Models;
using ShirtStormMvc.Rules;

namespace ShirtStormTests
{
    [TestClass]
    public sealed class ViewModelFactoryTests
    {
        [TestMethod]
        public void CreateOrderItemSummaryModel()
        {
            var expectedWhoFor = "Who For 1";
            var expectedSize = "S";
            var expectedAddressAlias = "Alias 2";
            var shirts = new List<Shirt>
            {
                new Shirt {Id = new Guid("5EDB1302-4DF1-4FB2-9C2D-143F99126549"), Brand = "Gildan", Model="G500", Size=expectedSize},
                new Shirt {Id = new Guid("AEA43BBA-8E2E-422B-899A-FFFD527348E8"), Brand = "Gildan", Model="G500", Size="M"},
                new Shirt {Id = Guid.NewGuid(), Brand = "Gildan", Model="G500", Size="L"},
                new Shirt {Id = Guid.NewGuid(), Brand = "Gildan", Model="G500", Size="XL"},
                new Shirt {Id = Guid.NewGuid(), Brand = "Gildan", Model="G500", Size="2XL"},
                new Shirt {Id = Guid.NewGuid(), Brand = "Gildan", Model="G500", Size="3XL"},
                new Shirt {Id = Guid.NewGuid(), Brand = "Gildan", Model="G500", Size="4XL"},
                new Shirt {Id = Guid.NewGuid(), Brand = "Gildan", Model="G500", Size="5XL"},
                new Shirt {Id = Guid.NewGuid(), Brand = "Gildan", Model="G500VL", Size="Ladies V-Neck S"},
                new Shirt {Id = Guid.NewGuid(), Brand = "Gildan", Model="G500VL", Size="Ladies V-Neck M"},
                new Shirt {Id = Guid.NewGuid(), Brand = "Gildan", Model="G500VL", Size="Ladies V-Neck L"},
                new Shirt {Id = new Guid("FD2E5A43-2E42-4D3E-9B91-7CC01984EB42"), Brand = "Gildan", Model="G500VL", Size="Ladies V-Neck XL"},
                new Shirt {Id = Guid.NewGuid(), Brand = "Gildan", Model="G500VL", Size="Ladies V-Neck 2XL"},
                new Shirt {Id = Guid.NewGuid(), Brand = "Gildan", Model="G500VL", Size="Ladies V-Neck 3XL"},
                new Shirt {Id = Guid.NewGuid(), Brand = "Gildan", Model="G500L", Size="Ladies S"},
                new Shirt {Id = Guid.NewGuid(), Brand = "Gildan", Model="G500L", Size="Ladies M"},
                new Shirt {Id = Guid.NewGuid(), Brand = "Gildan", Model="G500L", Size="Ladies L"},
                new Shirt {Id = Guid.NewGuid(), Brand = "Gildan", Model="G500L", Size="Ladies XL"},
                new Shirt {Id = Guid.NewGuid(), Brand = "Gildan", Model="G500L", Size="Ladies 2XL"},
                new Shirt {Id = Guid.NewGuid(), Brand = "Gildan", Model="G500L", Size="Ladies 3XL"},
                new Shirt {Id = Guid.NewGuid(), Brand = "Gildan", Model="G500B", Size="Youth XS"},
                new Shirt {Id = Guid.NewGuid(), Brand = "Gildan", Model="G500B", Size="Youth S"},
                new Shirt {Id = Guid.NewGuid(), Brand = "Gildan", Model="G500B", Size="Youth M"},
                new Shirt {Id = Guid.NewGuid(), Brand = "Gildan", Model="G500B", Size="Youth L"},
                new Shirt {Id = Guid.NewGuid(), Brand = "Gildan", Model="G500B", Size="Youth XL"},
            };
            var addresses = new List<Address>
            {
                new Address {Id = new Guid("F11114D9-C125-426B-8D5D-A8F84A824404"), Alias = "Alias 1", CustomerGuid = new Guid(), Recipient = "Recipient 1", StreetAddress1 = "street address 1", CityStateZip = "csz 1" },
                new Address {Id = new Guid("9C4BBC9F-241F-4AE3-A48B-89E64C5B12A8"), Alias = expectedAddressAlias, CustomerGuid = new Guid(), Recipient = "Recipient 2", StreetAddress1 = "street address 2", CityStateZip = "csz 2" },
                new Address {Id = Guid.NewGuid(), Alias = "Alias 3", CustomerGuid = new Guid(), Recipient = "Recipient 3", StreetAddress1 = "street address 3", CityStateZip = "csz 3" },
                new Address {Id = Guid.NewGuid(), Alias = "Alias 4", CustomerGuid = new Guid(), Recipient = "Recipient 4", StreetAddress1 = "street address 4", CityStateZip = "csz 4" },
            };

            var orderItem = new OrderItem
            {
                Id = Guid.NewGuid(),
                AddressId = new Guid("9C4BBC9F-241F-4AE3-A48B-89E64C5B12A8"),
                CustomerId = new Guid(),
                DesignId = new Guid(),
                ShirtId = new Guid("5EDB1302-4DF1-4FB2-9C2D-143F99126549"),
                WhoFor = expectedWhoFor
            };


            var actual = ViewModelFactory.CreateOrderItemSummaryViewModel(orderItem, shirts, addresses);

            Assert.IsFalse(actual.Id == Guid.Empty);
            Assert.AreEqual(expectedWhoFor, actual.WhoFor);
            Assert.AreEqual(expectedSize, actual.Size);
            Assert.AreEqual(expectedAddressAlias, actual.AddressAlias);
        }

        [TestMethod]
        public void CreateOrderItemSummaryModelScenario2()
        {
            var expectedWhoFor = "Who For 2";
            var expectedSize = "M";
            var expectedAddressAlias = "Alias 1";
            var shirts = new List<Shirt>
            {
                new Shirt {Id = new Guid("5EDB1302-4DF1-4FB2-9C2D-143F99126549"), Brand = "Gildan", Model="G500", Size="S"},
                new Shirt {Id = new Guid("AEA43BBA-8E2E-422B-899A-FFFD527348E8"), Brand = "Gildan", Model="G500", Size=expectedSize},
                new Shirt {Id = Guid.NewGuid(), Brand = "Gildan", Model="G500", Size="L"},
                new Shirt {Id = Guid.NewGuid(), Brand = "Gildan", Model="G500", Size="XL"},
                new Shirt {Id = Guid.NewGuid(), Brand = "Gildan", Model="G500", Size="2XL"},
                new Shirt {Id = Guid.NewGuid(), Brand = "Gildan", Model="G500", Size="3XL"},
                new Shirt {Id = Guid.NewGuid(), Brand = "Gildan", Model="G500", Size="4XL"},
                new Shirt {Id = Guid.NewGuid(), Brand = "Gildan", Model="G500", Size="5XL"},
                new Shirt {Id = Guid.NewGuid(), Brand = "Gildan", Model="G500VL", Size="Ladies V-Neck S"},
                new Shirt {Id = Guid.NewGuid(), Brand = "Gildan", Model="G500VL", Size="Ladies V-Neck M"},
                new Shirt {Id = Guid.NewGuid(), Brand = "Gildan", Model="G500VL", Size="Ladies V-Neck L"},
                new Shirt {Id = new Guid("FD2E5A43-2E42-4D3E-9B91-7CC01984EB42"), Brand = "Gildan", Model="G500VL", Size="Ladies V-Neck XL"},
                new Shirt {Id = Guid.NewGuid(), Brand = "Gildan", Model="G500VL", Size="Ladies V-Neck 2XL"},
                new Shirt {Id = Guid.NewGuid(), Brand = "Gildan", Model="G500VL", Size="Ladies V-Neck 3XL"},
                new Shirt {Id = Guid.NewGuid(), Brand = "Gildan", Model="G500L", Size="Ladies S"},
                new Shirt {Id = Guid.NewGuid(), Brand = "Gildan", Model="G500L", Size="Ladies M"},
                new Shirt {Id = Guid.NewGuid(), Brand = "Gildan", Model="G500L", Size="Ladies L"},
                new Shirt {Id = Guid.NewGuid(), Brand = "Gildan", Model="G500L", Size="Ladies XL"},
                new Shirt {Id = Guid.NewGuid(), Brand = "Gildan", Model="G500L", Size="Ladies 2XL"},
                new Shirt {Id = Guid.NewGuid(), Brand = "Gildan", Model="G500L", Size="Ladies 3XL"},
                new Shirt {Id = Guid.NewGuid(), Brand = "Gildan", Model="G500B", Size="Youth XS"},
                new Shirt {Id = Guid.NewGuid(), Brand = "Gildan", Model="G500B", Size="Youth S"},
                new Shirt {Id = Guid.NewGuid(), Brand = "Gildan", Model="G500B", Size="Youth M"},
                new Shirt {Id = Guid.NewGuid(), Brand = "Gildan", Model="G500B", Size="Youth L"},
                new Shirt {Id = Guid.NewGuid(), Brand = "Gildan", Model="G500B", Size="Youth XL"},
            };
            var addresses = new List<Address>
            {
                new Address {Id = new Guid("F11114D9-C125-426B-8D5D-A8F84A824404"), Alias = expectedAddressAlias, CustomerGuid = new Guid(), Recipient = "Recipient 1", StreetAddress1 = "street address 1", CityStateZip = "csz 1" },
                new Address {Id = new Guid("9C4BBC9F-241F-4AE3-A48B-89E64C5B12A8"), Alias = "Alias 2", CustomerGuid = new Guid(), Recipient = "Recipient 2", StreetAddress1 = "street address 2", CityStateZip = "csz 2" },
                new Address {Id = Guid.NewGuid(), Alias = "Alias 3", CustomerGuid = new Guid(), Recipient = "Recipient 3", StreetAddress1 = "street address 3", CityStateZip = "csz 3" },
                new Address {Id = Guid.NewGuid(), Alias = "Alias 4", CustomerGuid = new Guid(), Recipient = "Recipient 4", StreetAddress1 = "street address 4", CityStateZip = "csz 4" },
            };

            var orderItem = new OrderItem 
            { 
                Id = Guid.NewGuid(), 
                AddressId = new Guid("F11114D9-C125-426B-8D5D-A8F84A824404"), 
                CustomerId = new Guid(), 
                DesignId = new Guid(), 
                ShirtId = new Guid("AEA43BBA-8E2E-422B-899A-FFFD527348E8"), 
                WhoFor = expectedWhoFor
            };


            var actual = ViewModelFactory.CreateOrderItemSummaryViewModel(orderItem, shirts, addresses);

            Assert.IsFalse(actual.Id == Guid.Empty);
            Assert.AreEqual(expectedWhoFor, actual.WhoFor);
            Assert.AreEqual(expectedSize, actual.Size);
            Assert.AreEqual(expectedAddressAlias, actual.AddressAlias);
        }

        [TestMethod]
        public void CreateOrderItemSummaryModelScenario3()
        {
            var expectedWhoFor = "Who For 3";
            var expectedSize = "Ladies V-Neck XL";
            var expectedAddressAlias = "Alias 2";
            var shirts = new List<Shirt>
            {
                new Shirt {Id = new Guid("5EDB1302-4DF1-4FB2-9C2D-143F99126549"), Brand = "Gildan", Model="G500", Size="S"},
                new Shirt {Id = new Guid("AEA43BBA-8E2E-422B-899A-FFFD527348E8"), Brand = "Gildan", Model="G500", Size="M"},
                new Shirt {Id = Guid.NewGuid(), Brand = "Gildan", Model="G500", Size="L"},
                new Shirt {Id = Guid.NewGuid(), Brand = "Gildan", Model="G500", Size="XL"},
                new Shirt {Id = Guid.NewGuid(), Brand = "Gildan", Model="G500", Size="2XL"},
                new Shirt {Id = Guid.NewGuid(), Brand = "Gildan", Model="G500", Size="3XL"},
                new Shirt {Id = Guid.NewGuid(), Brand = "Gildan", Model="G500", Size="4XL"},
                new Shirt {Id = Guid.NewGuid(), Brand = "Gildan", Model="G500", Size="5XL"},
                new Shirt {Id = Guid.NewGuid(), Brand = "Gildan", Model="G500VL", Size="Ladies V-Neck S"},
                new Shirt {Id = Guid.NewGuid(), Brand = "Gildan", Model="G500VL", Size="Ladies V-Neck M"},
                new Shirt {Id = Guid.NewGuid(), Brand = "Gildan", Model="G500VL", Size="Ladies V-Neck L"},
                new Shirt {Id = new Guid("FD2E5A43-2E42-4D3E-9B91-7CC01984EB42"), Brand = "Gildan", Model="G500VL", Size=expectedSize},
                new Shirt {Id = Guid.NewGuid(), Brand = "Gildan", Model="G500VL", Size="Ladies V-Neck 2XL"},
                new Shirt {Id = Guid.NewGuid(), Brand = "Gildan", Model="G500VL", Size="Ladies V-Neck 3XL"},
                new Shirt {Id = Guid.NewGuid(), Brand = "Gildan", Model="G500L", Size="Ladies S"},
                new Shirt {Id = Guid.NewGuid(), Brand = "Gildan", Model="G500L", Size="Ladies M"},
                new Shirt {Id = Guid.NewGuid(), Brand = "Gildan", Model="G500L", Size="Ladies L"},
                new Shirt {Id = Guid.NewGuid(), Brand = "Gildan", Model="G500L", Size="Ladies XL"},
                new Shirt {Id = Guid.NewGuid(), Brand = "Gildan", Model="G500L", Size="Ladies 2XL"},
                new Shirt {Id = Guid.NewGuid(), Brand = "Gildan", Model="G500L", Size="Ladies 3XL"},
                new Shirt {Id = Guid.NewGuid(), Brand = "Gildan", Model="G500B", Size="Youth XS"},
                new Shirt {Id = Guid.NewGuid(), Brand = "Gildan", Model="G500B", Size="Youth S"},
                new Shirt {Id = Guid.NewGuid(), Brand = "Gildan", Model="G500B", Size="Youth M"},
                new Shirt {Id = Guid.NewGuid(), Brand = "Gildan", Model="G500B", Size="Youth L"},
                new Shirt {Id = Guid.NewGuid(), Brand = "Gildan", Model="G500B", Size="Youth XL"},
            };
            var addresses = new List<Address>
            {
                new Address {Id = new Guid("F11114D9-C125-426B-8D5D-A8F84A824404"), Alias = "Alias 1", CustomerGuid = new Guid(), Recipient = "Recipient 1", StreetAddress1 = "street address 1", CityStateZip = "csz 1" },
                new Address {Id = new Guid("9C4BBC9F-241F-4AE3-A48B-89E64C5B12A8"), Alias = expectedAddressAlias, CustomerGuid = new Guid(), Recipient = "Recipient 2", StreetAddress1 = "street address 2", CityStateZip = "csz 2" },
                new Address {Id = Guid.NewGuid(), Alias = "Alias 3", CustomerGuid = new Guid(), Recipient = "Recipient 3", StreetAddress1 = "street address 3", CityStateZip = "csz 3" },
                new Address {Id = Guid.NewGuid(), Alias = "Alias 4", CustomerGuid = new Guid(), Recipient = "Recipient 4", StreetAddress1 = "street address 4", CityStateZip = "csz 4" },
            };

            var orderItem = new OrderItem 
            {
                Id = Guid.NewGuid(), 
                AddressId = new Guid("9C4BBC9F-241F-4AE3-A48B-89E64C5B12A8"), 
                CustomerId = new Guid(), 
                DesignId = new Guid(), 
                ShirtId = new Guid("FD2E5A43-2E42-4D3E-9B91-7CC01984EB42"), 
                WhoFor = expectedWhoFor 
            };


            var actual = ViewModelFactory.CreateOrderItemSummaryViewModel(orderItem, shirts, addresses);

            Assert.IsFalse(actual.Id == Guid.Empty);
            Assert.AreEqual(expectedWhoFor, actual.WhoFor);
            Assert.AreEqual(expectedSize, actual.Size);
            Assert.AreEqual(expectedAddressAlias, actual.AddressAlias);
        }

        [TestMethod]
        public void CreateUpcomingnModel()
        {
            var imageId = Guid.NewGuid();
            var bytes = Encoding.UTF8.GetBytes("Bytes");
            var expectedImageSource = $"data:image/jpeg;base64,{Convert.ToBase64String(bytes)}";
            var expectedDesignId = new Guid();
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
                Id = expectedDesignId,
                Description = expDescription,
                DisplayOnFrontPage = displayOnFrontPage,
                Title = expTitle,
                ImageId = imageId,
                ReleaseDate = releaseDate,
            };

            var actual = ViewModelFactory.CreateProductVM(design, image);

            Assert.AreEqual(expectedDesignId, actual.DesignId);
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
