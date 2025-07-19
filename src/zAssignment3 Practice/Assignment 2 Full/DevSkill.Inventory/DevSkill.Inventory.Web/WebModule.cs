using Autofac;
using Blog.Application;
using Blog.Application.Services;
using Blog.Domain.RepositoryContracts;
using Blog.Infrastructure;
using Blog.Infrastructure.Repositories;
using Blog.Infrastructure.UnitOfWorks;
using DevSkill.Inventory.Web.Data;
using DevSkill.Inventory.Web.Models;

namespace DevSkill.Inventory.Web
{
    public class WebModule (string connectionString, string migrationAssembly) : Module  //Syntax Primary Constructor
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BlogDbContext>().AsSelf()
                .WithParameter("connectionString", connectionString)
                .WithParameter("migrationAssembly", migrationAssembly)
                .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationDbContext>().AsSelf()
                .WithParameter("connectionString", connectionString)
                .WithParameter("migrationAssembly", migrationAssembly)
                .InstancePerLifetimeScope();

            builder.RegisterType<BlogPostRepository>()
                .As<IBlogPostRepositiory>()
                 .InstancePerLifetimeScope();

            builder.RegisterType<BlogUnitOfWork>()
                .As<IBlogUnitOfWork>()
                 .InstancePerLifetimeScope();

            builder.RegisterType<BlogPostManagementServices>()
                .As<IBlogPostManagementServices>()
                 .InstancePerLifetimeScope();
        }
    }
}
