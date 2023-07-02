using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.MicrosoftAccount;
using Microsoft.AspNetCore.HttpOverrides;
using MvcTest.Library;
using System.Net;

namespace MvcTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.Configure<ForwardedHeadersOptions>(options =>
            {
                string? proxy = builder.Configuration["TrustedProxyAddress"];
                if (proxy != null)
                {
                    options.KnownProxies.Add(IPAddress.Parse(proxy));
                }
                options.ForwardedHeaders =
                    ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            });

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme =
                    CookieAuthenticationDefaults.AuthenticationScheme;

                //options.DefaultChallengeScheme =
                //    GoogleDefaults.AuthenticationScheme;
                //options.DefaultChallengeScheme =
                //    GoogleAccountDefaults.
                //MicrosoftAccountDefaults.AuthenticationScheme;
            }).AddCookie()
            .AddMicrosoftAccount(microsoftOptions =>
            {
                string? callback = builder.Configuration["Authentication:Microsoft:CallbackPath"];
                if (callback != null)
                {
                    microsoftOptions.CallbackPath = callback;

                }
                //microsoftOptions.
                microsoftOptions.ClientId = builder.Configuration.GetRequiredValue("Authentication:Microsoft:ClientId");
                microsoftOptions.ClientSecret = builder.Configuration.GetRequiredValue("Authentication:Microsoft:ClientSecret");
            })
            .AddGoogle(googleOptions =>
            {
                googleOptions.ClientId = builder.Configuration.GetRequiredValue("Authentication:Google:ClientId");
                googleOptions.ClientSecret = builder.Configuration.GetRequiredValue("Authentication:Google:ClientSecret");
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.Use((context, next) =>
                {
                    // setting correct scheme when reverse proxy is in front of the app
                    // in productionm, only HTTPS should be allowed by the reverse proxy
                    context.Request.Scheme = "https";
                    return next(context);
                });

                app.UseExceptionHandler("/Home/Error");
                app.UseForwardedHeaders();
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            else
            {
                app.UseForwardedHeaders();
            }

            app.UseHttpLogging();
            
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