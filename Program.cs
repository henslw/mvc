using ContosoUniversity.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Policy;

namespace ContosoUniversity
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // not in the dykstra tutorial, this is from following url location
            // https://learn.microsoft.com/en-us/aspnet/core/fundamentals/servers/kestrel/options?view=aspnetcore-7.0
            // example of configuring the kestrel web server
            builder.WebHost.ConfigureKestrel(serverOptions =>
            {
                // example parameters that can be set
                serverOptions.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(2);
                serverOptions.Limits.MaxConcurrentConnections = 100;
                serverOptions.Limits.MaxConcurrentUpgradedConnections = 100;
            });

            // verbatim code from razor pages version can be used in mvc version
            builder.Services.AddDbContext<SchoolContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolContext") ??
                throw new InvalidOperationException("Connection string 'SchoolContext' not found.")));

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();
            // end verbatim code

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

            else
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }


            // from dykstra mvc tutorial
            // expanded using block with embedded exception handler
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context = services.GetRequiredService<SchoolContext>();
                    context.Database.EnsureCreated();
                    DbInitializer.Initialize(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }

            //////////////////////////////////////////////////////////////////////////
            ///// Origal genreated code
            app.UseHttpsRedirection();
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