using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Services
{
    public class BlogPostManagementServices : IBlogPostManagementServices
    {
        private readonly IBlogUnitOfWork _blogUnitOfWork;

        public BlogPostManagementServices(IBlogUnitOfWork blogUnitOfWork)
        {
                _blogUnitOfWork = blogUnitOfWork;
        }
        public void CreateBlogPost(BlogPost blogPost)
        {
            _blogUnitOfWork.BlogPostRepositiory.Add(blogPost);
            _blogUnitOfWork.Save();
        }
    }
}
