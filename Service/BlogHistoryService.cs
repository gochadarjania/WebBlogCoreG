using Domain;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class BlogHistoryService : BaseService<BlogHistory>, IBlogHistoryService
    {
        public BlogHistoryService(IBlogHistoryRepository blogHistoryRepository) : base(blogHistoryRepository)
        {

        }
    }
}
