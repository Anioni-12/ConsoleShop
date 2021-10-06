using System;

namespace ConsoleOnlineShop
{
    class RequestField
    {
        private string[] items;
        private string nameOfMenu;

        public RequestField(string nameOfMenu, string[] items)
        {
            this.items = items;
            this.nameOfMenu = nameOfMenu;
        }

        public bool ShowMenuToUserAndReturnChoise(ref string[] answers)
        {
            int choise = 0;
            ConsoleKeyInfo key;

            do
            {
                Console.Clear();

                Console.WriteLine($"\n\n\n                        {nameOfMenu}\n\n");

                for (int i = 0; i < items.Length; i++)
                {
                    if (i == choise)
                    {
                        Console.Write(" >>> ");
                    }
                    else
                    {
                        Console.Write("     ");
                    }

                    Console.Write(items[i]);

                    if (i != items.Length - 1) Console.WriteLine(" : " + answers[i]);
                }

                key = Console.ReadKey();

                if (key.Key == ConsoleKey.Enter)
                {
                    return true;
                }

                if (key.Key == ConsoleKey.Tab || (key.Modifiers & ConsoleModifiers.Alt) == ConsoleModifiers.Alt || (key.Modifiers & ConsoleModifiers.Control) == ConsoleModifiers.Control) continue;
                if (key.Key == ConsoleKey.Backspace && answers[choise].Length > 0)
                {
                    answers[choise] = answers[choise].Remove(answers[choise].Length - 1);
                    continue;
                }

                if (key.Key == ConsoleKey.UpArrow && choise != 0)
                {
                    choise--;
                }
                else if (key.Key == ConsoleKey.DownArrow && choise != items.Length - 1)
                {
                    choise++;
                }
                else if (choise != items.Length - 1)
                {
                    answers[choise] += key.KeyChar;
                }

            }
            while (key.Key != ConsoleKey.Escape);

            return false;
        }
    }
}
