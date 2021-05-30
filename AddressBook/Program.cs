using System;
using System.Collections.Generic;


namespace AddressBook
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int option;
            string bookName ;
            AddressBookBuider addressBook = new AddressBookBuider();
            do
            {
                Console.WriteLine("Enter your option :");
                Console.WriteLine("1. Add new contact ");
                Console.WriteLine("2. Display the contacts");
                Console.WriteLine("3. Edit  contacts");
                Console.WriteLine("4. Delete  contacts");
                Console.WriteLine("5. Search a person in a city or state");
                option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                            Console.WriteLine("Enter a  name for your Addressbook:");
                            bookName = Console.ReadLine();
                            Console.WriteLine("Enter First Name :");
                            string firstName = Console.ReadLine();
                            if (addressBook.CheckFor_Duplicate(firstName) == "true")
                            break;
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
                            addressBook.AddContact(firstName, lastName, address, city, state, email, zip, phoneNumber, bookName);
                            break;
                    case 2:
                            addressBook.DisplayContact();
                            break;
                    case 3:
                        Console.WriteLine("Enter first Name of contact which to be edited");
                        string NameToEdit = Console.ReadLine();
                            addressBook.EditContact(NameToEdit);
                            break;

                    case 4:
                        Console.WriteLine("Enter first Name of contact which to be deleted");
                        string NameToDelete = Console.ReadLine();
                        addressBook.DeleteContact(NameToDelete);
                        break;

                   
                    case 5:Console.WriteLine("Enter city or state name");
                            string input = Console.ReadLine();
                            addressBook.SearchPersonByCity(input);
                        break;
                   
                    default: Console.WriteLine("wrong input");
                            break;
                }
                Console.WriteLine("Do you want to continue to The Main Menu?  press 1 if yes,press 0 for Exit");
                option = Convert.ToInt32(Console.ReadLine());
            }
            while (option != 0);
        }
    }
}

