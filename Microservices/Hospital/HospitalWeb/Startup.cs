using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using DAL;
using Microsoft.EntityFrameworkCore;
using Common.Contracts;
using BusinessLogic;
using Common.Entities;
using AutoMapper;
using Swashbuckle.AspNetCore.Swagger;

namespace CoreProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = @"";
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection));
            services.AddDbContext<ApplicationDbContext>(options =>
        options.UseInMemoryDatabase(connection)
    );
            services.AddAutoMapper();
           
            services.AddMvc();
            services.AddCors();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API ", Version = "v1" });
            });

            services.AddScoped<IRepository<User>, Repository<User>>();
    
            services.AddTransient<IUserService, UserService>();
          
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
                    app.UseSwagger();
                    app.UseCors(builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            );
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
               // c.RoutePrefix = string.Empty;
            });

            app.UseMvc();
        }
    }
}
