using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using NikeRun.Application.Contracts.Entities;
using NikeRun.DataAccess.NikeRunDBContext;
using NikeRun.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikeRun.DataAccess
{
    public static class DataAccessServiceRegistration
    {
        public static IServiceCollection AddDataAccessServiceRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            //Jwt Configuration Variables
            var key = Encoding.UTF8.GetBytes(configuration.GetSection("SecretKey:key").Value);
            var jwtValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false, // for dev purpose only
                ValidateAudience = false, // for dev purpose only
                RequireExpirationTime = true, // for dev purpose only
                ValidateLifetime = false,
                ClockSkew = TimeSpan.Zero,
            };

            //DbContext Instance

            services.AddDbContext<NikeRunDbContext>(option => option.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")
                    ));


            //Services Instances
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<ICartsRepository, CartsRepository>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(jwt =>
            {
                jwt.SaveToken = false;
                jwt.TokenValidationParameters = jwtValidationParameters;
            });


            return services;
        }
    }
};
