using Blog.Domain.Entities;
using Blog.Application.Services;
using DevSkill.Inventory.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevSkill.Inventory.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogPostController : Controller
    {
        private readonly IBlogPostManagementServices _blogPostManagementServices;
        public BlogPostController(IBlogPostManagementServices blogPostManagementServices)
        {
            _blogPostManagementServices = blogPostManagementServices;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(BlogPostCreateModel model)
        {
            if (ModelState.IsValid) 
            {
                var blog = new BlogPost { Id = Guid.NewGuid(), Title = model.Title };
                _blogPostManagementServices.CreateBlogPost(blog);
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
