using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopsPgm
{
    class DeckOfCard
    {
        public void DeckCard()
        {
            String[,] playercard = Utility.cardDistribute();
            Console.WriteLine("Player1 \t Player2 \t Player3 \t Player4");
            Console.WriteLine();
            int x = 0;
            int y = 0;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(playercard[x, y] + " \t ");
                    y++;
                    if (y == 9)
                    {
                        y = 0;
                        x++;
                    }
                }
                Console.WriteLine();
            }
        }
    }
}

