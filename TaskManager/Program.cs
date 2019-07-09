using TaskManager.PL.ConsoleInterface.ButtonsInterface.Pages;

namespace TaskManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            AuthenticationPage authentication = new AuthenticationPage();
            authentication.Init();
        }
    }
}
