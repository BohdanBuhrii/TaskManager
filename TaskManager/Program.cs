﻿using TaskManager.PL.ConsoleInterface;


namespace TaskManager
{
    class Program
    {
        static void Main(string[] args)
        {
            //Authentication authentication = new Authentication();
            //authentication.Init();
            //BL.Services.TaskManagerProvider provider = new BL.Services.TaskManagerProvider();
            //provider.AddNewTask( //not work
            //    new TaskDTO { Content = "test task", GroupTitle = "Family", IsDone = false, PublicationDate = System.Convert.ToDateTime("02-07-2019"), PublisherName = "Bohdan" },
            //    new UserDTO { Id = 1, Email = "bohdan@gmail.com", Name = "Bohdan" },
            //    new GroupDTO { Id = 1, Title = "Family" });
            DAL.Repository.Abstract.IUnitOfWork db = DAL.Repository.UnitOfWork.GetUnit();
            //var p=provider.GetUserByEmail("bohdan@gmail.com"); //work
            
        }
    }
}
