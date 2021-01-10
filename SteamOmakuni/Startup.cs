using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace SteamOmakuni
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            // DB接続文字列をグローバル化
            GlobalConfigure.DbConnStr = Configuration.GetValue<string>("ConnectionStrings:MySQLConnection");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "app",
                    pattern: "app/{id}",
                    defaults: new { controller = "App", action = "Index" });

                endpoints.MapControllerRoute(
                    name: "developer",
                    pattern: "developer/{name}",
                    defaults: new { controller = "Company", action = "Developer" });

                endpoints.MapControllerRoute(
                    name: "publisher",
                    pattern: "publisher/{name}",
                    defaults: new { controller = "Company", action = "Publisher" });
            });
        }
    }

    /// <summary>グローバルに参照可能な設定値クラス</summary>
    public class GlobalConfigure
    {
        /// <summary>DB接続文字列</summary>
        public static string DbConnStr { get; internal set; }
    }
}