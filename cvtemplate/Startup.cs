using System;
using AutoMapper;
using cvtemplate.Data;
using MediatR;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using cvtemplate.Infrastructure;
using System.IO;
using LiteDB;

namespace cvtemplate
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
            services.AddMediatR();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc(opts =>
                    {
                        var policy = new AuthorizationPolicyBuilder()
                                            .RequireAuthenticatedUser()
                                            .Build();
                        opts.Filters.Add(new AuthorizeFilter(policy));
                        opts.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
                    })
                    // Fluent Validation doesn't work on 2.1 yet..
                    //.AddFluentValidation(cfg => { cfg.RegisterValidatorsFromAssemblyContaining<Startup>(); })
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                    .AddFeatureFolders();


            services.AddAutoMapper();

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                    .AddUserStore<ApplicationUserStore>()
                    .AddRoleStore<ApplicationRoleStore>()
                    .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 6;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;

                // User settings
                options.User.RequireUniqueEmail = true;
            });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.Expiration = TimeSpan.FromHours(1);
                options.LoginPath = "/Login";
                options.LogoutPath = "/Logout";
                options.AccessDeniedPath = "/AccessDenied";
                options.SlidingExpiration = true;
            });

            // Implement your own services here..
            var db = Path.Combine(Directory.GetCurrentDirectory(), "litedb.db");

            services.AddScoped<IUserStore<ApplicationUser>, ApplicationUserStore>();
            services.AddScoped<IRoleStore<ApplicationRole>, ApplicationRoleStore>();
            services.AddScoped<IUserRepository, LiteDbUserRepository>();
            services.AddScoped<IRoleRepository, LiteDbRoleRepository>();
            services.AddSingleton<LiteRepository>(_ => new LiteRepository(db));
            services.AddSingleton<LiteDbConfiguration>();

            var serviceProvider = services.BuildServiceProvider();

            // Configure LiteDb.. This can be removed in most cases
            // but it showcases how you can do start-up tasks such as seeding data
            // or specific configuration data..
            serviceProvider.GetService<LiteDbConfiguration>().Init();
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
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
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
