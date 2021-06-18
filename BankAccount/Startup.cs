using System;
using AutoMapper;
using BankAccount.API.Models;
using BankAccount.Domain.DTOs;
using BankAccount.Domain.Entities;
using BankAccount.Domain.Interfaces;
using BankAccount.Infrastructure.Context;
using BankAccount.Infrastructure.Repository;
using BankAccount.Service.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BankAccount
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.AddDbContext<MySqlContext>(options =>
            {
                var server = Configuration["database:mysql:server"];
                var port = Configuration["database:mysql:port"];
                var database = Configuration["database:mysql:database"];
                var username = Configuration["database:mysql:username"];
                var password = Configuration["database:mysql:password"];

                options.UseMySql($"Server={server};Port={port};Database={database};Uid={username};Pwd={password}", new MySqlServerVersion(new Version(5, 7, 34)), opt =>
                {
                    opt.CommandTimeout(180);
                    opt.EnableRetryOnFailure(5);
                    opt.MigrationsAssembly("BankAccount.Infrastructure");
                });
            });

            // Repositories
            services.AddScoped<IBaseRepository<User>, BaseRepository<User>>();
            services.AddScoped<IBaseRepository<Deposit>, BaseRepository<Deposit>>();
            services.AddScoped<IBaseRepository<Withdraw>, BaseRepository<Withdraw>>();
            services.AddScoped<IBaseRepository<Payment>, BaseRepository<Payment>>();

            services.AddScoped<UserRepository, UserRepository>();
            services.AddScoped<TransactionRepository, TransactionRepository>();

            // Services
            services.AddScoped<IBaseService<User>, BaseService<User>>();
            services.AddScoped<IBaseService<Deposit>, BaseService<Deposit>>();
            services.AddScoped<IBaseService<Withdraw>, BaseService<Withdraw>>();
            services.AddScoped<IBaseService<Payment>, BaseService<Payment>>();

            services.AddScoped<TransactionService, TransactionService>();
            
            // Mappers
            services.AddSingleton(new MapperConfiguration(config =>
            {
                config.CreateMap<CreateUserModel, User>();
                config.CreateMap<MakeDepositModel, Deposit>();
                config.CreateMap<MakePaymentModel, Payment>();
                config.CreateMap<MakeWithdrawModel, Withdraw>();
                config.CreateMap<TransactionBase, TransactionDto>();
            }).CreateMapper());


            // CORS policy
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            })); 
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("MyPolicy");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
            });
        }
    }
}
