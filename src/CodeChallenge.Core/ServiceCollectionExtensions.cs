using CodeChallenge.Core.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace CodeChallenge.Core
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCodeChallengeCore(this IServiceCollection services, int luckyNumber)
        {
            //Add generators to IoC container
            services.AddTransient<ICouponGenerator, CouponGenerator>();
            services.AddTransient<IRowGenerator, RowGenerator>();
            services.AddTransient<INumberGenerator, RandomNumberGenerator>();

            //For validation I have implemented two variations.
            //I like the linq one more, so I'm using that.
            services.AddTransient<ICouponValidator, LuckyNumberCouponLinqValidator>(x => new LuckyNumberCouponLinqValidator(luckyNumber));
            //services.AddTransient<ICouponValidator, LuckyNumberCouponLoopsValidator>(x => new LuckyNumberCouponLoopsValidator(luckyNumber));
            return services;
        }
    }
}
