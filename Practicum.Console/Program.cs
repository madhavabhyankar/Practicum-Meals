using System.Linq;
using Castle.Core.Internal;
using Castle.MicroKernel;
using Castle.MicroKernel.Resolvers;
using Practicum.Console.Builder;
using Practicum.Console.IOC;

namespace Practicum.Console
{
    /// <summary>
    /// IMPORTANT
    /// ---------
    /// This project is designed to be highly agile and service oriented.  As such the dependecies are not referenced in the
    /// project, but are exepected (assumed) to be in the folder at runtime.  This allows the 3 components of the project - 
    /// UI, Business Rules and Business Process to evolve independently.
    /// 
    /// If you try to run the project within visual studio, you will not be able to get the expected result. Please use the 
    /// powershell script to build and unit test and run from the Application folder.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Install IOC Container
            var installer = new Install();
            installer.InstallIOC();

            //Using a try, to ensure that all the libraries exist at run time.
            try
            {
                //Mealbuilder wires business logic and rules.
                var mealBuiler = installer.Container.Resolve<IMealBuilder>();

                //Initialize input
                var input = string.Empty;
                do
                {
                    //This wil catch if the user accidently hit 'enter'
                    if (!input.IsNullOrEmpty())
                    {

                        //Run the input through rules validations
                        var ruleValidations = mealBuiler.ValidateRules(input);

                        //If the input passed all rules, show the result, else show error
                        if (ruleValidations.All(x => x.IsValid))
                        {
                            System.Console.WriteLine(mealBuiler.BuildMeal(input));
                        }
                        else
                        {
                            ruleValidations.Where(x => !x.IsValid).All(x =>
                            {
                                System.Console.WriteLine(x.Error);
                                return true;
                            });

                        }
                    }
                    System.Console.WriteLine(@"Please provide input, press 'q' or 'Q' to quit");
                    input = System.Console.ReadLine();
                } while (!input.Trim().ToUpper().Equals("Q"));
            }
            catch (ComponentResolutionException)
            {
                System.Console.WriteLine(
                    "Cannot resolve component necessary for the application to run.  Please ensure that the Business Rules and Business Process libraries exist in {0}",
                    System.Environment.CurrentDirectory);
                System.Console.WriteLine("Exising, hit 'return' to quit");
                System.Console.Read();
            }
            catch (DependencyResolverException)
            {
                System.Console.WriteLine(
                    "Cannot resolve component necessary for the application to run.  Please ensure that the Business Rules and Business Process libraries exist in {0}",
                    System.Environment.CurrentDirectory);
                System.Console.WriteLine("Exising, hit 'return' to quit");
                System.Console.Read();
            }
            finally
            {
                installer.Container.Dispose();
            }

        }
    }
}
