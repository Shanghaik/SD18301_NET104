namespace AppMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Thêm Services để cho phép sử dụng Session
            builder.Services.AddSession(option =>
            {
                option.IdleTimeout = TimeSpan.FromSeconds(15); // Set thời gian timeout của Session là 5 giây
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute( // Đường dẫn default của chương trình
                name: "default",
                pattern: "{controller=User}/{action=Login}");

            app.Run();
        }
    }
}