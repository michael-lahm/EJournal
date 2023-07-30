using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace EJournal
{
    static internal class Tool
    {
        static internal void Msg(string Text)
        {
            Console.Clear();
            Console.WriteLine(Text);
            Thread.Sleep(1000);
        }

        static internal void WaitStart()
        {
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }

        static internal string InputWithEscape()
        {
            string line = "";
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(false);
                if (key.Key == ConsoleKey.Enter)
                    return line;
                else if (key.Key == ConsoleKey.Escape)
                    return null;
                line += key.KeyChar;
            }
        }
    }
}
