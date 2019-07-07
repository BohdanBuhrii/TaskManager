using System;

namespace TaskManager.PL.ConsoleInterface.ButtonsInterface
{
    public class Button
    {
        private ConsoleColor _backgroundColor;
        private ConsoleColor _foregroundColor;

        public Button()
        {
            ToUsual();
        }

        public delegate void Action();

        public ConsoleColor BackgroundColor
        {
            get
            {
                return _backgroundColor;
            }

            set
            {
                if (AbilityToChange)
                {
                    _backgroundColor = value;
                }
            }
        }

        public ConsoleColor ForegroundColor
        {
            get
            {
                return _foregroundColor;
            }

            set
            {
                if (AbilityToChange)
                {
                    _foregroundColor = value;
                }
            }
        }

        public bool AbilityToChange { get; set; }

        public bool IsSelected { get; private set; }

        public string Content { get; set; }

        public Action ButtonAction { get; set; }

        public void Press()
        {
            ButtonAction();
        }

        public void Highlight()
        {
            _foregroundColor = ConsoleColor.White;
            _backgroundColor = ConsoleColor.DarkCyan;
            IsSelected = true;
        }

        public void ToUsual()
        {
            _foregroundColor = ConsoleColor.Black;
            _backgroundColor = ConsoleColor.White;
            IsSelected = false;
        }

        public void Init()
        {
            Console.ForegroundColor = _foregroundColor;
            Console.BackgroundColor = _backgroundColor;

            int i = 0;
            foreach (char c in Content)
            {
                Console.Write(c);
                i += 1;
                if (i == Constants.ConsoleWidth)
                {
                    i = 0;
                    Console.WriteLine();
                }
            }

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
        }
    }
}
