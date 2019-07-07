using System;
using System.Collections.Generic;

namespace TaskManager.PL.ConsoleInterface.ButtonsInterface
{
    /// <summary>
    /// Defines console page.
    /// </summary>
    public class Page
    {
        /// <summary>
        /// Index of current element on the page.
        /// </summary>
        protected int _currentPosition;

        /// <summary>
        /// Buttons of which the page is composed.
        /// </summary>
        protected List<Button> buttons;

        /// <summary>
        /// Initializes a new instance of the <see cref="Page"/> class.
        /// </summary>
        public Page()
        {
            buttons = new List<Button>();
            CurrentPosition = -1;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Page"/> class.
        /// </summary>
        /// <param name="buttons"> Array of buttons. </param>
        public Page(params Button[] buttons)
        {
            this.buttons = new List<Button>(buttons);
        }

        /// <summary>
        /// Gets or sets index of current element on the page.
        /// </summary>
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

        /// <summary>
        /// Add new button to the page.
        /// </summary>
        /// <param name="button">Button.</param>
        public virtual void AddButton(Button button)
        {
            buttons.Add(button);
        }

        /// <summary>
        /// Remove button with specific content.
        /// </summary>
        /// <param name="buttonContent"> Content of button.</param>
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

        /// <summary>
        /// Select next button on the page.
        /// </summary>
        public virtual void MoveDown()
        {
            buttons[CurrentPosition].ToUsual();
            CurrentPosition += 1;
            buttons[CurrentPosition].Highlight();
        }

        /// <summary>
        /// Select previous button on the page.
        /// </summary>
        public virtual void MoveUp()
        {
            buttons[CurrentPosition].ToUsual();
            CurrentPosition -= 1;
            buttons[CurrentPosition].Highlight();
        }

        /// <summary>
        /// Press selected button.
        /// </summary>
        public virtual void PressSelectedButton()
        {
            buttons[CurrentPosition].ButtonAction();
        }

        /// <summary>
        /// Init all elements of page in specific way.
        /// </summary>
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
                    PressSelectedButton();
                    break;
                }
            }
        }

        /// <summary>
        /// Program's end.
        /// </summary>
        public virtual void Exit()
        {
            Console.Clear();
        }

        /// <summary>
        /// Show message in specific way.
        /// </summary>
        /// <param name="message">Error message.</param>
        public virtual void ShowErrorMessage(string message)
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(message);
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
        }

        /// <summary>
        /// Show message in specific way.
        /// </summary>
        /// <param name="message">Message about success. </param>
        public virtual void ShowSuccessMessage(string message)
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(message);
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
        }

        /// <summary>
        /// Refresh page.
        /// </summary>
        public virtual void NullAction()
        {
            this.Init();
        }
    }
}
