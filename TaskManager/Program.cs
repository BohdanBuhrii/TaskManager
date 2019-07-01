using TaskManager.BL.DTOs;
using TaskManager.PL.ConsoleInterface;


namespace TaskManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu(new UserDTO { Id=1 });
            menu.Init();
        }
    }
}
