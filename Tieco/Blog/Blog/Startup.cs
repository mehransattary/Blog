using Data.Context;
using IRepositories;
using Microsoft.AspNetCore.Authentication.Certificate;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repositories;
using Service.Repository;
using Service.Repository.Interface;
using System;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace Blog
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
            services.AddRazorPages();
            services.AddControllersWithViews();
            services.AddAuthorization(x =>
            {
                x.AddPolicy("admin", p => p.RequireClaim("value_admin_role"));
            });
            services.AddAuthentication(
               CertificateAuthenticationDefaults.AuthenticationScheme)
               .AddCertificate();
            //===========SqlServer==================================================================//
            #region SqlServer
            //=======SqlServer===============//
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("connection"));
            });
            //=======Identity===============//
            services.AddDbContext<IdentityDbContext>(x =>
                x.UseSqlServer(Configuration.GetConnectionString("connection"), o => o.MigrationsAssembly("Data"))
            );
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<IdentityDbContext>().AddDefaultTokenProviders();

            #endregion
            //===========Scoped=====================================================================//
            #region AddScoped

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IAccountService, AccountService>();          
            services.AddScoped<IPersonService, PersonService>();
          
            services.AddScoped<ISocialService, SocialService>();

            services.AddScoped<ISettingsService, SettingsService>();
            services.AddScoped<ISettingsMetasService, SettingsMetaService>();
            services.AddScoped<ISettingsLogoesService, SettingsLogoService>();
            services.AddScoped<ISettingsCopyRightsService, SettingsCopyRightService>();
            services.AddScoped<ISettingAdvertisingService, SettingAdvertisingService>();
            services.AddScoped<ISettingsEnemadsService, SettingsEnemadService>();
            services.AddScoped<IWeblogCategoryService, WeblogCategoryService>();
            services.AddScoped<IWeblogGroupService, WeblogGroupService>();
            services.AddScoped<IWeblogLabelService, WeblogLabelService>();
            services.AddScoped<IWeblogService, WeblogService>();



            services.AddSingleton<Microsoft.AspNetCore.Http.IHttpContextAccessor, Microsoft.AspNetCore.Http.HttpContextAccessor>();
            services.AddSingleton<HtmlEncoder>(HtmlEncoder.Create(allowedRanges: new[] { UnicodeRanges.BasicLatin, UnicodeRanges.Arabic }));         
            //  services.AddAutoMapper(typeof(Startup));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                                     name: "areas",
                                     pattern: "{area:exists}/{controller=Default}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();


            });
        }
    }
}
