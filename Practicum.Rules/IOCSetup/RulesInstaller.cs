using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Practicum.Contracts;
using Practicum.Rules.PrimaryRules;

namespace Practicum.Rules.IOCSetup
{
    public class RulesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IPrimaryRule>().ImplementedBy<CommaDelimitedInput>(),
                Component.For<IPrimaryRule>().ImplementedBy<TimeOfDayRule>(),
                Component.For<IPrimaryRule>().ImplementedBy<IntTypeForParamsExcludingFirst>());

        }
    }
}
