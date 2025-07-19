
using DevSkill.Inventory.Domain.Entities;

namespace DevSkill.Inventory.Application.Services
{
    public interface IProductManagementServices
    {
        void CreateProduct(Product product);
    }
}