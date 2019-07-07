using Helper;
using System.Collections.Generic;
using TaskManager.BL.DTOs;
using TaskManager.DAL.Models;
using TaskManager.DAL.Repository;
using TaskManager.DAL.Repository.Abstract;

namespace TaskManager.BL.Services
{
    public class TaskManagerProvider
    {
        private readonly IUnitOfWork _db;

        public TaskManagerProvider()
        {
            _db = UnitOfWork.GetUnit();
        }

        public TaskManagerProvider(IUnitOfWork unitOfWork)
        {
            _db = unitOfWork;
        }

        #region ConvertToDTO

        private GroupDTO ConvertToDTO(Group group)
        {
            return new GroupDTO
            {
                Id = group.Id,
                Title = group.Title,
                NumberOfUnresolvedTasks = GetNumberOfUnresolvedTasks(group),
            };
        }

        private TaskDTO ConvertToDTO(Task task)
        {
            return new TaskDTO
            {
                Id = task.Id,
                Content = task.Content,
                GroupTitle = task.Group.Title,
                IsDone = task.IsDone,
                PublicationDate = task.PublicationDate,
                PublisherName = task.Publisher.Name
            };
        }

        private UserDTO ConvertToDTO(User user)
        {
            return new UserDTO
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name
            };
        }

        #endregion

        #region Getters
        private uint GetNumberOfUnresolvedTasks(Group group)
        {
            uint counter = 0;

            IEnumerable<Task> tasks = _db.TasksRepo.Get(t => t.GroupId == group.Id);

            foreach (Task task in tasks)
            {
                if (task.IsDone == false)
                {
                    counter += 1;
                }
            }

            return counter;
        }

        public UserDTO GetUserByEmail(string email)
        {
            return ConvertToDTO(_db.UsersRepo.GetByEmail(email));
        }

        public List<GroupDTO> GetGroupsByUser(UserDTO user)
        {
            List<GroupDTO> groups = new List<GroupDTO>();

            IEnumerable<UserGroup> userGroups = _db.UserGroupsRepo.Get(ug => ug.UserId == user.Id);

            foreach (UserGroup userGroup in userGroups)
            {
                groups.Add(ConvertToDTO(userGroup.Group));
            }

            return groups;
        }

        public List<TaskDTO> GetTasksByUser(UserDTO user)
        {
            List<TaskDTO> taskDTOs = new List<TaskDTO>();

            IEnumerable<Task> tasks = _db.TasksRepo.Get(t => t.PublisherId == user.Id);

            foreach (Task task in tasks)
            {
                taskDTOs.Add(ConvertToDTO(task));
            }

            return taskDTOs;
        }

        public List<TaskDTO> GetTasksByGroup(GroupDTO group)
        {
            List<TaskDTO> taskDTOs = new List<TaskDTO>();

            IEnumerable<Task> tasks = _db.TasksRepo.Get(t => t.GroupId == group.Id);

            foreach (Task task in tasks)
            {
                taskDTOs.Add(ConvertToDTO(task));
            }

            return taskDTOs;
        }

        #endregion

        #region Adders

        public void AddNewUser(UserDTO user, string password)
        {
            _db.UsersRepo.Add(new User
            {
                Email = user.Email,
                HashPassword = HashHelper.GetHashStringSHA256(password),
                Name = user.Name
            });
            _db.SaveChanges();
        }

        public void AddNewGroup(GroupDTO group, UserDTO user)
        {
            _db.GroupsRepo.Add(new Group
            {
                Title = group.Title
            });
            _db.SaveChanges();

            foreach (Group g in _db.GroupsRepo.Get(g => g.Title == group.Title))
            {
                group.Id = g.Id;
            }

            _db.UserGroupsRepo.Add(new UserGroup
            {
                UserId = user.Id,
                GroupId = group.Id
            });

            _db.SaveChanges();
        }

        public void AddNewTask(TaskDTO task, UserDTO user, GroupDTO group)
        {
            Task t = new Task
            {
                Content = task.Content,
                GroupId = group.Id,
                IsDone = task.IsDone,
                PublicationDate = task.PublicationDate,
                PublisherId = user.Id
            };
            _db.TasksRepo.Add(t);
            _db.SaveChanges();
        }

        public void AddUserToGroup(UserDTO user, GroupDTO group)
        {
            _db.UserGroupsRepo.Add(new UserGroup { GroupId = group.Id, UserId = user.Id });
            _db.SaveChanges();
        }

        #endregion

        public void DeleteUserFromGroup(UserDTO user, GroupDTO group)
        {
            _db.UserGroupsRepo.DeleteRange(_db.UserGroupsRepo.Get(ug => ug.UserId == user.Id && ug.GroupId == group.Id));
            _db.SaveChanges();
        }

        public void MarkTaskAsDone(TaskDTO taskDTO)
        {
            taskDTO.IsDone = true;

            Task task = _db.TasksRepo.GetByKey(taskDTO.Id);
            task.IsDone = true;

            _db.TasksRepo.Update(task);
            _db.SaveChanges();
        }

        public bool IsEmailExist(string email)
        {
            if (_db.UsersRepo.GetByEmail(email) == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool IsPasswordValid(string email, string password)
        {
            if (IsEmailExist(email))
            {
                if (_db.UsersRepo.GetByEmail(email).HashPassword == HashHelper.GetHashStringSHA256(password))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
