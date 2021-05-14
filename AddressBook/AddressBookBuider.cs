using System;
using System.Collections.Generic;
using System.Linq;
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

        public void EditContact(string name)
        {
            bool flag = false;
            foreach (var contactlist in list)
            {
                if (contactlist.FirstName==name)
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
            if(flag==false)
            Console.WriteLine("not exits");
        }

    }
}


