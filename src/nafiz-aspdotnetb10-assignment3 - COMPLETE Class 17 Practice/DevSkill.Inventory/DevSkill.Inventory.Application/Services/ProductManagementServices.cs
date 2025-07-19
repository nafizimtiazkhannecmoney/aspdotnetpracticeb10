using DevSkill.Inventory.Domain.Entities;

namespace DevSkill.Inventory.Application.Services
{
    public class ProductManagementServices : IProductManagementServices
    {
        private readonly IProductUnitOfWork _productUnitOfWork;

        public ProductManagementServices(IProductUnitOfWork productUnitOfWork)
        {
            _productUnitOfWork = productUnitOfWork;
        }
        //public void CreateProduct()
        //{

        //}

        public void CreateProduct(Product product)
        {
           _productUnitOfWork.ProductRepository.Add(product);
            _productUnitOfWork.Save();
        }
    }
}
