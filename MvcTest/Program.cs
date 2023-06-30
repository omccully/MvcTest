using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.MicrosoftAccount;
using Microsoft.AspNetCore.HttpOverrides;
using MvcTest.Library;

namespace MvcTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            builder.Services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders =
                    ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            });

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme =
                    CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme =
                    MicrosoftAccountDefaults.AuthenticationScheme;
            }).AddCookie().AddMicrosoftAccount(microsoftOptions =>
            {
                string? callback = builder.Configuration["Authentication:Microsoft:CallbackPath"];
                if (callback != null)
                {
                    microsoftOptions.CallbackPath = callback;
                    
                }
                //microsoftOptions.
                microsoftOptions.ClientId = builder.Configuration.GetRequiredValue("Authentication:Microsoft:ClientId");
                microsoftOptions.ClientSecret = builder.Configuration.GetRequiredValue("Authentication:Microsoft:ClientSecret");
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseForwardedHeaders();
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            else
            {
                app.UseForwardedHeaders();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}