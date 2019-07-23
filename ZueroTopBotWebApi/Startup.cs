using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;
using ZueroTopBotWebApi.Middlewares;
using ZueroTopBotWebApi.Filters;
using Core.Context;
using Microsoft.EntityFrameworkCore;
using Core.Repositories;

namespace ZueroTopBotWebApi
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
                    new Info
                    {
                        Title = "Zuero Top Bot Telegram",
                        Version = "v1",
                        Description = "API with operations for bot",
                        Contact = new Contact
                        {
                            Name = "André Militão Costa",
                            Url = "https://github.com/andremco"
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

            services.AddDbContext<Context>(options => {
                options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]);
                options.UseLazyLoadingProxies();

                }) ;
            services.AddScoped<UnitOfWork>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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

            app.UseMvc();
        }
    }
}
