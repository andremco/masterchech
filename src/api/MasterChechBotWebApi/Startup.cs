using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MasterChechBotWebApi.Middlewares;
using MasterChechBotWebApi.Filters;
using Core.Context;
using Microsoft.EntityFrameworkCore;
using Core.Repositories;
using MasterChechBotWebApi.HostedService;
using Core.Messages;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace MasterChechBotWebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(builder => builder
                .AddConsole()
                .AddDebug());

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Zuero Top Bot Telegram",
                        Version = "v1",
                        Description = "API with operations for bot",
                        Contact = new OpenApiContact
                        {
                            Name = "André Militão Costa Oliveira",
                            Email = "andremco1992@gmail.com"
                        }
                    });

                c.OperationFilter<HeaderKeyFilterSwagger>();
            });

            services.AddCors(o => o.AddPolicy("PolicyAPI", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddMvc();

            services.AddHostedService<BotTelegramHostedService>();

            var connectionString = System.Environment.GetEnvironmentVariable("ConnectionString");
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new NullReferenceException("ConnectionString");
            }

            services.AddDbContext<Context>(options => {
                options.UseSqlServer(connectionString);
                options.UseLazyLoadingProxies();
            });

            services.AddScoped<UnitOfWork>();
            services.AddScoped<MessageOnShipBusiness>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json",
                        "Zuero Top Bot");
                });

            }

            app.UseCors("PolicyAPI");

            app.UseMiddleware<APIKeyMiddleware>();
        }
    }
}
