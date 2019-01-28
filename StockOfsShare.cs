using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace OopsPgm
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Newtonsoft.Json;

    /// <summary>
    /// json file to read the company stock data
    /// </summary>
    class StockOfsShare
    {
        /// <summary>
        /// r
        /// </summary>
        public void StockShare()
        {
            ////creating obj for constant class
            Constant constants = new Constant();
            ////Creating one obj for stock model 
            IList<StockModel> stockModels = new List<StockModel>();
            ////the method Stock.ReadFile is called for reading the elements from the stock object
            stockModels = StockOfsShare.ReadFile(constants.stockDetails);
            Console.WriteLine("Id\t name\t availableshare\t price");
            ////looping the all element printend in the json file
            foreach (var item in stockModels)
            {
                Console.WriteLine("{0}" + "\t" + "{1}" + "\t" + "{2}" + "\t" + "{3}",item.id, item.name, item.availableShares, item.Price);
            }
        }
        /// <summary>
        /// Reads the file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>returns the elements in a stock object </returns>
        /// <exception cref="Exception"></exception>
        public static IList<StockModel> ReadFile(string fileName)
        {
            try
            {
                using (StreamReader r = new StreamReader(fileName))
                {
                    var json = r.ReadToEnd();
                    /// deserialize data because it is in json format
                    var items = JsonConvert.DeserializeObject<List<StockModel>>(json);
                    return items;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}
