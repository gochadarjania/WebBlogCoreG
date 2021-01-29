using Domain;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class BlogService : BaseService<Blog>, IBlogService
    {
        public BlogService(IBlogRepository blogRepository) : base(blogRepository)
        {

        }
    }
}
