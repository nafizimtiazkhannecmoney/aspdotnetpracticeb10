using Blog.Domain.Entities;

namespace Blog.Application.Services
{
    public interface IBlogPostManagementServices
    {
        void CreateBlogPost(BlogPost blogPost);
    }
}