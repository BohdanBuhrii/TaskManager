using System;

namespace TaskManager.PL.ConsoleInterface.ButtonsInterface
{
    /// <summary>
    /// Defines console button.
    /// </summary>
    public class Button
    {
        private ConsoleColor _backgroundColor;
        private ConsoleColor _foregroundColor;

        /// <summary>
        /// Initializes a new instance of the <see cref="Button"/> class.
        /// </summary>
        public Button()
        {
            ToUsual();
        }

        /// <summary>
        /// Defines delegate for button's actoins.
        /// </summary>
        public delegate void Action();

        /// <summary>
        /// Gets or sets (if possible) buttot's background color.
        /// </summary>
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

        /// <summary>
        /// Gets or sets (if possible) buttot's foreground color.
        /// </summary>
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

        /// <summary>
        /// Gets or sets a value indicating whether you can change button's setting.
        /// </summary>
        public bool AbilityToChange { get; set; }

        /// <summary>
        /// Gets a value indicating whether button is selected.
        /// </summary>
        public bool IsSelected { get; private set; }

        /// <summary>
        /// Gets or sets button's content.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets button's action.
        /// </summary>
        public Action ButtonAction { get; set; }

        /// <summary>
        /// Press button.
        /// </summary>
        public void Press()
        {
            ButtonAction();
        }

        /// <summary>
        /// Set button as selected.
        /// </summary>
        public void Highlight()
        {
            _foregroundColor = ConsoleColor.White;
            _backgroundColor = ConsoleColor.DarkCyan;
            IsSelected = true;
        }

        /// <summary>
        /// Set button to usual style.
        /// </summary>
        public void ToUsual()
        {
            _foregroundColor = ConsoleColor.Black;
            _backgroundColor = ConsoleColor.White;
            IsSelected = false;
        }

        /// <summary>
        /// Init button on the consol.
        /// </summary>
        public void Init()
        {
            Console.ForegroundColor = _foregroundColor;
            Console.BackgroundColor = _backgroundColor;

            Console.Write(Content);

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
        }
    }
}
