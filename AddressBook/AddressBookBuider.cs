using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AddressBook
{

    class AddressBookBuider : IContacts
    {
        private Dictionary<string, Contacts> addressBook = new Dictionary<string, Contacts>();
        private Dictionary<string, AddressBookBuider> addressBookDictionary = new Dictionary<string, AddressBookBuider>();
        private Dictionary<Contacts, string> cityDictionary = new Dictionary<Contacts, string>();
        private Dictionary<Contacts, string> stateDictionary = new Dictionary<Contacts, string>();

        public void AddContact(string firstName, string lastName, string address, string city, string state, string email, int zip, long phoneNumber, string bookName)
        {
            Contacts contact = new Contacts(firstName, lastName, address, city, state, email, zip, phoneNumber);
            addressBookDictionary[bookName].addressBook.Add(contact.FirstName + " " + contact.LastName, contact);
            Console.WriteLine("\nAdded Succesfully. \n");
        }
        public void DisplayContact(string bookName)
        {
            Console.WriteLine($"You are working on {bookName} addressbook",bookName);
            foreach (KeyValuePair<string, Contacts> item in addressBookDictionary[bookName].addressBook)
            {
                    Console.WriteLine("First Name : " + item.Value.FirstName);
                    Console.WriteLine("Last Name : " + item.Value.LastName);
                    Console.WriteLine("Address : " + item.Value.Address);
                    Console.WriteLine("City : " + item.Value.City);
                    Console.WriteLine("State : " + item.Value.State);
                    Console.WriteLine("Email : " + item.Value.Email);
                    Console.WriteLine("Zip : " + item.Value.Zip);
                    Console.WriteLine("Phone Number : " + item.Value.PhoneNumber + "\n"); 
            }
        }
        public void EditContact(string name,string bookName)
        {
            bool flag = false;
            foreach (KeyValuePair<string, Contacts> item in addressBookDictionary[bookName].addressBook)
            {
                if (item.Key.Equals(name))
                {
                    flag = true;
                    Console.WriteLine("Enter your choich \n1.First Name \n2.Last Name \n3.Address \n4.City \n5.State \n6.Email \n7.Zip \n8.Phone Number");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Enter New First Name :");
                            item.Value.FirstName = Console.ReadLine();
                            break;
                        case 2:
                            Console.WriteLine("Enter New Last Name :");
                            item.Value.LastName = Console.ReadLine();
                            break;
                        case 3:
                            Console.WriteLine("Enter New Address :");
                            item.Value.Address = Console.ReadLine();
                            break;
                        case 4:
                            Console.WriteLine("Enter New City :");
                            item.Value.City = Console.ReadLine();
                            break;
                        case 5:
                            Console.WriteLine("Enter New State :");
                            item.Value.State = Console.ReadLine();
                            break;
                        case 6:
                            Console.WriteLine("Enter New Email :");
                            item.Value.Email = Console.ReadLine();
                            break;
                        case 7:
                            Console.WriteLine("Enter New Zip :");
                            item.Value.Zip = Convert.ToInt32(Console.ReadLine());
                            break;
                        case 8:
                            Console.WriteLine("Enter New Phone Number :");
                            item.Value.PhoneNumber = Convert.ToInt64(Console.ReadLine());
                            break;
                    }
                }

            }
            if (flag == false)
                Console.WriteLine("not exits");
        }
        public void DeleteContact(string name, string bookName)
        {
            if (addressBookDictionary[bookName].addressBook.ContainsKey(name))
            {
                addressBookDictionary[bookName].addressBook.Remove(name);
                Console.WriteLine("\nDeleted Succesfully.\n");
            }
            else
            {
                Console.WriteLine("\nNot Found, Try Again.\n");
            }
        }
        public void AddAddressBook(string bookName)
        {
            AddressBookBuider addressBook = new AddressBookBuider();
            addressBookDictionary.Add(bookName, addressBook);
            Console.WriteLine("AddressBook Created.");
        }
        public Dictionary<string, AddressBookBuider> GetAddressBook()
        {
            return addressBookDictionary;
        }
        public bool CheckFor_Duplicate(Contacts c, string bookName)
        {

            List<Contacts> book = GetListOfDictionaryValues(bookName);
            if (book.Any(b => b.Equals(c)))
            {
                Console.WriteLine("Name already Exists.");
                return true;
            }
            return false; 
        }
        public void SearchPersonByCity(string city)
        {
            foreach (AddressBookBuider addressbookobj in addressBookDictionary.Values)
            {
                CreateCityDictionary();
                List<Contacts> contactList = GetListOfDictionaryKeys(addressbookobj.cityDictionary);
                foreach (Contacts contact in contactList.FindAll(c => c.City.Equals(city)).ToList())
                {
                    Console.WriteLine(contact.ToString());
                }
            }
        }
        public void SearchPersonByState(string state)
        {
            foreach (AddressBookBuider addressbookobj in addressBookDictionary.Values)
            {
                CreateStateDictionary();
                List<Contacts> contactList = GetListOfDictionaryKeys(addressbookobj.stateDictionary);
                foreach (Contacts contact in contactList.FindAll(c => c.State.Equals(state)).ToList())
                {
                    Console.WriteLine(contact.ToString());
                }
            }
        }
        public void CreateCityDictionary()
        {
            foreach (AddressBookBuider addressBookObj in addressBookDictionary.Values)
            {
                foreach (Contacts contact in addressBookObj.addressBook.Values)
                {
                    addressBookObj.cityDictionary.TryAdd(contact, contact.City);
                }
            }
        }
        public void CreateStateDictionary()
        {
            foreach (AddressBookBuider addressBookObj in addressBookDictionary.Values)
            {
                foreach (Contacts contact in addressBookObj.addressBook.Values)
                {
                    addressBookObj.stateDictionary.TryAdd(contact, contact.State);
                }
            }
        }
       
        public List<Contacts> GetListOfDictionaryValues(string bookName)
        {
            List<Contacts> book = new List<Contacts>();
            foreach (var value in addressBookDictionary[bookName].addressBook.Values)
            {
                book.Add(value);
            }
            return book;
        }
        public List<Contacts> GetListOfDictionaryKeys(Dictionary<Contacts, string> d)
        {
            List<Contacts> book = new List<Contacts>();
            foreach (var value in d.Keys)
            {
                book.Add(value);
            }
            return book;
        }
    }
}

