using CodeChallenge.Core;
using CodeChallenge.Core.Implementations;
using CodeChallenge.Core.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace CodeChallenge.ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var services = new ServiceCollection();

            //For simplicity, I'm just reading a json file with configurations. 
            //Using the Microsoft.Extensions.Configuration packages seem like overkill for this simple task.
            var configJson = await File.ReadAllTextAsync("config.json");
            var config = JsonSerializer.Deserialize<Configuration>(configJson);

            new ConfigurationValidator().Validate(config);

            services.AddSingleton(config);

            services.AddCodeChallengeCore(config);

            services.AddTransient<CouponTask>();

            var serviceProvider = services.BuildServiceProvider();

            var tasksCount = Environment.ProcessorCount;

            var keepGoing = true;
            while (keepGoing)
            {
                await DoWork(serviceProvider, tasksCount);

                Console.WriteLine("Type new degree of parallelism (eg. '10') or 'new' to restart. Enter to exit.");
                var input = Console.ReadLine();



                keepGoing = false;

                if (int.TryParse(input, out var number))
                {
                    tasksCount = number;
                    keepGoing = true;
                }
                else if (input.Equals("new", StringComparison.InvariantCultureIgnoreCase))
                {
                    tasksCount = Environment.ProcessorCount;
                    keepGoing = true;
                }
            }

        }

        async static Task DoWork(IServiceProvider serviceProvider, int tasksCount)
        {

            var config = serviceProvider.GetRequiredService<Configuration>();
            Console.WriteLine($"Starting to gennerate Coupon with {config.RowsInCoupon} rows of {config.ColumnsInRow} numbers with a max number of {config.MaxNumber}.");

            var sw = Stopwatch.StartNew();

            var couponTasks = new List<CouponTask>();
            for (var i = 0; i < tasksCount; i++)
            {
                var couponTask = serviceProvider.GetRequiredService<CouponTask>();
                couponTasks.Add(couponTask);
            }

            var completedTask = await Task.WhenAny(couponTasks.Select(y => Task.Run(async () => await y.DoWork())));
            sw.Stop();


            var validCoupon = await completedTask;
            var totalAttempts = couponTasks.Sum(x => x.Attempts);
            var avgCoupon = sw.ElapsedMilliseconds / (decimal)totalAttempts;
            Console.WriteLine($"Success after {couponTasks.Sum(x => x.Attempts)} attempts in {sw.Elapsed.TotalSeconds} seconds.");
            Console.WriteLine($"Each coupon took on average {avgCoupon:N5} ms.");

            PrintCoupon(validCoupon, config.LuckyNumber);
        }

        private static void PrintCoupon(Coupon coupon, int luckyNumber)
        {
            var defaultColor = Console.ForegroundColor;
            foreach (var row in coupon.Rows)
            {
                Console.Write("| ");
                foreach (var number in row.Numbers)
                {
                    var numberString = number.ToString().PadLeft(2, ' ');
                    if (number == luckyNumber)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(numberString);
                        Console.ForegroundColor = defaultColor;
                    }
                    else
                    {
                        Console.Write(numberString);
                    }
                    Console.Write(" | ");
                }
                Console.Write(Environment.NewLine);
            }

        }

    }


}


