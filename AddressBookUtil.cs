
namespace OopsPgm
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;
    using System.IO;
    using System.Text.RegularExpressions;
    
    /// <summary>
    /// AddressBookutil classs creating
    /// </summary>
    public class AddressBookUtil
    {
        /// <summary>
        /// adding the data into a json file
        /// </summary>
        public void AddPerson()
        {
            try
            {
                //// creating the constants cls obj
                Constant constants = new Constant();
                //// creating the arrayList of addreass book
                IList<AddressBookModel> addressBook = new List<AddressBookModel>();
                Console.WriteLine("ENTER THE NAME ");
                string firstname = Console.ReadLine();
                Console.WriteLine("ENTER THE LASTNAME");
                string lastname = Console.ReadLine();
                Console.WriteLine("ENTER THE ADDRESS");
                string address = Console.ReadLine();
                Console.WriteLine("ENTER THE CITY");
                string city = Console.ReadLine();
                Console.WriteLine("ENTER THE STATE");
                string state = Console.ReadLine();
                Console.WriteLine("ENTER THE ZIPCODE");
                string zip = Console.ReadLine();
                Console.WriteLine("ENTER THE VALID PHONE NUMBER");
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
                    string file = AddressBookUtil.ReadFile(constants.AddressBook);
                    addressBook = JsonConvert.DeserializeObject<List<AddressBookModel>>(file);
                    addressBook.Add(addressBookModel);
                    var convertedJson = JsonConvert.SerializeObject(addressBook);
                    File.WriteAllText(constants.AddressBook, convertedJson);
                    Console.WriteLine("SUCCESSFULLY PERSON DETAILS ADDED");
                }
                else
                {
                    Console.WriteLine("ENTER THE VALID DATAILS");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static string ReadFile(string path)
        {
            using (StreamReader streamReader = new StreamReader(path))
            {
                string json = streamReader.ReadToEnd();
                streamReader.Close();
                return json;
            }
        }

        public void Update()
        {
            try
            {
                Console.WriteLine("ENTER THE YOUR PHONE NUMBER UPDATE");
                string phoneNumber = Console.ReadLine();
                Constant constants = new Constant();
                IList<AddressBookModel> addressBook = new List<AddressBookModel>();
                string json = AddressBookUtil.ReadFile(constants.AddressBook);
                addressBook = JsonConvert.DeserializeObject<List<AddressBookModel>>(json);
                bool number = true;
                foreach (var list in addressBook)
                {
                    if (list.PhoneNuumber == phoneNumber)
                    {
                        Console.WriteLine(list.FirstName + "\n" + list.LastName + "\n" + list.Address + "\n" + list.City + "\n" + list.State + "\n" + list.ZipCode + "\n" + list.PhoneNuumber);
                        number = false;
                        string Condition = null;
                        do
                        {
                            Console.WriteLine("PRESS 1 FOR UPDATE PHONE NUMBER");
                            Console.WriteLine("PRESS 2 FOR UPDATE ADDRESS");
                            Console.WriteLine("PRESS 3 FOR UPDATE STATE");
                            Console.WriteLine("PRESS 4 FOR UDDATE THE CITY");
                            int switchCase = Convert.ToInt32(Console.ReadLine());
                            switch (switchCase)
                            {
                                case 1:
                                    Console.WriteLine("ENTER THE NEW PHONE NUMBER");
                                    string newPhoneNumber = Console.ReadLine();
                                    if (Regex.IsMatch(phoneNumber, @"[0-9]{10}"))
                                    {
                                        list.PhoneNuumber = newPhoneNumber;
                                    }
                                    else
                                    {
                                        Console.WriteLine("ENTER THE VALID PHONE NUMBER");
                                    }

                                    break;
                                case 2:
                                    Console.WriteLine("ENTER THE NEW ADDRESS");
                                    string newAddress = Console.ReadLine();
                                    list.Address = Console.ReadLine();
                                    break;
                                case 3:
                                    Console.WriteLine("ENTER THE NEW STATE");
                                    string newState = Console.ReadLine();
                                    if (Regex.IsMatch(newState, @"[a-zA-Z]"))
                                    {
                                        list.PhoneNuumber = newState;
                                    }
                                    else
                                    {
                                        Console.WriteLine("INVALID");
                                    }
                                    break;

                                case 4:
                                    Console.WriteLine("ENTER THE NEW CITY");
                                    string newCity = Console.ReadLine();
                                    if (Regex.IsMatch(newCity, @"[a-zA-Z]"))
                                    {
                                        list.PhoneNuumber = newCity;
                                    }
                                    else
                                    {
                                        Console.WriteLine("INVALID");
                                    }

                                    break;
                            }
                            Console.WriteLine("enter y to continue");
                            Condition = Console.ReadLine();
                        }
                        while (Condition.Equals("y"));
                        var convertedJson = JsonConvert.SerializeObject(addressBook);
                        File.WriteAllText(constants.AddressBook, convertedJson);
                        Console.WriteLine("SUCCESSFULLY UPDATED");
                    }
                }

                if (number == true)
                {
                    Console.WriteLine("enter proper phone number");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        public void AllList()
        {
            Constant constants = new Constant();
            IList<AddressBookModel> addressBook = new List<AddressBookModel>();
            using (StreamReader stream = new StreamReader(constants.AddressBook))
            {
                string data = stream.ReadToEnd();
                stream.Close();
                addressBook = JsonConvert.DeserializeObject<List<AddressBookModel>>(data);
                foreach (var items in addressBook)
                {
                    Console.WriteLine(items.FirstName + "\t" + items.LastName + "\t" + items.Address + "\t" + items.City + "\t" + items.State + "\t" + items.ZipCode + "\t" + items.PhoneNuumber);
                    Console.WriteLine();
                }
            }
        }
        public void Delete()
        {
            Console.WriteLine("ENTER YOUR PHONE NUMBER TO BE DELETED");
            string phoneNumber = Console.ReadLine();
            Constant constants = new Constant();
            IList<AddressBookModel> addressBookModel = new List<AddressBookModel>();
            string json = AddressBookUtil.ReadFile(constants.AddressBook);
            addressBookModel = JsonConvert.DeserializeObject<List<AddressBookModel>>(json);
            bool number = true;
            foreach (var items in addressBookModel)
            {
                if (items.PhoneNuumber == phoneNumber)
                {
                    Console.WriteLine(items.FirstName + "\n" + items.LastName + "\n" + items.Address + "\n" + items.City + "\n" + items.State + "\n" + items.ZipCode + "\n" + items.PhoneNuumber);
                    number = false;
                }
            }

            if (number == true)
            {
                Console.WriteLine("YOUR PHONE NUMBER DO NOT MATCh");
            }

            var itemToRemove = addressBookModel.Single(r => r.PhoneNuumber == phoneNumber);
            addressBookModel.Remove(itemToRemove);
            ////searilizeing the object
            var convertedJson = JsonConvert.SerializeObject(addressBookModel);
            ////writing in to the file
            File.WriteAllText(constants.AddressBook, convertedJson);
            Console.WriteLine("YOUR DATA SUCCESSFULLY DELETED");
        }

        public void SortByLastName()
        {
            Constant con = new Constant();
            string data = AddressBookUtil.ReadFile(con.AddressBook);
            IList<AddressBookModel> addressbook = new List<AddressBookModel>();
            addressbook = JsonConvert.DeserializeObject<List<AddressBookModel>>(data);
            var assendingorder = addressbook.OrderBy(x=>x.LastName);
            var orderByLastName = JsonConvert.SerializeObject(assendingorder);
            File.WriteAllText(con.AddressBook, orderByLastName);
            Console.WriteLine("ORDER BY THE LASTNAME");
        }
        public void SortByZipCode()
        {
            Constant con = new Constant();
            string data = AddressBookUtil.ReadFile(con.AddressBook);
            IList<AddressBookModel> addressbook = new List<AddressBookModel>();
            addressbook = JsonConvert.DeserializeObject<List<AddressBookModel>>(data);
            var sortbyzip = addressbook.OrderBy(x => x.ZipCode);
            var orderByzip = JsonConvert.SerializeObject(sortbyzip);
            File.WriteAllText(con.AddressBook, orderByzip);
            Console.WriteLine("ORDER BY THE LASTNAME");
        }
        public void SaveName()
        {
            Constant con = new Constant();
            string data = AddressBookUtil.ReadFile(con.AddressBook);
            IList<AddressBookModel> address = new List<AddressBookModel>();
            address = JsonConvert.DeserializeObject<List<AddressBookModel>>(data);

        }
    }
}
