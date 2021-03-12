using CodeChallenge.Core;
using CodeChallenge.Core.Implementations;
using CodeChallenge.Core.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
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

            var couponGenerator = serviceProvider.GetRequiredService<ICouponGenerator>();
            var validator = serviceProvider.GetRequiredService<ICouponValidator>();

            var sw = Stopwatch.StartNew();
            Coupon validCoupon = null;
            var attempts = 0;
            while(validCoupon == null)
            {
                var coupon = couponGenerator.GenerateCoupon();
                if (validator.IsValid(coupon))
                {
                    validCoupon = coupon;
                }
                attempts++;
            }
            sw.Stop();

            Console.WriteLine($"Success after {attempts} attempts in {sw.Elapsed.TotalSeconds} seconds.");
            Console.WriteLine(JsonSerializer.Serialize(validCoupon, new JsonSerializerOptions { WriteIndented = true }));
            
        }
    }
}
