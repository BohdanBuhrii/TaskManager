using System;

namespace TaskManager.PL.ConsoleInterface.ButtonsInterface
{
    /// <summary>
    /// Defines console page to show lists of items.
    /// </summary>
    public class ListView : Page
    {
        /// <summary>
        /// Init all elements of page, sseparated with specific blankline.
        /// </summary>
        public override void Init()
        {
            if (buttons != null)
            {
                buttons[0].Highlight();
            }

            while (true)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;

                foreach (Button button in buttons)
                {
                    button.Init();

                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.WriteLine();
                    for (int i = 0; i < Constants.ConsoleWidth; i++)
                    {
                        Console.Write(" ");
                    }

                    Console.WriteLine();
                    Console.BackgroundColor = ConsoleColor.White;
                }

                ConsoleKey key = Console.ReadKey().Key;

                if (key == ConsoleKey.UpArrow)
                {
                    MoveUp();
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    MoveDown();
                }
                else if (key == ConsoleKey.Enter)
                {
                    PressSelectedButton();
                    break;
                }
            }
        }
    }
}
