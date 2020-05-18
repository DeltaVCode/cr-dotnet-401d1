using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Demo.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // var app = express();

            // app.use(cors());
            // app.UseCors();

            // app.use(errorHandler)
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Serve from wwwroot
            // app.use(express.static('wwwroot'))
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}");

                //endpoints.MapGet("/", async context =>
                //{
                //    // ?? = null coalescing operator
                //    // var message = req.query['message'] || 'Hello';

                //    string message = context.Request.Query["message"].FirstOrDefault() ?? "Hello";

                //    await context.Response.WriteAsync($"{message} World!");
                //});
            });
        }
    }
}
