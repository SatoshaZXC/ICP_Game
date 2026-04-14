using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ICP
{
    public static class CoinFlip
    {
      public static bool FlipCoin()
        {
            string[] frames =
{
    " (O) ",
    "  |  ",
    " (X) ",
    "  |  "
};
            Console.WriteLine("Обери сторону, яку покличеш із темряви:\n");

            Console.Write("1. ");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Орел (X)");
            Console.ResetColor();

            Console.WriteLine();

            Console.Write("2. ");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Решка (O)\n");
            Console.ResetColor();
            bool tempChoice = true;
            while (true)
            {
                Console.Write("\rТвій вибір:");
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                
                switch (keyInfo.Key)
                    {
                    case ConsoleKey.D1:
                        tempChoice = true;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(" Орел (X)");
                        Console.ResetColor();
                        //Console.WriteLine(keyInfo.Key);
                        break;
                    case ConsoleKey.D2:
                        tempChoice = false;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Решка (O)");
                        Console.ResetColor();
                        //Console.WriteLine(keyInfo.Key);
                        break;
                    case ConsoleKey.Enter:
                        
                        break;
                   
                  
                    default:
                      
                        continue;
                      }
                //Console.WriteLine(keyInfo.Key);
                if (keyInfo.Key == ConsoleKey.Enter)
                    break;


            }
            bool playerChoice = tempChoice;
            //Console.WriteLine(playerChoice == true ? "Орел (X)" : "Решка (O)");
            Random rnd = new Random();

            int duration = rnd.Next(20, 40);
            int speedCoin = 80;
            Console.WriteLine();
            for (int i = 0; i < duration; i++)
            {
                
                //Console.Write("Монетка: " );
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\r" + frames[i % frames.Length]);
                Console.ResetColor();
                Thread.Sleep(speedCoin+=10);

            }
          
            (string result, bool resultReturn) = rnd.Next(2) == 0 ? ("Орёл (X)", true) : ("Решка (O)", false);

            Console.Write("\rМонетка: " );
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(result + "    ");
            Console.ResetColor();
            return playerChoice ==resultReturn ?  true : false;
            

        }
    }
}
