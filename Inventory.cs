
namespace OopsPgm
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// Finding the total amount of json file
    /// </summary>
   public class Inventory
    {
        /// <summary>
        /// inventory data managements this instance
        /// </summary>
        public void PrintTotalData()
        {
            /// Reads the file from which is json format
            Inventory printsDetailsOfInventory = new Inventory();
            Constant constants = new Constant();
           IList<InventoryModel> items = printsDetailsOfInventory.ReadFile(constants.inventoryProducts);
            Console.WriteLine("Name\tweight\tRate\tAmount");
            /// for loop to iterate a data from json file
            foreach (var item in items)
            {
                Console.WriteLine("{0}" + "\t" + "{1}" + " \t" + "{2}" + "\t" + "{3}", item.Name, item.Weight, item.Priceperkg, item.Priceperkg * item.Weight);
            }
        }
        
        public List<InventoryModel> ReadFile(string fileName)
        {
            ////StreamReader is  used to read from the file
            using (StreamReader r = new StreamReader(fileName))
            {
                var json = r.ReadToEnd();
                /// deserialize data because it is in json format
                var items = JsonConvert.DeserializeObject<List<InventoryModel>>(json);
                return items;
            }
        }
    }
}
