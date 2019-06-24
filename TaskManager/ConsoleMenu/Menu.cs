using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManager.Models;
using TaskManager.Repository;

namespace TaskManager.ConsoleMenu
{
    public class Menu
    {
        private UnitOfWork db;
        private User user;

        public Menu(User user)
        {
            this.user = user;
            db = new UnitOfWork();
        }

        private void ShowTask(Task task)
        {
            Console.WriteLine( "{0}{1}",task.Publisher.Name, task.PublicationDate);
            Console.WriteLine(task.Content);
            Console.WriteLine(task.IsDone);
        }

        private void ShowGroup(Group group)
        {
            Console.Write("{0}, {1}", group.Title, group.Tasks.Count);
        }

        public void ShowGroups()
        {
            int choise=0;

            while (true)
            {
                Console.WriteLine("Choose ");

                int i = 1;
                foreach (Group group in user.Groups)
                {
                    ShowGroup(group);  Console.WriteLine("({0})", i++);
                }

                Console.WriteLine("\nExit (0)");

                choise = Convert.ToInt32(Console.ReadLine());

                if (choise == 0) break;
                else if (choise < 0 && choise <= i) ShowGroupTasks(user.Groups[choise - 1]);
            }
        }

        public void ShowUserTasks()
        { }

        public void ShowGroupTasks(Group group)
        {
            int choise = 0;
            int i = 1;
            foreach (Task task in group.Tasks)
            {
                ShowTask(task); Console.WriteLine(i);
            }
            choise = Convert.ToInt32(Console.ReadLine());
        }

        

        public void Init()
        {
            //var a=typeof(User).GetProperties().Select(property => property.Name).ToArray();

            int choise = 0;
            while (choise != 5)
            {
                Console.Write("\nSee my groups (1)\n" +
                              "See my tasks (2)\n" +
                              "Log out (3)\n" +
                              "Exit (4)\n");

                choise = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                /*
                if (choise == 1)
                {
                    Console.WriteLine("Choose repository (documents, users, issuanceforms)");
                    string repo = Console.ReadLine();

                    try
                    {
                        List<IModel> models = factory.GetRepository(repo).GetAll();
                        foreach (IModel model in models)
                        {
                            Console.WriteLine(model);
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Can't find repository \"{0}\"", repo);
                    }
                }
                else if (choise == 2)
                {
                    //todo
                    Console.WriteLine("Enter user's name: ");

                    //try
                    User user = (User)usersRepo.Get(new UserFilter { user_name = Console.ReadLine() })[0];

                    //try
                    List<IModel> documents = documentsRepo.Get(new DocumentFilter { owner_id = user.user_id, existence = true });

                    Console.WriteLine("Choose document:");

                    for (int i = 0; i < documents.Count; i++)
                    {
                        Console.WriteLine((i + 1).ToString() + ":\n" + documents[i]);
                    }

                    int documentNumber = Convert.ToInt32(Console.ReadLine()) - 1;

                    if
                    (
                    issuanceformsRepo.Add(new IssuanceForm
                    {
                        date_of_issue = DateTime.Now,
                        was_returned = false,
                        document_id = ((Document)documents[documentNumber]).document_id,
                        user_id = user.user_id
                    })
                    )
                    {
                        documentsRepo.Update(new DocumentFilter { owner_id = user.user_id, document_id = ((Document)documents[documentNumber]).document_id }, new DocumentFilter { existence = false });
                        Console.WriteLine("\nDone");
                    }
                    else Console.WriteLine("\nError");

                }
                else if (choise == 3)
                {
                    //todo
                    Console.WriteLine("Enter user's name: ");

                    //try
                    User user = (User)usersRepo.Get(new UserFilter { user_name = Console.ReadLine() })[0];

                    List<IModel> issuanceForms = issuanceformsRepo.Get(new IssuanceFormFilter { user_id = user.user_id });

                    Console.WriteLine("Choose issuance form:");

                    for (int i = 0; i < issuanceForms.Count; i++)
                    {
                        Console.WriteLine((i + 1).ToString() + ":\n" + issuanceForms[i]);
                    }

                    int issuanceFormNumber = Convert.ToInt32(Console.ReadLine()) - 1;

                    if (
                    issuanceformsRepo.Update(new IssuanceFormFilter
                    {
                        user_id = user.user_id,
                        document_id = ((IssuanceForm)issuanceForms[issuanceFormNumber]).document_id
                    },
                        new IssuanceFormFilter { was_returned = true })

                    )
                    {
                        documentsRepo.Update(new DocumentFilter { owner_id = user.user_id, document_id = ((IssuanceForm)issuanceForms[issuanceFormNumber]).document_id }, new DocumentFilter { existence = true });
                        Console.WriteLine("\nDone");
                    }
                    else Console.WriteLine("\nError");
                }
                else if (choise == 4)
                {
                    List<IModel> issuanceforms = issuanceformsRepo.Get(new IssuanceFormFilter { was_returned = false });
                    if (issuanceforms.Count > 0)
                    {
                        foreach (IModel model in issuanceforms)
                        {
                            Console.WriteLine(usersRepo.Get(new UserFilter { user_id = ((IssuanceForm)model).user_id }));
                        }
                    }
                    else Console.WriteLine("No debtors");
                }*/
            }
        }
    }
}
