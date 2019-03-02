using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.Finance;
//using ApplicationCore.Interfaces.Forms;
using ApplicationCore.Mapping.Finance;
//using ApplicationCore.Services.Finance;
//using ApplicationCore.Services.Forms;
using AutoMapper;
using Infrastructure.Data;
//using Infrastructure.Data.Finance;
//using Infrastructure.Data.Forms;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
//using Web.Services;
using Web.Extensions;
using Newtonsoft.Json.Serialization;
using ApplicationCore.Interfaces.Accounts;
using ApplicationCore.Services.Accounts;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Web.Filters;
using Contracts.Auth;
using Contracts.Accounts;
using Web.Middlewares;
using Web.Handlers;

namespace Web
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            // use real database
            // Requires LocalDB which can be installed with SQL Server Express 2016
            // https://www.microsoft.com/en-us/download/details.aspx?id=54284
            services.AddDbContext<SqlserverContext>(c =>
                c.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            //services.AddScoped(typeof(IAsyncRepository<>), typeof(EfRepository<>));
            services.AddScoped(typeof(IUserService), typeof(UserService));
            services.AddScoped<AuthContext>();
            //services.AddScoped(typeof(IAccountRepository), typeof(AccountRepository));
            //services.AddScoped(typeof(ICommandRepository), typeof(CommandRepository));
            //services.AddScoped(typeof(ITransactionPostingService), typeof(TransactionPostingService));
            //services.AddScoped(typeof(IAccountService), typeof(AccountService));
            //services.AddScoped(typeof(ICashRepositoryService), typeof(CashRepositoryService));
            //services.AddScoped<JournalEntries>();

            //services.AddScoped(typeof(IJournalService), typeof(JournalService));

            //services.AddScoped(typeof(IFormRepository), typeof(FormRepository));
            //services.AddScoped<EntityView>();
            //services.AddScoped<EntityViews>();


            var mappingAssemply = typeof(JournalEntryMappingProfile).Assembly;
            services.ConfigureAutoMapper(new[] { mappingAssemply });

            services.AddCors();

            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
              .AddIdentityServerAuthentication(options =>
              {
                  options.Authority = "http://localhost:5000/";
                  options.ApiName = "api1";
                  options.ApiSecret = "api1Secret";                 
                  options.RequireHttpsMetadata = false;
              });

            services.AddMvc(config =>
                {
                    var policy = new AuthorizationPolicyBuilder()
                                     .RequireAuthenticatedUser()
                                     .Build();
                    config.Filters.Add(new AuthorizeFilter(policy));
                    config.Filters.Add(typeof(AuthContextFilter)); // by type
                }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver()); // If you need/want all of the JSON output to be in PascalCase

            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("EntityTypePolicy", policy =>
            //        policy.Requirements.Add(new EntityTypeRequirement()));                
            //});

            services.AddScoped<IAuthorizationHandler, OfficeEntityTypeAuthorizationHandler>();
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }           

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseCors(builder =>
                builder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());

            app.UseMiddleware<ErrorHandlingMiddleware>();

            app.UseAuthentication();

            

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
