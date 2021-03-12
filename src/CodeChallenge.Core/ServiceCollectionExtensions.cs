using CodeChallenge.Core.Implementations;
using CodeChallenge.Core.Models;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CodeChallenge.Core
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCodeChallengeCore(this IServiceCollection services, Configuration config)
        {
            //Add generators to IoC container
            services.AddTransient<ICouponGenerator, CouponGenerator>();
            services.AddTransient<IRowGenerator, RowGenerator>();
            if (config.UseRandomNext)
            {
                services.AddTransient<INumberGenerator, RandomNextNumberGenerator>(); 
            }
            else
            {
                services.AddTransient<INumberGenerator, RandomNumberGenerator>();
            }

            //For validation I have implemented two variations.
            //I like the linq one more, so I'm using that.
            services.AddTransient<ICouponValidator, LuckyNumberCouponLinqValidator>(x => new LuckyNumberCouponLinqValidator(config.LuckyNumber));
            //services.AddTransient<ICouponValidator, LuckyNumberCouponLoopsValidator>(x => new LuckyNumberCouponLoopsValidator(config.luckyNumber));
            return services;
        }
    }
}
