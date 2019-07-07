using System;
using TaskManager.BL.DTOs;
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

                ReadChoise(0, 2);

                if (choise == 0)
                {
                    break;
                }
                else if (choise == 1)
                {
                    Console.Clear();
                    LogIn();
                    break;
                }
                else if (choise == 2)
                {
                    Console.Clear();
                    Registeration();
                    break;
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
                        break;
                    }
                    else
                    {
                        // todo
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
            while (true)
            {
                UserDTO user = new UserDTO();
                string password, confirmPassword;

                Console.Write("Name : ");
                user.Name = Console.ReadLine();

                Console.Write("Email : ");
                user.Email = Console.ReadLine();

                if (_provider.IsEmailExist(user.Email))
                {
                    Console.WriteLine("User with this email exist in our system, press (0) to try login,"+
                        " \npressany any other key try another password");
                    if (Console.ReadLine() == "0")
                    {
                        Console.Clear();
                        StartPage();
                        break;
                    }

                    Console.Clear();
                }
                else
                {
                    while (true)
                    {
                        Console.Write("Password : ");
                        password = Console.ReadLine();
                        Console.Write("Confirm Password : ");
                        confirmPassword = Console.ReadLine();

                        if (password == confirmPassword)
                        {
                            _provider.AddNewUser(user, password);
                            Console.WriteLine("User created successfully!");
                            Console.WriteLine("Press any key to start work!");
                            Console.ReadLine();
                            Console.Clear();
                            Menu menu = new Menu(user);
                            menu.Init();
                            break;
                        }
                        else
                        {
                            // todo
                            Console.Clear();
                            Console.WriteLine("You enter different passwords, try again");
                        }

                        
                    }
                }
            }
        }
    }
}
