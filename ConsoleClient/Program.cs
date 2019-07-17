using System;
using DavidTielke.PersonManagementApp.CrossCutting.DataClasses;
using DavidTielke.PersonManagementApp.Logic.PersonManagement.Contract;
using DavidTielke.PersonManagementApp.Mappings.DiMappings;
using Ninject;

namespace DavidTielke.PersonManagementApp.UI.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var kernel = new StandardKernel();

            new KernelInitializer().Initialize(kernel);

            var manager = kernel.Get<IPersonManager>();

            manager.Add(new Person()
            {
                Age = 42,
                Name = "Dagobert"
            });
            
            var statistic = manager.GetAgeStatistic();

            var adults = manager.GetAllAdults();
            Console.WriteLine($"### Erwachsene ({statistic.AmountAdults}) ###");
            foreach (var adult in adults)
            {
                Console.WriteLine(adult.Name);
            }

            var children = manager.GetAllChildren();
            Console.WriteLine($"### Kinder ({statistic.AmountChildren}) ###");
            foreach (var child in children)
            {
                Console.WriteLine(child.Name);
            }

            Console.ReadKey();
        }
    }
}
