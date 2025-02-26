using Assignment.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Assignment
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Sử dụng Configuration để lấy chuỗi kết nối và cấu hình DbContext
			builder.Services.AddDbContext<FunewsManagementContext>(options =>
				options.UseSqlServer(builder.Configuration.GetConnectionString("MyDB")));
			// Thêm dịch vụ controller, session và cache
			builder.Services.AddControllersWithViews();
			builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
			.AddCookie(options =>
			{
				options.LoginPath = "/Account/Login"; // Trang login
				options.LogoutPath = "/Account/Logout"; // Trang logout
				options.AccessDeniedPath = "/Account/AccessDenied"; // Khi không đủ quyền
			});

			builder.Services.AddAuthorization();
			builder.Services.AddSession();
			
			var app = builder.Build();

			// Cấu hình HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
			}

			app.UseStaticFiles();
			app.UseSession();
			app.UseRouting();

			// 🔹 Quan trọng: Đặt `UseAuthentication()` trước `UseAuthorization()`
			app.UseAuthentication();
			app.UseAuthorization();


			

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}
