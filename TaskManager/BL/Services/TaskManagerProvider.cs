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
                NumberOfUnresolvedTasks = GetNumberOfUnresolvedTasks(group)
            };
        }

        private TaskDTO ConvertToDTO(Task task)
        {
            return new TaskDTO
            {
                Id = task.Id,
                Content = task.Content,
                GroupId = task.Group.Id,
                IsDone = task.IsDone,
                PublicationDate = task.PublicationDate,
                PublisherId = task.Publisher.Id
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

        private uint GetNumberOfUnresolvedTasks(Group group)
        {
            uint counter = 0;

            foreach (Task task in group.Tasks)
            {
                if (task.IsDone == false) counter += 1;
            }

            return counter;
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

        #region DTOGetters

        public UserDTO GetUserByEmail(string email)
        {
            return ConvertToDTO(_db.UsersRepo.GetByEmail(email));
        }

        public List<GroupDTO> GetGroupsByUser(UserDTO user)
        {
            List<GroupDTO> groups = new List<GroupDTO>();

            User userInfo= _db.UsersRepo.Get(u => u.Id == user.Id).GetEnumerator().Current;
            foreach (UserGroup userGroup in userInfo.UserGroups)
            {
                groups.Add(ConvertToDTO(userGroup.Group));
            }

            return groups;
        }

        public List<TaskDTO> GetTasksByUser(UserDTO user)
        {
            List<TaskDTO> tasks = new List<TaskDTO>();

            User userInfo = _db.UsersRepo.Get(u => u.Id == user.Id).GetEnumerator().Current;

            foreach (Task task in userInfo.Tasks)
            {
                tasks.Add(ConvertToDTO(task));
            }

            return tasks;
        }

        public List<TaskDTO> GetTasksByGroup(GroupDTO group)
        {
            List<TaskDTO> tasks = new List<TaskDTO>();

            Group groupInfo = _db.GroupsRepo.Get(g=>g.Id==group.Id).GetEnumerator().Current;

            foreach (Task task in groupInfo.Tasks)
            {
                tasks.Add(ConvertToDTO(task));
            }

            return tasks;
        }

        #endregion

    }
}
