namespace Assignment1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

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

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
              name: "index",
              pattern: "/",
             defaults: new { controller = "Products", action = "Index" });

            app.MapControllerRoute(
              name: "index",
              pattern : "AmicusProducts",
             defaults: new { controller = "Products", action = "Index" });

            app.MapControllerRoute(
              name: "index",
              pattern: "AmicusProducts/Index",
             defaults: new { controller = "Products", action = "Index" });

            app.MapControllerRoute(
              name: "details",
              pattern: "AmicusProducts/Details/{id}",
             defaults: new { controller = "Products", action = "Details" });

            app.MapControllerRoute(
                name : "default",
                pattern : "{controller = Products}/{action}/{id?}",
                defaults : new {controller = "Products", action = "Index"}
                );

            app.Run();
        }
    }
}