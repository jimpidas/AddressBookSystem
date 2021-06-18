using AddressBook;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Collections.Generic;

namespace RestSharpAndJsonServer
{
    [TestClass]
    public class RestSharpTestCase
    {
        RestClient client;

        [TestInitialize]
        public void Setup()
        {
            client = new RestClient("http://localhost:3000");
        }

        private IRestResponse getEmployeeList()
        {
            RestRequest request = new RestRequest("/Contacts", Method.GET);

            //act

            IRestResponse response = client.Execute(request);
            return response;
        }

        [TestMethod]
        public void onCallingGETApi_ReturnEmployeeList()
        {
            IRestResponse response = getEmployeeList();

            //assert
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
            List<Contacts> dataResponse = JsonConvert.DeserializeObject<List<Contacts>>(response.Content);
            Assert.AreEqual(1, dataResponse.Count);
            foreach (var item in dataResponse)
            {
                System.Console.WriteLine("FirstName: " + item.FirstName + "Lastname: " + item.LastName + "Address: " + item.Address+
                                        "City: "+item.City+"State:"+item.State+"Zip:"+item.Zip+"Email:"+item.Email+"Phone:"+item.PhoneNumber);
            }
        }


        [TestMethod]
        public void givenEmployee_OnPost_ShouldReturnAddedEmployee()
        {
            RestRequest request = new RestRequest("/Contacts", Method.POST);
            JObject jObjectbody = new JObject();
            
            jObjectbody.Add("FirstName", "Clark");
            jObjectbody.Add("LastName", "Rt");
            jObjectbody.Add("Address", "Street 3");
            jObjectbody.Add("City", "Dib");
            jObjectbody.Add("State", "Assam");
            jObjectbody.Add("Email", "wer@gmail.com");
            jObjectbody.Add("PhoneNumber", "8975345678");
           
            request.AddParameter("application/json", jObjectbody, ParameterType.RequestBody);

            //act
            IRestResponse response = client.Execute(request);
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.Created);
            Contacts dataResponse = JsonConvert.DeserializeObject<Contacts>(response.Content);
            Assert.AreEqual("Clark", dataResponse.FirstName);  

        }


        [TestMethod]
        public void givenEmployeeSalary_OnUpdate_ShouldReturnAddedEmployee()
        {
            RestRequest request = new RestRequest("/Contacts/1", Method.PUT);
            JObject jObjectbody = new JObject();

            jObjectbody.Add("FirstName", "Pinki");
            
            request.AddParameter("application/json", jObjectbody, ParameterType.RequestBody);

            //act
            var response = client.Execute(request);
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
            Contacts dataResponse = JsonConvert.DeserializeObject<Contacts>(response.Content);
            Assert.AreEqual("Pinki", dataResponse.FirstName);
           

        }
        [TestMethod]
        public void givenEmployeeID_SholudDeleteEmployee()
        {
            RestRequest request = new RestRequest("/Contacts/2", Method.DELETE);
            IRestResponse response = client.Execute(request);
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);

        }
    }
}
