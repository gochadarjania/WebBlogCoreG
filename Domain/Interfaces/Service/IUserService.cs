using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.Service
{
    public interface IUserService : IBaseService<User>
    {
        int? Login(string eMail, string password, out string error);
        bool CheckMail(string eMail);
        User CreateUser(string firstName, string lastName, string email, string password, byte[] avatar);
    }
}
