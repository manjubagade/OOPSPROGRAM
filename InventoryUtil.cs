
namespace OopsPgm
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

   public class InventoryUtil
    {
        IList<InventoryMangModel> inventory = new List<InventoryMangModel>();

        public void InventoryManagementData()
        {
            Console.WriteLine(" diaplaying the items in a inventory management");
            Constant constants = new Constant();

            using (StreamReader streamReader = new StreamReader(constants.InventoryManageMentDetails))
            {
                string json = streamReader.ReadToEnd();
                this.inventory = JsonConvert.DeserializeObject<List<InventoryMangModel>>(json);
            }
        
            foreach (var items in this.inventory)
            {
                Console.WriteLine(items.name + "\t" + items.weight + "\t" + items.pricePerKg);
            }
        }
        public void AddToInventory()
        {
            try
            {
                Console.WriteLine("ENTER THE ID");
                int idNo = Convert.ToInt32(Console.ReadLine());
                Constant constants = new Constant();
                Console.WriteLine("ENTER THE NAME OF PROJUCT");
                string nameOfItem = Console.ReadLine();
                Console.WriteLine("ENTER THE WEIGHT OF PRODUCt");
                double weightOfItem = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("ENTER THE PRICE PER KG FOR PRODDUCT");
                double pricePerkgOfItem = Convert.ToDouble(Console.ReadLine());
                InventoryMangModel managementModel = new InventoryMangModel()
                {
                    id = idNo,
                    name = nameOfItem,
                    weight = weightOfItem,
                    pricePerKg = pricePerkgOfItem
                };

                string data = InventoryUtil.ReadFile(constants.InventoryManageMentDetails);
                this.inventory = JsonConvert.DeserializeObject<List<InventoryMangModel>>(data);
                this.inventory.Add(managementModel);
                var convertedJson = JsonConvert.SerializeObject(inventory);
                File.WriteAllText(constants.InventoryManageMentDetails, convertedJson);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
        public void UpdateInventoryData()
        {
            Constant constants = new Constant();
            string data = InventoryUtil.ReadFile(constants.InventoryManageMentDetails);
            IList<InventoryMangModel> inventoryDetails = JsonConvert.DeserializeObject<List<InventoryMangModel>>(data);

            foreach (var items in inventoryDetails)
            {
                Console.WriteLine(items.id + "\t" + items.name + "\t" + items.weight + "\t" + items.pricePerKg);
            }
            Console.WriteLine("Enter the Id to update");
            int id = Convert.ToInt32(Console.ReadLine());
            foreach (var item in inventoryDetails)
            {
                while (id == item.id)
                {
                    Console.WriteLine(item.id + "\t" + item.name + "\t" + item.weight + "\t" + item.pricePerKg);
                    break;
                }
            }
            Console.WriteLine("Enter 1 to change the price \n Enter 2 to change weight");
            int property = Convert.ToInt32(Console.ReadLine());
            int newPrice = 0;
            int newWeight = 0;
            switch (property)
            {
                case 1:
                    Console.WriteLine("Enter new Price");
                    newPrice = Convert.ToInt32(Console.ReadLine());
                    foreach (var item in inventoryDetails)
                    {
                        while (id == item.id)
                        {
                            item.pricePerKg = newPrice;
                            break;
                        }
                    }
                    break;
                case 2:
                    Console.WriteLine("Enter new Price");
                    newWeight = Convert.ToInt32(Console.ReadLine());
                    foreach (var item in inventoryDetails)
                    {
                        while (id == item.id)
                        {
                            item.weight = newWeight;
                            break;
                        }
                    }
                    break;
            }
            var convertedJson = JsonConvert.SerializeObject(inventoryDetails);
            File.WriteAllText(constants.InventoryManageMentDetails, convertedJson);
        }
        public void deleteInventory()
        {
            Constant constants = new Constant();
            string data = InventoryUtil.ReadFile(constants.InventoryManageMentDetails);
            IList<InventoryMangModel> inventoryDelete = JsonConvert.DeserializeObject<List<InventoryMangModel>>(data);
            foreach (var items in inventoryDelete)
            {
                Console.WriteLine(items.id + "\t" + items.name + "\t" + items.weight + "\t" + items.pricePerKg);
            }
            Console.WriteLine("Enter the Id to delete");
            int id = Convert.ToInt32(Console.ReadLine());
            bool itemExists = true;
            foreach (var item in inventoryDelete)
            {
                if (id == item.id)
                {
                    Console.WriteLine(item.id + "\t" + item.name + "\t" + item.weight + "\t" + item.pricePerKg);
                    itemExists = false;
                    break;
                }
            }
            if (itemExists == true)
            {
                Console.WriteLine("inventory does not exists");
            }
            Console.WriteLine(inventoryDelete);
            var itemToRemove = inventoryDelete.Single(r => r.id == id);
            inventoryDelete.Remove(itemToRemove);

            var convertedJson = JsonConvert.SerializeObject(inventoryDelete);
            File.WriteAllText(constants.InventoryManageMentDetails, convertedJson);
            Console.WriteLine("stock removed");
        }
    }
}
