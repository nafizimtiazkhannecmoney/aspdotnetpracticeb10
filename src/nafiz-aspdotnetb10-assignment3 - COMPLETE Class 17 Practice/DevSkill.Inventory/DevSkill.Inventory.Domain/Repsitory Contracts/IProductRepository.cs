using DevSkill.Inventory.Domain.RepositoryContracts;
using DevSkill.Inventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Domain.Repsitory_Contracts
{
    public interface IProductRepository : IRepositoryBase<Product, Guid>
    {

    }
}
