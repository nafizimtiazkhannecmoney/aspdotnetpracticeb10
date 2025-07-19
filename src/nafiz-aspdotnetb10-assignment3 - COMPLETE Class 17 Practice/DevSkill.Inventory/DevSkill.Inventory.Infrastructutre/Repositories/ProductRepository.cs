using DevSkill.Inventory.Domain.Entities;
using DevSkill.Inventory.Domain.Repsitory_Contracts;
using DevSkill.Inventory.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Infrastructutre.Repositories
{
    public class ProductRepository : Repository<Product, Guid>, IProductRepository
    {
        public ProductRepository(ProductDbCntext context) : base(context)
        {
                
        }
    }
}
