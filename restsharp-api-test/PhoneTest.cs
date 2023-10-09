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
            Phone phone = DataHelper.getPhoneData();
            APIHelper objectsApiHelper = new APIHelper();
            Phone createdPhone = objectsApiHelper.createPhone(phone);
            Phone phonecreated = objectsApiHelper.getPhoneById(createdPhone.Id);
            Assert.Equal(createdPhone.Id, phonecreated.Id);
        }

        [Fact]
        public void testCreateObjects()
        {
            Phone phone = DataHelper.getPhoneData();
            APIHelper objectsApiHelper = new APIHelper();
            Phone createdPhone = objectsApiHelper.createPhone(phone);
            Assert.Equal(phone.Name, createdPhone.Name);
            Assert.Equal(phone.Data.Year, createdPhone.Data.Year);
            Assert.Equal(phone.Data.Price, createdPhone.Data.Price);
            Assert.Equal(phone.Data.CpuModel, createdPhone.Data.CpuModel);
            Assert.Equal(phone.Data.HardDiskSize, createdPhone.Data.HardDiskSize);
        }

        [Fact]
        public void testUpdateObject()
        {
            Phone phone = DataHelper.getPhoneData();
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
            Phone phone = DataHelper.getPhoneData();
            APIHelper objectsApiHelper = new APIHelper();
            Phone createdPhone = objectsApiHelper.createPhone(phone);
            DeletedMsg deletedMsg = objectsApiHelper.deletePhone(createdPhone.Id);
            var expectedMsg = "Object with id = " + createdPhone.Id + " has been deleted.";
            Assert.Equal(expectedMsg, deletedMsg.Message);
        }

        [Fact]
        public void testPatchUpdateObject()
        {
            Phone phone = DataHelper.getPhoneData();
            APIHelper objectsApiHelper = new APIHelper();
            Phone createdPhone = objectsApiHelper.createPhone(phone);
            var body = $$"""
                    {
                        "name": "Apple MacBook Pro 16 (Updated Name)"
                    }
                    """;
            Phone updatedPhone = objectsApiHelper.patchUpdatePhone(body,createdPhone.Id);
            Assert.Equal("Apple MacBook Pro 16 (Updated Name)", updatedPhone.Name);
        }
    }
} 