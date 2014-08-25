using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Practicum.Contracts;
using Practicum.Meals.Concrete;
using Morning = Practicum.Meals.Concrete.Morning;
using Night = Practicum.Meals.Concrete.Night;
using Practicum.Meals.Interfaces;

namespace Practicum.Meals.IOC
{
    public class MealsInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IMorningDish>().ImplementedBy<Morning.Entree>(),
                Component.For<IMorningDish>().ImplementedBy<Morning.Side>(),
                Component.For<IMorningDish>().ImplementedBy<Morning.Drink>(),
                Component.For<INightDish>().ImplementedBy<Night.Entree>(),
                Component.For<INightDish>().ImplementedBy<Night.Side>(),
                Component.For<INightDish>().ImplementedBy<Night.Drink>(),
                Component.For<INightDish>().ImplementedBy<Night.Dessert>(),
                Component.For<MealCollection>().LifestyleTransient(),
                Types.FromThisAssembly()
                    .BasedOn<IMeal>()
                    .WithService.Base()
                    .Configure(c => c.LifeStyle.Transient.Named(c.Implementation.Name)));
        }
    }
}
