.using Domain;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class BlogCommentService : BaseService<BlogComment>, IBlogCommentService
    {
        public BlogCommentService(IBlogCommentRepository blogCommentRepository) : base(blogCommentRepository)
        {

        }
    }
}
