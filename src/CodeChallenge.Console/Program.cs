using CodeChallenge.Core;
using CodeChallenge.Core.Implementations;
using CodeChallenge.Core.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
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
            services.AddSingleton(config);

            services.AddCodeChallengeCore(config.LuckyNumber);

            services.AddTransient<CouponTask>();

            var serviceProvider = services.BuildServiceProvider();

            var sw = Stopwatch.StartNew();
            
            var couponTasks = new List<CouponTask>();
            for (var i = 0; i < Environment.ProcessorCount; i++)
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
            Console.WriteLine(JsonSerializer.Serialize(validCoupon));

        }

    }


}


