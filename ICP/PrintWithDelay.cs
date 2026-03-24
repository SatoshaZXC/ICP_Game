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
            foreach (char c in text)
            {
                Console.Write(c);        // выводим букву
                Thread.Sleep(delayMilliseconds); // ждём
            }
            Console.WriteLine(); // перевод на следующую строку после текста
        }
    }
}
