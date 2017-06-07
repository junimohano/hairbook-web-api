﻿using AutoMapper;
using HairbookWebApi.Database;
using HairbookWebApi.Mappers;
using HairbookWebApi.Repositories;
using HairbookWebApi.Swaggers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.Swagger.Model;
using System.Text;

namespace HairbookWebApi
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsEnvironment("Development"))
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }
            builder.AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting(x => { x.LowercaseUrls = true; });
            services.AddMvc();
            services.AddAutoMapper(x => x.AddProfile(new MappingProfile()));

            // cors
            var corsBuilder = new CorsPolicyBuilder();
            corsBuilder.AllowAnyHeader();
            corsBuilder.AllowAnyMethod();
            corsBuilder.AllowAnyOrigin();
            corsBuilder.AllowCredentials();
            services.AddCors(options => { options.AddPolicy("AllowAll", corsBuilder.Build()); });

            services.AddApiVersioning(o =>
            {
                //                o.AssumeDefaultVersionWhenUnspecified = true;
                //                o.DefaultApiVersion = new ApiVersion(new DateTime(2016, 7, 1));
            });

            services.AddSwaggerGen(options =>
            {
                options.SingleApiVersion(new Info
                {
                    Version = "v1",
                    Title = "Hairbook API",
                    Description = "restful api for an application of hairbook",
                    TermsOfService = "None",
                    Contact = new Contact() { Name = "Jun An", Email = "junimohano@gmail.com", Url = "http://junan.ca" }
                });
                //options.IncludeXmlComments(GetXmlCommentsPath());
                options.DescribeAllEnumsAsStrings();
                options.OperationFilter<FileUploadOperation>(); //Register File Upload Operation Filter
            });

            //services.AddDbContext<HairbookContext>(x => x.UseInMemoryDatabase());
            services.AddDbContext<HairbookContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //#if DEBUG
            //#else
            //#endif

            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, HairbookContext context)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            DbInitializer.Initialize(context);

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUi();

            // If your client secret is base64 encoded, then uncomment these two lines
            //var keyAsBase64 = Configuration["auth0:clientSecret"].Replace('_', '/').Replace('-', '+');
            //var secret = Convert.FromBase64String(keyAsBase64);

            // If your client secret is base64 encoded, then comment out this line, and rather use 2 lines above
            var secret = Encoding.UTF8.GetBytes(Configuration["auth0:clientSecret"]);

            var options = new JwtBearerOptions
            {
                TokenValidationParameters =
                {
                    ValidIssuer = $"https://{Configuration["auth0:domain"]}/",
                    ValidAudience = Configuration["auth0:clientId"],
                    IssuerSigningKey = new SymmetricSecurityKey(secret)
                }
            };
            app.UseJwtBearerAuthentication(options);

            app.UseCors("AllowAll");

            // It should be after JwtBearerAuth
            app.UseMvc(routes =>
            {
                //routes.MapRoute(
                //    name: "default",
                //    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
