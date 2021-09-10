using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Quipu.Core.DAL;
using Microsoft.Extensions.Configuration;
using Quipu.Core.BLL;
using Quipu.Core.DomainModel;

namespace Quipu.Core
{
    public class Startup
    {
        private IConfiguration Configuration;
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<QContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("*")
                                             .WithHeaders("*")
                                             .WithMethods("*");
                                  });
            });            

            //Model Service
            services.AddScoped<IModelService<Alert>, AlertService>();
            services.AddScoped<IModelService<Change>, ChangeService>();
            services.AddScoped<IModelService<Discussion>, DiscussionService>();
            services.AddScoped<IModelService<PermissionGroup>, PermissionGroupService>();
            services.AddScoped<IModelService<Permission>, PermissionService>();
            services.AddScoped<IModelService<Settings>, SettingsService>();
            services.AddScoped<IModelService<Task>, TaskService>();
            services.AddScoped<IModelService<UserPermissionOverride>, UserPermissionOverrideService>();
            services.AddScoped<IModelService<User>, UserService>();
            services.AddDbContext<QContext>(options => options.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllersWithViews().AddNewtonsoftJson(options =>
                                                                 options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers()
                .RequireCors(MyAllowSpecificOrigins);
            });
        }
    }
}
