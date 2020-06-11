using System.Text;
using IdentityDemo.Data;
using IdentityDemo.Models.Identity;
using IdentityDemo.Models.Interfaces;
using IdentityDemo.Models.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace IdentityDemo
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // this will allow us to use the Controllers for our API calls without the req of razor pages or views
            services.AddControllers();

            services.AddDbContext<BlogDbContext>(options =>
            {
                //Install-Package Microsoft.EntityFrameworkCore.SqlServer
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddDbContext<UsersDbContext>(options =>
            {
                //Install-Package Microsoft.EntityFrameworkCore.SqlServer
                options.UseSqlServer(Configuration.GetConnectionString("UsersConnection"));
            });

            services.AddIdentity<BlogUser, IdentityRole>()
                .AddEntityFrameworkStores<UsersDbContext>()
                ;

            services
                .AddAuthentication(options =>
                {
                    // Avoid "challenging" user by sending to login page
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;

                    var secret = Configuration["JWT:Secret"];
                    var secretBytes = Encoding.UTF8.GetBytes(secret);
                    var signingKey = new SymmetricSecurityKey(secretBytes);

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = signingKey,
                        ValidateIssuer = false,
                        ValidateAudience = false,
                    };
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("posts.create",
                    policy => policy.RequireClaim("permissions", "create"));
                options.AddPolicy("posts.update",
                    policy => policy.RequireClaim("permissions", "update"));
                options.AddPolicy("posts.delete",
                    policy => policy.RequireClaim("permissions", "delete"));
            });

            services.AddTransient<IPostManager, PostService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                // using the default is fine and a nice shortcut
                endpoints.MapDefaultControllerRoute();
            });

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetService<UserManager<BlogUser>>();
                // SeedUsersDatabase(userManager);
            }
        }

        private async void SeedUsersDatabase(UserManager<BlogUser> userManager)
        {
            var hasUsers = await userManager.Users.AnyAsync();
            if (hasUsers)
            {
                return;
            }

            // TODO: Add roles, if not already seeded in migrations
            // TODO: Add intial admin user with known password
            // userManager.CreateAsync(new BlogUser { ... }, "p@ssw0rd");
            // TODO: Assign admin user to admin role
            // userManager.AddToRoleAsync(user, "admin");
        }
    }
}
