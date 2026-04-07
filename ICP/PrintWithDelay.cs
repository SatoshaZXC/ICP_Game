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
                Console.Write(c);        // виводимо букву
                Thread.Sleep(delayMilliseconds); // чекаємо
            }
            Console.WriteLine(); // перехід на наступний рядок після тексту
        }
    }
}
