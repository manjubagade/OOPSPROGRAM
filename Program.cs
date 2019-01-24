
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


                }
                Console.WriteLine("ENTER YES FOR Y AND NO FOR N");
                flag = Convert.ToChar(Console.ReadLine());
            } while (flag == 'y' || flag == 'Y');


        }
    }
}
