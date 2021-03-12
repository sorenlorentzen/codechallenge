using CodeChallenge.Core;
using CodeChallenge.Core.Implementations;
using CodeChallenge.Core.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            services.AddCodeChallengeCore();
            services.AddTransient<CouponTask>();
            var serviceProvider = services.BuildServiceProvider();



            //Coupon validCoupon = null;


            var sw = Stopwatch.StartNew();

            var couponTasks = new List<CouponTask>();
            for (var i = 0; i < Environment.ProcessorCount; i++)
            {
                couponTasks.Add(serviceProvider.GetRequiredService<CouponTask>());
            }

            var completedTask = await Task.WhenAny(couponTasks.Select(y => y.DoWork()));

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


