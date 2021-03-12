using CodeChallenge.Core.Implementations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge.Core
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCodeChallengeCore(this IServiceCollection services)
        {
            services.AddTransient<ICouponGenerator, CouponGenerator>();
            services.AddTransient<IRowGenerator, RowGenerator>();
            services.AddTransient<INumberGenerator, RandomNumberGenerator>();

            return services;
        }
    }
}
