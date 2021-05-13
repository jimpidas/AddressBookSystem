using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook
{
    class Contacts
    {
        static string firstName, lastName, address, city, state, email;
        static int pinCode, phoneNo;



        public void addContact()
        {
            Console.WriteLine("Add first name :");
            firstName = Console.ReadLine();
            Console.WriteLine("Add last name :");
            lastName = Console.ReadLine();
            Console.WriteLine("Add address :");
            address = Console.ReadLine();
            Console.WriteLine("Add city :");
            city = Console.ReadLine();
            Console.WriteLine("Add state :");
            state = Console.ReadLine();
            Console.WriteLine("Add email :");
            email = Console.ReadLine();
            Console.WriteLine("Add zipcode :");
            pinCode = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Add phoneno :");
            phoneNo = Convert.ToInt32(Console.ReadLine());


            Console.WriteLine("Name : " + firstName + "" + lastName + "\n Address: " + address + "\n city :" + city + "\n state : " + state + "\n Zipcode: " + pinCode + "\n phone number :" + phoneNo);

        }
    }
}