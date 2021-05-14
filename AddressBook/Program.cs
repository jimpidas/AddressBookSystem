using System;
using System.Collections.Generic;


namespace AddressBook
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int option;
            AddressBookBuider addressBook = new AddressBookBuider();
            do
            {
                
                Console.WriteLine("Enter your option :");
                Console.WriteLine("1. Add new contact ");
                Console.WriteLine("2. Display the contacts");
                Console.WriteLine("3. Edit the contacts");
                option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                            Console.WriteLine("Enter First Name :");
                            string firstName = Console.ReadLine();
                            Console.WriteLine("Enter Last Name :");
                            string lastName = Console.ReadLine();
                            Console.WriteLine("Enter Address :");
                            string address = Console.ReadLine();
                            Console.WriteLine("Enter City :");
                            string city = Console.ReadLine();
                            Console.WriteLine("Enter State :");
                            string state = Console.ReadLine();
                            Console.WriteLine("Enter Email :");
                            string email = Console.ReadLine();
                            Console.WriteLine("Enter Zip :");
                            int zip = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter Phone Number :");
                            long phoneNumber = Convert.ToInt64(Console.ReadLine());
                            addressBook.AddContact(firstName, lastName, address, city, state, email, zip, phoneNumber);
                            break;
                    case 2:
                            addressBook.DisplayContact();
                            break;
                    case 3:
                        Console.WriteLine("Enter first Name of contact which to be edited");
                        string NameToEdit = Console.ReadLine();
                            addressBook.EditContact(NameToEdit);
                            break;
                    default:
                            Console.WriteLine("Wrong input");
                            break;
                }
                Console.WriteLine("Do you want to continue?  press 1 if yes,press 0 for Exit");
                option = Convert.ToInt32(Console.ReadLine());
            }
            while (option != 0);
        }
    }
}

