using System;
using TaskManager.PL.ConsoleInterface.Abstract;

namespace TaskManager.PL.ConsoleInterface
{
    public class Authentication : ConsoleItem
    {
        public Authentication() : base() { }

        public override void Init()
        {
            StartPage();
        }

        public void StartPage()
        {
            while (true)
            {
                Console.WriteLine("LogIn         (1)");
                Console.WriteLine("Registration  (2)");

                Console.WriteLine("\nExit          (0)");

                choise = ReadChoise(0, 2);


                if (choise == 0)
                {
                    break;
                }
                else if (choise == 1)
                {
                    Console.Clear();
                    LogIn();
                }
                else if (choise == 2)
                {
                    Console.Clear();
                    Registeration();
                }
            }

        }

        public void LogIn()
        {
            while (true)
            {
                string email;
                string password;
                               

                Console.Write("Email : ");
                email = Console.ReadLine();

                if (_provider.IsEmailExist(email))
                {
                    
                    Console.Write("Password : ");
                    password = Console.ReadLine();

                    if (_provider.IsPasswordValid(email, password))
                    {
                        Menu menu = new Menu(_provider.GetUserByEmail(email));
                        menu.Init();
                    }
                    else
                    {
                        //todo
                        Console.WriteLine("Uncorrect password");
                    }
                }
                else
                {
                    Console.WriteLine("User with this email not found, press (0) to go to previous page, \npressany any other key try again");
                    if (Console.ReadLine() == "0")
                    {
                        Console.Clear();
                        StartPage();
                        break;
                    }
                    Console.Clear();
                }              
            }
        }

        public void Registeration()
        {

        }
    }
}
