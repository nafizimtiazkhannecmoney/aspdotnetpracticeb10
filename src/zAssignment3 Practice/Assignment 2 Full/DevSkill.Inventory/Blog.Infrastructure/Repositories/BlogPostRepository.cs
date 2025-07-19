using Blog.Domain.Entities;
using Blog.Domain.RepositoryContracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infrastructure.Repositories
{
    public class BlogPostRepository : Repository<BlogPost, Guid>, IBlogPostRepositiory
    {
        public BlogPostRepository(BlogDbContext context) : base(context)
        {
        }
    }
}
