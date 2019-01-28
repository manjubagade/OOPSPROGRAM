namespace OopsPgm
{
    using System;

    /// <summary>
    /// this is inventory managament  crud operation 
    /// </summary>
    class InventoryManagement
    {
        /// <summary>
        /// this is management of crud operation
        /// </summary>
        public void Management()
        {
            ////creating the object of InventoryUtility class
            InventoryUtil inventoryUtility = new InventoryUtil();
            Console.WriteLine("ENTER PRESS 1 TO READ THE ALL FILE");
            Console.WriteLine("ENTER PRESS 2 TO ADDING THE DATA IN FILE");
            Console.WriteLine("ENTER PRESS 3 TO UPDATING THE SOME PRODUCT PRESENT IN THE LIST");
            Console.WriteLine("ENTER PRESS 4 TO DELETE FROM THE SOME PRODUCT FROM FILE");
            int caseToExecute = Convert.ToInt32(Console.ReadLine());
            switch (caseToExecute)
            {
                case 1:

                    inventoryUtility.InventoryManagementData();
                    break;
                case 2:
                    inventoryUtility.AddToInventory();
                    break;
                case 3:
                    inventoryUtility.UpdateInventoryData();
                    break;
                case 4:
                    inventoryUtility.deleteInventory();
                    break;
            }
        }
    }
}
