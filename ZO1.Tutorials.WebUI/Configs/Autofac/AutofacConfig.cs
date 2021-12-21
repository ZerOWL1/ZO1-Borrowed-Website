using Autofac;
using ZO1.Tutorials.Core.Contexts;
using ZO1.Tutorials.Core.Cores.Repositories;
using ZO1.Tutorials.Core.Cores.UnitOfWork;
using ZO1.Tutorials.Services.Services.Implement;

namespace ZO1.Tutorials.WebUI.Configs.Autofac
{
    public class AutofacConfig : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BorrowedContext>().AsSelf().InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();

            //Scan an assembly for components
            builder.RegisterAssemblyTypes(typeof(ItemRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(ItemService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

        }
    }
}