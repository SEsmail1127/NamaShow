using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NamaShow.Core.Convertors;
using NamaShow.Core.Services;
using NamaShow.Core.Services.InterFaces;
using NamaShow.DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NmaShow.EndPoint
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
            services.AddControllersWithViews();
            services.AddMvc();
            services.AddRazorPages()
                    .AddRazorPagesOptions(options =>
              {
                        options.Conventions.AddPageRoute("/Index", "{*url}");
               // options.RootDirectory = "/Pages";
            });
            //services.AddRazorPages().AddRazorOptions(options =>
            //{
            //    options.Conventions.AddPageRoute("/index", "{*url}");
            //});


            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddTransient<IMovieService, MovieService>();
            services.AddTransient<ICategorieService, CategorieService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IPermissionService, PermissionService>();
            services.AddTransient<ISlideService, SlideService>();
            services.AddTransient<IComeingSoonService, ComeingSoonService>();
            services.AddTransient<IViewRenderService, RenderViewToString>();
           
            services.AddDbContext<NamaShowContext>(options =>
                     options.UseSqlServer(Configuration.GetConnectionString("NamaShow")));

            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                option.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;

            }).AddCookie(option =>
            {
                option.LoginPath = "/Login";
                option.LogoutPath = "/LogOut";
                option.ExpireTimeSpan = TimeSpan.FromMinutes(5);
            });






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
                //endpoints.MapAreaControllerRoute( "default","Admin","{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "Admin",

                     pattern: "{area:exists}/{controller=UserManeger}/{action=Create}/{id?}"
                    );


                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
