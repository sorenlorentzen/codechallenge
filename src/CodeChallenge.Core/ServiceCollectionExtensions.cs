using CodeChallenge.Core.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace CodeChallenge.Core
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCodeChallengeCore(this IServiceCollection services)
        {
            //Add generators to IoC container
            services.AddTransient<ICouponGenerator, CouponGenerator>();
            services.AddTransient<IRowGenerator, RowGenerator>();
            services.AddTransient<INumberGenerator, RandomNumberGenerator>();

            //For validation we have two possibilities.
            //I like the linq one more, so I'm using that.
            services.AddTransient<ICouponValidator, LuckyNumberCouponLinqValidator>(x => new LuckyNumberCouponLinqValidator(13)); //TODO: Get this value from config. Hardcoded for now.
            //services.AddTransient<ICouponValidator, LuckyNumberCouponLoopsValidator>(x => new LuckyNumberCouponLoopsValidator(13)); //TODO: Get this value from config. Hardcoded for now.
            return services;
        }
    }
}
