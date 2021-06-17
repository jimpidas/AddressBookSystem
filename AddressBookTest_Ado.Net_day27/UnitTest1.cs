using AddressBookSystem_ADO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

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
            
            AddressBookDatabase database = new AddressBookDatabase();
            List<AddressBookDetail> model = new List<AddressBookDetail>();
            
            model.Add(new AddressBookDetail(firstname: "Snehal", lastname: "Chaudhari", phone: "8624345545", email: "shenal234@gmail.com", city: "Dibrugarh", book_id: 2, person_id: 6, zip: 3, date_added: new DateTime(2019,04, 09)));
            model.Add(new AddressBookDetail(firstname: "Rashmi", lastname: "DAs", phone: "8890345545", email: "rashmi@gmail.com", city: "Tsk", book_id: 1, person_id: 7, zip: 3, date_added: new DateTime(2020, 02, 09)));
            model.Add(new AddressBookDetail(firstname: "Rakesh", lastname: "sharma", phone: "8452245545", email: "raksesh@gmail.com", city: "Jorhat", book_id: 2, person_id: 8, zip: 3, date_added: new DateTime(2017, 06, 09)));
            model.Add(new AddressBookDetail(firstname: "Bindu", lastname: "pujari", phone: "899945545", email: "bindu@gmail.com", city: "Sibsagor", book_id: 1, person_id: 9, zip: 3, date_added: new DateTime(2016, 07, 09)));
            model.Add(new AddressBookDetail(firstname: "Moni", lastname: "Brende", phone: "864533545", email: "moni@gmail.com", city: "Ghy", book_id: 2, person_id: 10, zip: 3, date_added: new DateTime(2018, 08, 09)));
            
            
           // Assert.AreEqual(result,true);
            
            DateTime startDateTime = DateTime.Now;
            database.AddNewContactWithoutThread(model);
            DateTime stopDateTime = DateTime.Now;
            Console.WriteLine("Duration without thread: " + (stopDateTime - startDateTime));


            DateTime startDateTimeThread = DateTime.Now;
            database.AddNewContactWithThread(model);
            DateTime stopDateTimeThread = DateTime.Now;
            Console.WriteLine("Duration with thread: " + (stopDateTimeThread - startDateTimeThread));            
           //Assert.AreEqual(result, 5);
        }
    }
}
