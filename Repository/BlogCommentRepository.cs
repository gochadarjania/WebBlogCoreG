using Domain;
using Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class BlogCommentRepository : BaseRepository<BlogComment>, IBlogCommentRepository
    {
        public BlogCommentRepository(BlogDbContext context) : base(context)
        {

        }
    }
}
