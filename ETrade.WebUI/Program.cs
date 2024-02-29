using ETrade.Core.Service;
using ETrade.Model.Context;
using ETrade.Service.DbService;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

namespace ETrade.WebUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddMvc();

            builder.Services.AddDbContext<ETradeContext>(options =>options.UseSqlServer(
                "Server=DESKTOP-CF4C8LU\\SQLEXPRESS;Database=ETrade;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"));

            builder.Services.AddScoped(typeof(IDbService<>), typeof(CoreDbService<>)); //Once araci (Interface kullanilir) sonra hedef yazilir.
            //Session kullanimi
            builder.Services.AddSession(options => {
                options.Cookie.Name = "basket";
                options.IdleTimeout=TimeSpan.FromMinutes(30);
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            app.MapAreaControllerRoute(
                name: "Admin",
                areaName:"Admin",
                pattern: "Admin/{Controller=Home}/{Action=Index}/{id?}");

            // Ana proje icin yonlendirme kurali
            app.MapControllerRoute(
                name: "default",
                pattern: "{Controller=Home}/{Action=Index}/{id?}");

            //app.MapRazorPages();

            app.Run();
        }
    }
}
