using System;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Practicum.Console.Builder;

namespace Practicum.Console.IOC
{
    class Install
    {
        private static readonly IWindsorContainer _container = new WindsorContainer();

        public void InstallIOC()
        {
            //Initialize windsor
            Container.AddFacility<TypedFactoryFacility>();
            Container.Kernel.Resolver.AddSubResolver(new CollectionResolver(Container.Kernel));

            Container.Install(FromAssembly.InDirectory(new AssemblyFilter(Environment.CurrentDirectory, "*.Rules.dll")),
                FromAssembly.InDirectory(new AssemblyFilter(Environment.CurrentDirectory, "*.Meals.dll")));

            Container.Register(Component.For<IMealBuilder>().ImplementedBy<MealBuilder>());

            

        }

        public IWindsorContainer Container { get { return _container; }}
    }
}
