using System;
using TaskManager.BL.Services;

namespace TaskManager.PL.ConsoleInterface.Abstract
{

    public abstract class ConsoleItem
    {
        protected int choise;
        protected readonly TaskManagerProvider _provider;

        public ConsoleItem()
        {
            choise = -1;
            _provider = new TaskManagerProvider();
        }

        protected virtual void ReadChoise(int minValue, int maxValue)
        {
            while (true)
            {
                try
                {
                    choise = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Incorrect input! Please try again : ");
                    continue;
                }

                if (minValue <= choise && choise <= maxValue)
                {
                }
                else
                {
                    Console.WriteLine("Incorrect input! Please try again : ");
                    continue;
                }
            }
        }

        public virtual void Init() { }
    }
}
