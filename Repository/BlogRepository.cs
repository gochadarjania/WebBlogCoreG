using Domain;
using Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class BlogRepository : BaseRepository<Blog>, IBlogRepository
    {
        public BlogRepository(BlogDbContext context) : base(context)
        {

        }
    }
}
