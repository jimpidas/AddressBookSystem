using AddressBookSystem_ADO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AddressBookTest_Ado.Net_day27
{
    [TestClass]
    public class UnitTest1
    {
        
       
            [TestMethod]
            public void GivenQuery_WhenRetrieve_ShouldReturnNumberOfRowsRetrieved()
            {
                int expectedResult = 4;
                AddressBookDatabase database = new AddressBookDatabase();
                int result = database.GetPersonDetailsfromDatabase();
                Assert.AreEqual(expectedResult, result);
            }

            
            
            [TestMethod]
            public void GivenQuery_whenUpdate_ShouldUpdateContactInDB()
            {
                bool expectedResult = true;
                AddressBookDatabase database = new AddressBookDatabase();
                AddressBookModel model = new AddressBookModel()
                {
                firstname = "Niku",
                lastname = "Rajkonwar",
                phone = "9866345545",
                email = "motule@gmail.com",
                zip = 1,
                };
                bool result = database.UpdateContact(model);
                Assert.AreEqual(expectedResult, result);
            }


        [TestMethod]
        public void GivenDate_ShouldReturnRecordsInAParticularPeriod()
        {
            bool expectedResult = true;
            AddressBookDatabase database = new AddressBookDatabase();
            bool result = database.RetriveContactInParticularPeriod();
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void GivenQuery_WhenRetrieveByCityOrState_ShouldRetrievContactAndReturnNoOfCounts()
        {
            int expectedResult = 3;
            AddressBookDatabase database = new AddressBookDatabase();
            AddressBookModel model = new AddressBookModel()
            {
                state = "Assam"
            };
            int result = database.RetriveContactByCityOrState(model);
            Assert.AreEqual(expectedResult, result);
        }
        [TestMethod]
        public void GivenQuery_WhenInsert_ShouldAddNewContactToDB()
        {
            bool expectedResult = true;
            AddressBookDatabase database = new AddressBookDatabase();
            AddressBookModel model = new AddressBookModel()
            {
                firstname = "Snehal",
                lastname = "Chaudhari",
                phone = "8666345545",
                email = "shenal234@gmail.com",
                city = "Dibrugarh",
                book_id = 1,
                person_id=6,
                zip=3,
                date_added = new DateTime(2018, 12, 22)
            };
            bool result = database.AddNewContact(model);
            Assert.AreEqual(expectedResult, result);
        }
    }
}
