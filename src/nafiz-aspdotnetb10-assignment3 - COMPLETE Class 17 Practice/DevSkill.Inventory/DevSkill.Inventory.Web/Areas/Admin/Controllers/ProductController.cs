using DevSkill.Inventory.Application.Services;
using DevSkill.Inventory.Domain.Entities;
using DevSkill.Inventory.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevSkill.Inventory.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductManagementServices _productManagementServices;

        public ProductController(IProductManagementServices productManagementServices)
        {
            _productManagementServices = productManagementServices;
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
        public IActionResult Create(ProductCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var product = new Product { Id = Guid.NewGuid() , ProductName = model.ProductName };
                _productManagementServices.CreateProduct(product);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
