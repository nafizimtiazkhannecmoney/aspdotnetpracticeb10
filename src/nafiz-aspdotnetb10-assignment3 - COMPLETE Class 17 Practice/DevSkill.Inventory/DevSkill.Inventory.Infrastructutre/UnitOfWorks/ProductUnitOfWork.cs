using DevSkill.Inventory.Application;
using DevSkill.Inventory.Domain.RepositoryContracts;
using DevSkill.Inventory.Domain.Repsitory_Contracts;
using DevSkill.Inventory.Infrastructure.UnitOfWorks;
using DevSkill.Inventory.Infrastructutre;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Inventory.Infrastructure.UnitOfWorks
{
    public class ProductUnitOfWork : UnitOfWork, IProductUnitOfWork
    {
        public IProductRepository ProductRepository { get; private set; }

       // public IProductRepository productRepository => throw new NotImplementedException();           //Extra----------

        public ProductUnitOfWork(ProductDbCntext dbContext, 
            IProductRepository productRepository) : base(dbContext)
        {
            ProductRepository = productRepository;
        }
    }
}
