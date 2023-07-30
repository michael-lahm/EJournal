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
            string line = null;
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.Enter:
                        return line;
                    case ConsoleKey.Escape:
                        return null;
                    case ConsoleKey.Backspace:
                        if (line.Length > 0)
                        {
                            line = line.Remove(line.Length - 1);
                            Console.CursorLeft -= 1;
                            Console.Write(' ');
                            Console.CursorLeft -= 1;
                        }
                        break;
                    default:
                        if (Char.IsLetter(key.KeyChar) || Char.IsDigit(key.KeyChar))
                        {
                            Console.Write(key.KeyChar);
                            line += key.KeyChar;
                        }
                        break;
                }
            }
        }
    }
}
