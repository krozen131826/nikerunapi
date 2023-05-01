using Microsoft.Extensions.DependencyInjection;
using NikeRun.Application.Contracts.Entities;
using NikeRun.Application.Contracts.Infrastructure;
using NikeRun.DataAccess.Repositories;
using NikeRun.Infrastructure.TokenGenerator;
using NikeRun.Infrastructure.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NikeRun.Infrastructure
{

    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServiceRegistration(this IServiceCollection services)
        {
            services.AddTransient<ITokenProviderService, TokenProviderService>();
            services.AddTransient<IUtilitiesService, UtilitiesService>();
            return services;
        }
    }
}
