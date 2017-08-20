using AutoMapper;
using HairbookWebApi.Auth;
using HairbookWebApi.Database;
using HairbookWebApi.Mappers;
using HairbookWebApi.Repositories;
using HairbookWebApi.Swaggers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.Swagger.Model;
using System;

namespace HairbookWebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
            //        builder.AddUserSecrets<Startup>();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddRouting(x => { x.LowercaseUrls = true; });
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
            
#if DEBUG
            //services.AddDbContext<HairbookContext>(x => x.UseInMemoryDatabase());
            services.AddDbContext<HairbookContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
#else
            services.AddDbContextPool<HairbookContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
#endif

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Enable the use of an [Authorize("Bearer")] attribute on methods and classes to protect.
            services.AddAuthorization(auth =>
            {
                auth.AddPolicy(AuthOption.TokenType, new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build());
            });

            services.AddAuthentication(AuthOption.AuthenticationScheme)
                .AddCookie()
                .AddFacebook(o =>
                {
                    o.AppId = Configuration["Authentication:Facebook:AppId"];
                    o.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
                    o.SignInScheme = AuthOption.AuthenticationScheme;
                })
                .AddGoogle(o =>
                {
                    o.ClientId = Configuration["Authentication:Google:ClientId"];
                    o.ClientSecret = Configuration["Authentication:Google:ClientSecret"];
                    o.SignInScheme = AuthOption.AuthenticationScheme;
                })
                .AddJwtBearer(o =>
                {
                    //o.Authority = "http://localhost:4200/";
                    //o.Audience = AuthOption.Audience;
                    //o.RequireHttpsMetadata = false;

                    o.TokenValidationParameters = new TokenValidationParameters()
                    {
                        IssuerSigningKey = AuthOption.Key,
                        ValidAudience = AuthOption.Audience,
                        ValidIssuer = AuthOption.Issuer,
                        // When receiving a token, check that we've signed it.
                        ValidateIssuerSigningKey = true,
                        // When receiving a token, check that it is still valid.
                        ValidateLifetime = true,
                        // This defines the maximum allowable clock skew - i.e. provides a tolerance on the token expiry time 
                        // when validating the lifetime. As we're creating the tokens locally and validating them on the same 
                        // machines which should have synchronised time, this can be set to zero. Where external tokens are
                        // used, some leeway here could be useful.
                        ClockSkew = TimeSpan.FromMinutes(0)
                    };
                });

            // Auth0
            //var options = new JwtBearerOptions
            //{
            //    TokenValidationParameters =
            //    {
            //        ValidIssuer = $"https://{Configuration["auth0:domain"]}/",
            //        ValidAudience = Configuration["auth0:clientId"],
            //        IssuerSigningKey = new SymmetricSecurityKey(secret)
            //    }
            //};
            //app.UseJwtBearerAuthentication(options);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, HairbookContext context)
        {
            DbInitializer.Initialize(context);

            app.UseSwagger();
            app.UseSwaggerUi();

            app.UseAuthentication();

            app.UseCors("AllowAll");

            app.UseStaticFiles();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
