using CodeChallenge.Core;
using CodeChallenge.Core.Implementations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
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

            var numbersDictionary = Enumerable.Range(0, 10_000).Select(x => rng.GenerateNumber(40)).GroupBy(x => x).OrderByDescending(x => x.Count()).ToDictionary(x => x.Key, x => x.Count());
            

            foreach(var pair in numbersDictionary.Take(10))
            {
                Console.WriteLine($"{pair.Key} was seen {pair.Value} times");
            }



        }
    }
}
