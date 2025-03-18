using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebAppCoreProduct.Services;

namespace WebAppCoreProduct 
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // object manages application config
            var builder = WebApplication.CreateBuilder(args);

            // add Razor Pages services to the container
            builder.Services.AddRazorPages();
            // add services to the container
            builder.Services.AddScoped<IDiscountService, DiscountService>();

            // application object for processing HTTP requests
            var app = builder.Build();

            // Configure the HTTP request pipeline (Middleware) (request processing pipeline)
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");

                // The default HSTS value is 30 days
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            // Razor Pages end points for IEndpointRouteBuilder
            app.MapRazorPages();

            // starts application for listening HTTP requests
            app.Run();
        }
    }
}
