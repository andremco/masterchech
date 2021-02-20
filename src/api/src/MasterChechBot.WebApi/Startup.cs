using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using MasterChechBotWebApi.HostedService;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Telegram.Bot;
using MasterChechBot.Core.Context;
using MasterChechBot.Core.Repositories;
using MasterChechBot.Core.Services;

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
                //c.OperationFilter<HeaderKeyFilterSwagger>();
            });

            services.AddCors(o => o.AddPolicy("PolicyAPI", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddControllers();

            services.AddMvc();

            var connectionString = System.Environment.GetEnvironmentVariable("ConnectionString");
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new NullReferenceException("ConnectionString");
            }

            var botKey = System.Environment.GetEnvironmentVariable("BotKey");
            if (string.IsNullOrEmpty(botKey))
            {
                throw new NullReferenceException("BotKey");
            }

            services.AddDbContext<Context>(options => {
                options.UseSqlServer(connectionString);
                options.UseLazyLoadingProxies();
            });

            services.AddScoped<UnitOfWork>();
            services.AddScoped<MessageOnKitchen>();
            services.AddScoped<ITelegramBotClient>(c => new TelegramBotClient(botKey));
            services.AddHostedService<BotTelegramHostedService>();
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

            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseCors("PolicyAPI");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            //app.UseMiddleware<APIKeyMiddleware>();
        }
    }
}
