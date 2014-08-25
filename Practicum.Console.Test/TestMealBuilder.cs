using System;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practicum.Console.Builder;
using Practicum.Contracts;

namespace Practicum.Console.Test
{
    [TestClass]
    public class TestMealBuilder
    {
        private class MockRuleResult : IRuleExecutionResult
        {
            public bool IsValid { get; set; }
            public string Error { get; private set; }
        }

        class MockRule : IPrimaryRule
        {
            public IRuleExecutionResult Validate(string input)
            {
                return new MockRuleResult {IsValid = true};
            }
        }

        

        private WindsorContainer Setup()
        {
            var container = new WindsorContainer();
            container.Register(
                Types.FromThisAssembly()
                    .BasedOn<IMeal>()
                    .WithService.Base()
                    .Configure(c => c.LifeStyle.Transient.Named(c.Implementation.Name)));
            

            return container;

        }
        [TestMethod]
        public void TestGetMealGenerator()
        {
            var container = Setup();
            var mockRule = new MockRule();
            var mealBuilder = new MealBuilder(container.Kernel,new IPrimaryRule[]{mockRule});
            var component = mealBuilder.GetMealGeneratorFor("morning");
            Assert.IsInstanceOfType(component,typeof(MorningMeal));

        }
        [TestMethod]
        public void TestGetMealGeneratorWhenMealIsNotDefined()
        {
            var container = Setup();
            var mockRule = new MockRule();
            var mealBuilder = new MealBuilder(container.Kernel, new IPrimaryRule[] { mockRule });
            var component = mealBuilder.GetMealGeneratorFor("blach");
            Assert.IsNull(component);
            

        }
    }
    public class MorningMeal : IMeal
    {
        public string BuildMeal(string[] input)
        {
            throw new NotImplementedException();
        }
    }

    public class NightMeal : IMeal
    {
        public string BuildMeal(string[] input)
        {
            throw new NotImplementedException();
        }
    }
}
