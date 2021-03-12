using CodeChallenge.Core;
using CodeChallenge.Core.Generators;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace CodeChallenge.ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var services = new ServiceCollection();

            services.AddCodeChallengeCore();


            var serviceProvider = services.BuildServiceProvider();

            var rng = serviceProvider.GetRequiredService<INumberGenerator>();


            for(var i = 0; i < 10_000; i++)
            {
                Console.WriteLine(rng.GenerateNumber(40));
            }



        }
    }
}
