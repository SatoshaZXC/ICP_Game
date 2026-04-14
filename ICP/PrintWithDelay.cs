using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICP
{
    public  class PrintWithDelay
    {
       public static void printWithDelay(string text, int delayMilliseconds)
        {
            bool skip = false;

            for (int i = 0; i < text.Length; i++)
            {
                if (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                    skip = true;
                }

                if (skip)
                {
                    Console.Write(text.Substring(i));
                    break;
                }

                Console.Write(text[i]);
                Thread.Sleep(delayMilliseconds);
            }

            Console.WriteLine();
        }
    }
}
