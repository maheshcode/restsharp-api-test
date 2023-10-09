using RestSharp;
using restsharp_api_test.model;

namespace restsharp_api_test
{
    public class PhoneTest
    {
        [Fact]
         public void testListOfAllObjects()
            {
                APIHelper objectsApiHelper = new APIHelper();
                ICollection<Phone> phoneList = objectsApiHelper.getPhoneList();
                Assert.NotNull(phoneList);
            }

        [Fact]
        public void testSingleObjects()
            {
                APIHelper objectsApiHelper = new APIHelper();
                Phone phone = objectsApiHelper.getPhoneById("7");
                Assert.Equal("7",phone.Id);
            }

        [Fact]
        public void testCreateObjects()
            {
                Phone phone = new Phone();
                phone.Name = "Apple 26";
                Data data = new Data();
                data.Year = 2023;
                data.Price = 100;
                data.CpuModel = "Intel Core 9";
                data.HardDiskSize = "1 TB";
                phone.Data = data;
                APIHelper objectsApiHelper = new APIHelper();
                Phone createdPhone = objectsApiHelper.createPhone(phone);
                Assert.Equal(phone.Name, createdPhone.Name);
        }

        [Fact]
        public void testUpdateObject()
            {
                Phone phone = new Phone();
                phone.Name = "Apple 26";
                Data data = new Data();
                data.Year = 2023;
                data.Price = 100;
                data.CpuModel = "Intel Core 9";
                data.HardDiskSize = "1 TB";
                phone.Data = data;
                APIHelper objectsApiHelper = new APIHelper();
                Phone createdPhone = objectsApiHelper.createPhone(phone);
                var newName = "Apple New";
                var newPrice = 200;
                createdPhone.Name = newName;
                createdPhone.Data.Price = newPrice;
                Phone updatedPhone = objectsApiHelper.updatePhone(createdPhone);
                Assert.Equal(newName, updatedPhone.Name);
                Assert.Equal(newPrice, updatedPhone.Data.Price);
            }

        [Fact]
        public void testDeleteObject()
            {
                Phone phone = new Phone();
                phone.Name = "Apple 26";
                Data data = new Data();
                data.Year = 2023;
                data.Price = 100;
                data.CpuModel = "Intel Core 9";
                data.HardDiskSize = "1 TB";
                phone.Data = data;
                APIHelper objectsApiHelper = new APIHelper();
                Phone createdPhone = objectsApiHelper.createPhone(phone);
                DeletedMsg deletedMsg = objectsApiHelper.deletePhone(createdPhone.Id);
                var expectedMsg = "Object with id = " + createdPhone.Id + " has been deleted.";
                Assert.Equal(expectedMsg, deletedMsg.Message);
            }
    }
} 