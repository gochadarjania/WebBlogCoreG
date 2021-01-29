using Domain;
using Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class BlogHistoryRepository : BaseRepository<BlogHistory>, IBlogHistoryRepository
    {
        public BlogHistoryRepository(BlogDbContext context) : base(context)
        {

        }
    }
}
