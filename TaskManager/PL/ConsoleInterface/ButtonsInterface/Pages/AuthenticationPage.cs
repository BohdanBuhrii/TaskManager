using System;
using TaskManager.BL.DTOs;
using TaskManager.BL.Services;

namespace TaskManager.PL.ConsoleInterface.ButtonsInterface.Pages
{
    public class AuthenticationPage : Page
    {
        private readonly TaskManagerProvider _provider;

        public AuthenticationPage()
        {
            _provider = new TaskManagerProvider();
            buttons.Add(new Button { Content = "Login", ButtonAction = LogIn });
            buttons.Add(new Button { Content = "Registration", ButtonAction = Registration });
            buttons.Add(new Button { Content = "Exit", ButtonAction = Exit });
        }

        public void LogIn()
        {
            while (true)
            {
                Console.Clear();

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
                        MainMenuPage mainMenuPage = new MainMenuPage(_provider.GetUserByEmail(email));
                        mainMenuPage.Init();
                        break;
                    }
                    else
                    {
                        ShowErrorMessage("Uncorrect password, press any key to try again");
                        Console.ReadKey();
                    }
                }
                else
                {
                    ShowErrorMessage("User with this email not found, press 0 to go to previous page, pressany any other key try again");
                    if (Console.ReadKey().Key == ConsoleKey.D0)
                    {
                        Console.Clear();
                        this.Init();
                        break;
                    }

                    Console.Clear();
                }
            }

        }

        public void Registration()
        {
            while (true)
            {
                Console.Clear();

                UserDTO user = new UserDTO();
                string password, confirmPassword;

                Console.Write("Name : ");
                user.Name = Console.ReadLine();

                Console.Write("Email : ");
                user.Email = Console.ReadLine();

                if (_provider.IsEmailExist(user.Email))
                {
                    ShowErrorMessage("User with this email exist in our system, press (0) to try login," +
                        " \npressany any other key try another email");
                    if (Console.ReadLine() == "0")
                    {
                        Console.Clear();
                        AuthenticationPage authentication = new AuthenticationPage();
                        authentication.Init();
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
                            MainMenuPage mainMenuPage = new MainMenuPage(user); 
                            mainMenuPage.Init();
                            break;
                        }
                        else
                        {
                            // todo
                            Console.Clear();
                            ShowErrorMessage("You enter different passwords, try again");
                        }


                    }
                }


            }
        }
    }
}
