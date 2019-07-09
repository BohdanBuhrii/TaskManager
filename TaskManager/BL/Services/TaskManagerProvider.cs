using Helper;
using System.Collections.Generic;
using TaskManager.BL.DTOs;
using TaskManager.DAL.Models;
using TaskManager.DAL.Repository;
using TaskManager.DAL.Repository.Abstract;

namespace TaskManager.BL.Services
{
    /// <summary>
    /// Used for communication between PL and DAL.
    /// </summary>
    public class TaskManagerProvider
    {
        private readonly IUnitOfWork _db;

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskManagerProvider"/> class.
        /// </summary>
        public TaskManagerProvider()
        {
            _db = UnitOfWork.GetUnit();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskManagerProvider"/> class.
        /// </summary>
        /// <param name="unitOfWork"> Unit of work. </param>
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

        /// <summary>
        /// Gets user by email.
        /// </summary>
        /// <param name="email"> User's email. </param>
        /// <returns> User. </returns>
        public UserDTO GetUserByEmail(string email)
        {
            return ConvertToDTO(_db.UsersRepo.GetByEmail(email));
        }

        /// <summary>
        /// Gets groups which user follows.
        /// </summary>
        /// <param name="user"> User. </param>
        /// <returns> Groups, which user follows. </returns>
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

        /// <summary>
        /// Gets tasks, created by user.
        /// </summary>
        /// <param name="user"> User. </param>
        /// <returns> Tasks, created by user. </returns>
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

        /// <summary>
        /// Gets tasks, created in concrete group.
        /// </summary>
        /// <param name="group"> Group. </param>
        /// <returns> Tasks, created in this group. </returns>
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

        /// <summary>
        /// Add new user to the database.
        /// </summary>
        /// <param name="user"> User. </param>
        /// <param name="password"> User's password. </param>
        public void AddNewUser(UserDTO user, string password)
        {
            _db.UsersRepo.Add(new User
            {
                Email = user.Email,
                HashPassword = HashHelper.GetHashStringSHA256(password),
                Name = user.Name
            });
            _db.SaveChanges();

            user.Id = _db.UsersRepo.GetByEmail(user.Email).Id;
        }

        /// <summary>
        /// Add new group to the database.
        /// </summary>
        /// <param name="group"> Group. </param>
        /// <param name="user"> User, which will be added to the group. </param>
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

        /// <summary>
        /// Add new task to the database.
        /// </summary>
        /// <param name="task"> Task. </param>
        /// <param name="user"> Task's publisher. </param>
        /// <param name="group"> Group, in which task will be published. </param>
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

        /// <summary>
        /// Add new follower to group.
        /// </summary>
        /// <param name="user"> New follower. </param>
        /// <param name="group"> Group. </param>
        public void AddUserToGroup(UserDTO user, GroupDTO group)
        {
            _db.UserGroupsRepo.Add(new UserGroup { GroupId = group.Id, UserId = user.Id });
            _db.SaveChanges();
        }

        #endregion

        /// <summary>
        /// Unfollow user from group.
        /// </summary>
        /// <param name="user"> User, which following current group.</param>
        /// <param name="group"> Group. </param>
        public void DeleteUserFromGroup(UserDTO user, GroupDTO group)
        {
            foreach (UserGroup ug in _db.UserGroupsRepo.Get(ug => ug.UserId == user.Id && ug.GroupId == group.Id))
            {
                _db.UserGroupsRepo.Delete(ug);
            }
            
            _db.SaveChanges();
        }

        /// <summary>
        /// Marks task as "done".
        /// </summary>
        /// <param name="taskDTO"> Task. </param>
        public void MarkTaskAsDone(TaskDTO taskDTO)
        {
            taskDTO.IsDone = true;

            Task task = _db.TasksRepo.GetByKey(taskDTO.Id);
            task.IsDone = true;

            _db.TasksRepo.Update(task);
            _db.SaveChanges();
        }

        /// <summary>
        /// Check if email exist in database.
        /// </summary>
        /// <param name="email"> Email. </param>
        /// <returns> True, if email exist, false - if not. </returns>
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

        /// <summary>
        /// Check if password is correct for user with current email.
        /// </summary>
        /// <param name="email"> User's email. </param>
        /// <param name="password"> Password. </param>
        /// <returns> True if password is the same, else - false. </returns>
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
