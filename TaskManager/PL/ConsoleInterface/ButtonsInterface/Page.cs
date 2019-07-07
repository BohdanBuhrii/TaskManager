using System;
using System.Collections.Generic;

namespace TaskManager.PL.ConsoleInterface.ButtonsInterface
{
    public class Page
    {
        protected int _currentPosition;
        protected List<Button> buttons;

        public Page()
        {
            buttons = new List<Button>();
            CurrentPosition = -1;
        }

        public Page(params Button[] buttons)
        {
            this.buttons = new List<Button>(buttons);
        }

        public virtual int CurrentPosition
        {
            get
            {
                if (_currentPosition < 0)
                {
                    return 0;
                }
                else
                {
                    return _currentPosition;
                }
            }

            set
            {
                if (value < 0)
                {
                    _currentPosition = buttons.Count + value;
                }
                else if (value > buttons.Count - 1)
                {
                    _currentPosition = 0;
                }
                else
                {
                    _currentPosition = value;
                }
            }
        }

        public virtual void AddButton(Button button)
        {
            buttons.Add(button);
        }

        public virtual void RemoveButton(string buttonContent)
        {
            foreach (Button button in buttons)
            {
                if (button.Content == buttonContent)
                {
                    buttons.Remove(button);
                    break;
                }
            }
        }

        public virtual void MoveDown()
        {
            buttons[CurrentPosition].ToUsual();
            CurrentPosition += 1;
            buttons[CurrentPosition].Highlight();
        }

        public virtual void MoveUp()
        {
            buttons[CurrentPosition].ToUsual();
            CurrentPosition -= 1;
            buttons[CurrentPosition].Highlight();
        }

        public virtual void RunSelectedButton()
        {
            buttons[CurrentPosition].ButtonAction();
        }

        public virtual void Init()
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
                    Console.WriteLine();
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
                    RunSelectedButton();
                    break;
                }
            }
        }

        public virtual void Exit()
        {
            Console.Clear();
        }

        public virtual void ShowErrorMessage(string message)
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(message);
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
        }

        public virtual void ShowSuccessMessage(string message)
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(message);
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
        }

        public virtual void NullAction()
        {
            this.Init();
        }
    }
}
