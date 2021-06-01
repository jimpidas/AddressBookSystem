using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AddressBook
{
    class ReadWriteJson
    {

        string filePath = @"C:\Users\Dell\DotNetProjects\AddressBook\AddressBook\AddressRecord.json";
        public void WriteToFile(Dictionary<string, AddressBookBuider> addressBookDictionary)
        {
            foreach (AddressBookBuider obj in addressBookDictionary.Values)
            {
                foreach (Contacts contact in obj.addressBook.Values)
                {
                  string  json = JsonConvert.SerializeObject(contact);
                    File.WriteAllText(filePath, json);
                }
            }
            Console.WriteLine("\nSuccessfully added to JSON file.");
        }
        public void ReadFromFile()
        {
            Contacts contact = JsonConvert.DeserializeObject<Contacts>(File.ReadAllText(filePath));
            Console.WriteLine(contact.ToString());
        }
    }
}
