
namespace OopsPgm
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            char flag;
            do
            {
                Console.WriteLine("PRESS: 1 TO JSON INVENTORY DATA MANAGAMENT");
                Console.WriteLine("PRESS: 2 TO REGULAR EXPRESSION");
                Console.WriteLine("PRESS: 3 TO STOCK OF COMPANY");
                Console.WriteLine("PRESS: 4 TO INVENTORY MANAGAMENTS");
                Console.WriteLine("PRESS: 5 TO DECKOFCARD");
                Console.WriteLine("PRESS 6 TO ADDRESSBOOK");
                Console.WriteLine("PRESS 7 FOR CARDQUEUE");

                int n = Convert.ToInt32(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        Inventory inve = new Inventory();
                        inve.PrintTotalData();
                        break;
                    case 2:
                        RegularExpresstion rx = new RegularExpresstion();
                        rx.Operation();
                        break;
                    case 3:
                        StockOfsShare stockshare = new StockOfsShare();
                        stockshare.StockShare();  
                      break;
                    case 4:
                        InventoryManagement inmanage = new InventoryManagement();
                        inmanage.Management();
                        break;
                    case 5:
                        DeckOfCard dc = new DeckOfCard();
                        dc.DeckCard();
                        break;
                    case 6:
                        AddressBook addbook = new AddressBook();
                        addbook.AddressBookDetails();
                        break;
                    case 7:
                        CardQueue cq = new CardQueue();
                        cq.CardInQueue();
                        break;


                }
                Console.WriteLine("ENTER YES FOR Y AND NO FOR N");
                flag = Convert.ToChar(Console.ReadLine());
            } while (flag == 'y' || flag == 'Y');
        }
    }
}
