using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICP.Entity
{
    internal class tempOpen
    {
        public void openTemp(Chest chest, Inventory inventory)
        {
            Item loot = chest.Open();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Випав предмет: {loot}");
            Console.ResetColor();
            Console.WriteLine("Забрати?");
            Console.WriteLine("1. Так\n2. Ні");
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
                        Console.Write("Так");
                        Console.ResetColor();
                        //Console.WriteLine(keyInfo.Key);
                        break;
                    case ConsoleKey.D2:
                        tempChoice = false;
                        Console.ForegroundColor = ConsoleColor.Yellow; 
                        Console.Write(" Ні");
                        Console.ResetColor();
                        //Console.WriteLine(keyInfo.Key);
                        break;
                    case ConsoleKey.Enter:

                        break;


                    default:

                        continue;
                }

                if (keyInfo.Key == ConsoleKey.Enter)
                    break;

            }
            if (tempChoice == true)
                inventory.AddItem(loot);
        }
    }
}
