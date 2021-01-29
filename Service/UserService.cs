using Domain;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public class UserService : BaseService<User>, IUserService
    {
        public UserService(IUserRepository repository) : base(repository)
        {

        }
        public User CreateUser(string firstName, string lastName, string email, string password, byte[] avatar)
        {
            User user = new User
            {
                Firstname = firstName,
                Lastname = lastName,
                Mail = email,
                Password = password,
                Picture = avatar,
                SystemFields = new SystemFields()
                {
                    IsDeleted = false
                }
            };
            return user;
        }

        public int? Login(string eMail, string password, out string error)
        {
            var user = _repository.Set().SingleOrDefault(u => u.Mail == eMail && u.Password == password);

            if (!CheckMail(eMail))
            {
                error = "Email dont exists";
                return null;
            }
            else if (user == null)
            {
                error = "Inncorect Password ";
                return null;
            }
            else
            {
                error = null;

                return user?.ID;
            }
        }

        public bool CheckMail(string eMail)
        {
            if (_repository.Set().Any(u => u.Mail == eMail))
            {
                return true;
            }
            return false;
        }
    }
}
