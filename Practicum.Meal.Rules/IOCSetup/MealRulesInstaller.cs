using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Practicum.Contracts;

namespace Practicum.Meal.Rules.IOCSetup
{
    public class MealRulesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IMealRule>().ImplementedBy<CanAddThisDish>(),
                Component.For<IMealRule>().ImplementedBy<ErrorDishHasNotBeenAddedYet>());
        }
    }
}
