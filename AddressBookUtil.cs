using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;


namespace OopsPgm
{
    class AddressBookUtil
    {
        public void AddPerson()
        {
            Constant constants = new Constant();
            IList<AddressBookModel> addressBook = new List<AddressBookModel>();
            Console.WriteLine("enter first name");
            string firstname = Console.ReadLine();
            Console.WriteLine("enter last name");
            string lastname = Console.ReadLine();
            Console.WriteLine("enter address");
            string address = Console.ReadLine();
            Console.WriteLine("enter city");
            string city = Console.ReadLine();
            Console.WriteLine("enter state");
            string state = Console.ReadLine();
            Console.WriteLine("enter zip");
            string zip = Console.ReadLine();
            Console.WriteLine("enter phone number");
            string phoneNumber = Console.ReadLine();
            if (Regex.IsMatch(phoneNumber, @"[0-9]{10}") && Regex.IsMatch(zip, @"[0-9]{6}") && Regex.IsMatch(firstname, @"[a-zA-Z]") && Regex.IsMatch(lastname, @"[a-zA-Z]") && Regex.IsMatch(city, @"[a-zA-Z]") && Regex.IsMatch(state, @"[a-zA-Z]"))
            {
                AddressBookModel addressBookModel = new AddressBookModel()
                {
                    FirstName = firstname,
                    LastName = lastname,
                    Address = address,
                    City = city,
                    State = state,
                    ZipCode = zip,
                    PhoneNuumber = phoneNumber
                };
                var convertedJson = JsonConvert.SerializeObject(addressBookModel);
                File.WriteAllText(constants.AddressBook, convertedJson);
                Console.WriteLine("new person added");
            }
            else
            {
                Console.WriteLine("enter proper details");
            }
        }
        public static string ReadFile(string fileName)
        {
            using (StreamReader streamReader = new StreamReader(fileName))
            {
                string json = streamReader.ReadToEnd();
                streamReader.Close();
                return json;
            }
        }

        public void Update()
        {
            Console.WriteLine("ENTER THE MOBILE NUM");
            string num = Console.ReadLine();
            Constant constants = new Constant();
            string data = AddressBookUtil.ReadFile(constants.AddressBook);
            IList<AddressBookModel> addressers = JsonConvert.DeserializeObject<List<AddressBookModel>>(data);


            foreach (var add in addressers)
            {
                Console.WriteLine(add.FirstName + "\t" + add.LastName + "\t" + add.Address + "\t" + add.City + "\t" + add.State + "\t" + add.PhoneNuumber + "\t" +add.ZipCode);
            }
            

        }

        
    }
}
