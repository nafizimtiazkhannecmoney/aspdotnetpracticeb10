using Autofac;
using DevSkill.Inventory.Application.Services;
using DevSkill.Inventory.Domain.Repsitory_Contracts;
using DevSkill.Inventory.Infrastructutre.Repositories;
using DevSkill.Inventory.Web.Models;
using DevSkill.Inventory.Infrastructure;
using DevSkill.Inventory.Infrastructutre;
using DevSkill.Inventory.Infrastructure.UnitOfWorks;
using DevSkill.Inventory.Application;
using DevSkill.Inventory.Web.Data;

namespace DevSkill.Inventory.Web
{
    public class WebModule(string connectionString, string migrationAssembly) : Module //Syntax Primary Constructor
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductDbCntext>().AsSelf()
                .WithParameter("connectionString", connectionString)
                .WithParameter("migrationAssembly", migrationAssembly)
                .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationDbContext>().AsSelf()
                .WithParameter("connectionString", connectionString)
                .WithParameter("migrationAssembly", migrationAssembly)
                 .InstancePerLifetimeScope();

            builder.RegisterType<ProductRepository>()
                .As<IProductRepository>()
                 .InstancePerLifetimeScope();

            builder.RegisterType<ProductUnitOfWork>()
                .As<IProductUnitOfWork>()
                 .InstancePerLifetimeScope();

            builder.RegisterType<ProductManagementServices>()
                .As<IProductManagementServices>()
                 .InstancePerLifetimeScope();
        }
    }
}
