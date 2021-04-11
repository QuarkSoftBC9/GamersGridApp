using GamersGrid.BLL;
using GamersGrid.DAL;
using GamersGrid.DAL.Models;
using GamersGrid.DAL.Models.Identity;
using GamersGrid.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamersGrid
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddIdentity<GGuser, CustomRole>()
                 .AddEntityFrameworkStores<ApplicationDbContext>()
                 .AddUserStore<CustomUserStore>()
                        .AddRoleStore<CustomRoleStore>()
                     .AddDefaultTokenProviders();

            services.AddSingleton<CustomHelperService>();
            services.AddTransient<IUserStore<GGuser>, CustomUserStore>();
            services.AddTransient<IRoleStore<CustomRole>, CustomRoleStore>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
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
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            using (var scope = app.ApplicationServices.CreateScope())
            {
                CreateSupportedGames(scope.ServiceProvider).Wait();
            }
        }

        private async Task CreateSupportedGames(IServiceProvider serviceProvider)
        {
            var db = serviceProvider.GetRequiredService<ApplicationDbContext>();

            List<string> supportedGames = new() { "Dota", "League of Legends", "Overwatch" };
            var gamesInDb = await db.Games.ToListAsync();

            supportedGames.ForEach(gameTitle =>
            {
                if (!gamesInDb.Any(gameInDb => gameTitle == gameInDb.Title))
                    db.Add(VideoGame.GetGameInstance(gameTitle));
            });

            if (db.ChangeTracker.HasChanges())
                await db.SaveChangesAsync();
        }


    }
}
