using Demo.Data;
using Demo.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Demo
{
    public class Startup
    {
        // 1. Property to hold our Configuration info
        public IConfiguration Configuration { get; }

        // 2. Add constructor to received the IConfiguration (via magic)
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            // 3. Register the DbContext with the app, using our Connection String
            services.AddDbContext<SchoolDbContext>(options =>
            {
                string connectionString = Configuration.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connectionString);
            });

            // When a controller asks for IStudentRepository,

            // Give them a NotDatabaseRepository!
            // services.AddTransient<IStudentRepository, NotDatabaseStudentRepository>();

            // Give them a DatabaseRepository!
            services.AddTransient<ICourseRepository, DatabaseCourseRepository>();
            services.AddTransient<IStudentRepository, DatabaseStudentRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
