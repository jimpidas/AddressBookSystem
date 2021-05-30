using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AddressBook
{

    class AddressBookBuider : IContacts
    {
        readonly List<Contacts> list = new List<Contacts>();
        private readonly Dictionary<string, Contacts> dictionary = new Dictionary<string, Contacts>();

        public void AddContact(string firstName, string lastName, string address, string city, string state, string email, int zip, long phoneNumber, string bookName)
        {
            Contacts contact = new Contacts();
            contact.FirstName = firstName;
            contact.LastName = lastName;
            contact.Address = address;
            contact.City = city;
            contact.State = state;
            contact.Email = email;
            contact.Zip = zip;
            contact.PhoneNumber = phoneNumber;
            list.Add(contact);
            dictionary.Add(bookName, contact);
        }
        public void DisplayContact()
        {

            if (list.Count > 0)
            {

                foreach (var contactlist in dictionary)
                {
                    Console.WriteLine("First Name : " + contactlist.Value.FirstName);
                    Console.WriteLine("Last Name : " + contactlist.Value.LastName);
                    Console.WriteLine("Address : " + contactlist.Value.Address);
                    Console.WriteLine("City : " + contactlist.Value.City);
                    Console.WriteLine("State : " + contactlist.Value.State);
                    Console.WriteLine("Email : " + contactlist.Value.Email);
                    Console.WriteLine("Zip : " + contactlist.Value.Zip);
                    Console.WriteLine("Phone Number : " + contactlist.Value.PhoneNumber + "\n");
                }
            }
            else
                Console.WriteLine("list  is empty");
        }
        public void EditContact(string name)
        {
            bool flag = false;
            foreach (var contactlist in list)
            {
                if (contactlist.FirstName == name)
                {
                    flag = true;
                    Console.WriteLine("Enter your choich \n1.First Name \n2.Last Name \n3.Address \n4.City \n5.State \n6.Email \n7.Zip \n8.Phone Number");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Enter New First Name :");
                            contactlist.FirstName = Console.ReadLine();
                            break;
                        case 2:
                            Console.WriteLine("Enter New Last Name :");
                            contactlist.LastName = Console.ReadLine();
                            break;
                        case 3:
                            Console.WriteLine("Enter New Address :");
                            contactlist.Address = Console.ReadLine();
                            break;
                        case 4:
                            Console.WriteLine("Enter New City :");
                            contactlist.City = Console.ReadLine();
                            break;
                        case 5:
                            Console.WriteLine("Enter New State :");
                            contactlist.State = Console.ReadLine();
                            break;
                        case 6:
                            Console.WriteLine("Enter New Email :");
                            contactlist.Email = Console.ReadLine();
                            break;
                        case 7:
                            Console.WriteLine("Enter New Zip :");
                            contactlist.Zip = Convert.ToInt32(Console.ReadLine());
                            break;
                        case 8:
                            Console.WriteLine("Enter New Phone Number :");
                            contactlist.PhoneNumber = Convert.ToInt64(Console.ReadLine());
                            break;
                    }
                }

            }
            if (flag == false)
                Console.WriteLine("not exits");
        }
        public void DeleteContact(string deletename)
        {

            if (list.Count > 0)
            {
                foreach (var contact in list)
                {
                    if (contact.FirstName == deletename)
                    {
                        list.Remove(contact);
                        Console.WriteLine("deleted successfully");
                        break;
                    }

                }
                Console.WriteLine("not exists");
            }
            else
                Console.WriteLine("list is empty,cannot delete");
        }
        public string CheckFor_Duplicate(string name)
        {

            foreach (var contact in dictionary)
            {
                if (dictionary.Values.Any(e => e.FirstName == name))
                {

                    Console.WriteLine("Sorry! Duplicate entry not allowed.");
                    return "true";
                }
            }
            return "flag";
        }
        public void SearchPersonByCity(string cityOrstate)
        {
            foreach (var element in dictionary)
            {
                if (element.Value.City.Equals(cityOrstate))
                {
                    Console.WriteLine("firstname " + element.Value.FirstName + ":City " + element.Value.City);
                }
                else if (element.Value.State.Equals(cityOrstate))
                {
                    Console.WriteLine(" Firstname" + element.Value.FirstName + ":State " + element.Value.State);
                }
                else
                {
                    Console.WriteLine("No such City or State stored in your addressbook.\nAvailable city and states are ::\n Cites:: " + element.Value.City + "\nStates:: " + element.Value.State);
                }
            }
        }
    }
}

