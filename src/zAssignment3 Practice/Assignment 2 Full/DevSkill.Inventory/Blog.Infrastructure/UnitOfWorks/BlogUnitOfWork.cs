using Blog.Application;
using Blog.Domain.RepositoryContracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infrastructure.UnitOfWorks
{
    public class BlogUnitOfWork : UnitOfWork , IBlogUnitOfWork
    {
        public IBlogPostRepositiory BlogPostRepositiory { get; private set; }
        public BlogUnitOfWork(BlogDbContext dbContext, 
            IBlogPostRepositiory blogPostRepositiory) : base(dbContext)
        {
            BlogPostRepositiory = blogPostRepositiory;
        }
    }
}
