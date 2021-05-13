using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook
{
     class AddressBookBuider : IContacts
     {
        
 

            private LinkedList<Contacts> list = new LinkedList<Contacts>();
            public void AddContact(string firstName, string lastName, string address, string city, string state, string email, int zip, long phoneNumber)
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
            list.AddLast(contact);
            }
            public void DisplayContact()
            {
            
                if (list.Count > 0)
                {

                    foreach (var contactlist in list)
                    {
                        Console.WriteLine("First Name : " + contactlist.FirstName);
                        Console.WriteLine("Last Name : " + contactlist.LastName);
                        Console.WriteLine("Address : " + contactlist.Address);
                        Console.WriteLine("City : " + contactlist.City);
                        Console.WriteLine("State : " + contactlist.State);
                        Console.WriteLine("Email : " + contactlist.Email);
                        Console.WriteLine("Zip : " + contactlist.Zip);
                        Console.WriteLine("Phone Number : " + contactlist.PhoneNumber + "\n");
                    }
                }
                else
                        Console.WriteLine("list  is empty");
            }
     }
}

