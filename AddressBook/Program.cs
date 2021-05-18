using System;
using System.Collections.Generic;


namespace AddressBook
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int option, option1;
            string bookName = "default";
            AddressBookBuider addressBook = new AddressBookBuider();

            Console.WriteLine("1. Would you like to work on existing addressbook ? if yes press 1");
            Console.WriteLine("2. Would you like to add  new addressbook ? if yes press 2");
            option1 = Convert.ToInt32(Console.ReadLine());
            switch (option1)
            {
                case 1:
                    addressBook.AddAddressBook(bookName);
                    break;
                case 2:
                    Console.WriteLine("Enter Name Of New Addressbook You want to create : ");
                    bookName = Console.ReadLine();
                    addressBook.AddAddressBook(bookName);
                    break;
            }


            do
            {
                Console.WriteLine($"you are working on {bookName} addressbook ");
                Console.WriteLine("Enter your option :");
                Console.WriteLine("1. Add new contact ");
                Console.WriteLine("2. Display the contacts");
                Console.WriteLine("3. Edit  contacts");
                Console.WriteLine("4. Delete  contacts");
                Console.WriteLine("5. Add new addressbook");
                Console.WriteLine("6. Switch Addressbook");
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

                    case 4:
                        Console.WriteLine("Enter first Name of contact which to be deleted");
                        string NameToDelete = Console.ReadLine();
                        addressBook.DeleteContact(NameToDelete);
                        break;

                    case 5:
                        Console.WriteLine("Enter Name For New AddressBook");
                        string newAddressBook = Console.ReadLine();
                        addressBook.AddAddressBook(newAddressBook);
                        Console.WriteLine("Would you like to Switch to " + newAddressBook);
                        Console.WriteLine("1.Yes \n2.No");
                        int c = Convert.ToInt32(Console.ReadLine());
                        if (c == 1)
                        {
                            bookName = newAddressBook;
                        }
                        break;
                    case 6:
                        Console.WriteLine("Enter Name Of AddressBook From Below List");
                        foreach (KeyValuePair<string, AddressBookBuider> item in addressBook.GetAddressBook())
                        {
                            Console.WriteLine(item.Key);
                        }
                        while (true)
                        {
                            bookName = Console.ReadLine();
                            if (addressBook.GetAddressBook().ContainsKey(bookName))
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("No such AddressBook found. Try Again.");
                            }
                        }
                        break;
                    default:
                        Console.WriteLine("wrong input");
                        break;
                }
                Console.WriteLine("Do you want to continue?  press 1 if yes,press 0 for Exit");
                option = Convert.ToInt32(Console.ReadLine());
            }
            while (option != 0);
        }
    }
}

