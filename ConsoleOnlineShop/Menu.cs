using System;

namespace ConsoleOnlineShop
{
    class Menu
    {
        private string[] items;
        private string nameOfMenu;

        public Menu(string nameOfMenu, string[] items)
        {
            this.items = items;
            this.nameOfMenu = nameOfMenu;
        }

        public virtual int ShowMenuToUserAndReturnChoise()
        {
            int choise = 0;

            ConsoleKey key;

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

                    Console.WriteLine(items[i]);
                }

                key = Console.ReadKey().Key;

                if (key == ConsoleKey.Escape)
                {
                    return 2;
                }

                if (key == ConsoleKey.UpArrow && choise != 0)
                {
                    choise--;
                }
                else if (key == ConsoleKey.DownArrow && choise != items.Length - 1)
                {
                    choise++;
                }

            }
            while (key != ConsoleKey.Enter);

            return choise;
        }
    }
}
