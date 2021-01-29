using Domain;
using Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(BlogDbContext context) : base(context)
        {

        }
    }
}
