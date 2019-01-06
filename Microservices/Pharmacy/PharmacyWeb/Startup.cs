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
using PharmacyDAL;
using Microsoft.EntityFrameworkCore;
using PharmacyCommon.Contracts;
using PharmacyBusinessLogic;
using PharmacyCommon.Entities;
using AutoMapper;
using Swashbuckle.AspNetCore.Swagger;
using Newtonsoft.Json;
using PharmacyCommon.Dtos;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using Microsoft.AspNetCore.Http;

namespace PharmacyWeb
{
    public class Startup
    {

        private readonly IHostingEnvironment _hostingEnvironment;
        public Startup(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            Configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
        }


        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            PharmacyCommon.Dtos.DBConfiguration result = null;
            string contentRootPath = _hostingEnvironment.ContentRootPath;
            var JSON = System.IO.File.ReadAllText(contentRootPath + "/App_Data/DBConfiguration.json");

            result = JsonConvert.DeserializeObject<DBConfiguration>(JSON);
            var x = result.Password;

            var connection = $"Server=DESKTOP-CA1SMFG\\SQLEXPRESS;Database=HealthHub;Trusted_Connection=True;Integrated Security=False;MultipleActiveResultSets=True;user id={result.User};password={result.Password}";
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
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory
                .AddConsole(Configuration.GetSection("Logging"))
                .AddDebug();

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

            app.UseExceptionHandler(options =>
            {
                options.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "text/html";
                    var ex = context.Features.Get<IExceptionHandlerFeature>();
                    if (ex != null)
                    {
                        var err = $"<h1>Error: </h1> An error has occurred please contact the administrator";
                        Console.WriteLine($"Error: {ex.Error.Message} {ex.Error.StackTrace }");
                        await context.Response.WriteAsync(err).ConfigureAwait(false);
                    }
                });
            });

            app.UseMvc();
        }
    }
}
