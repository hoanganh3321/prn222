namespace DemoASP.NETCoreMVC
{
    using DemoASP.NETCoreMVC.Models;
    using Microsoft.EntityFrameworkCore;

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Sử dụng Configuration để lấy chuỗi kết nối và cấu hình DbContext
            builder.Services.AddDbContext<Banhang3Context>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("MyDB")));

            // Thêm dịch vụ controller
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Cấu hình HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
