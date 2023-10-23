using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.AzureAD.UI;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using testAAD.Data;
using testAAD.Services;

namespace testAAD
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
                        var connectionString = builder.Configuration.GetConnectionString("testAADContextConnection") ?? throw new InvalidOperationException("Connection string 'testAADContextConnection' not found.");

                                    builder.Services.AddDbContext<testAADContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddControllersWithViews();
            builder.Services.AddTransient<IClaimsTransformation, AddRolesClaimsTransformation>();


            builder.Services.AddAuthentication(AzureADDefaults.AuthenticationScheme)
    .AddAzureAD(options => builder.Configuration.Bind("AzureAd", options));

            // Define the route for authentication
            builder.Services.AddAuthorization();


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
                        app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action}"
                , defaults : new { controller = "Home" , action= "Index" });

            app.Run();
        }
    }
}