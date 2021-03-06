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
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
                       .EnableSensitiveDataLogging());

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
            services.AddScoped<IModelService<Discussion>, DiscussionService>();
            services.AddScoped<IModelService<Task>, TaskService>();
            services.AddScoped<IModelService<User>, UserService>();
            services.AddScoped<IModelService<Alert>, AlertService>();
            services.AddScoped<IModelService<PermissionGroup>, PermissionGroupService>();
            services.AddScoped<IModelService<Permission>, PermissionService>();
            services.AddScoped<IModelService<PriorityType>, PriorityTypeService>();
            services.AddScoped<IModelService<Project>, ProjectService>();
            services.AddScoped<IModelService<Settings>, SettingsService>();
            services.AddScoped<IModelService<StatusType>, StatusTypeService>();
            services.AddScoped<IModelService<TaskRevision>, TaskRevisionService>();
            services.AddScoped<IModelService<TaskStatusCategory>, TaskStatusCategoryService>();
            services.AddScoped<IModelService<TeamMessage>, TeamMessageService>();
            services.AddScoped<IModelService<Team>, TeamService>();
            services.AddScoped<IModelService<UserPermissionOverride>, UserPermissionOverrideService>();
            services.AddDbContext<QContext>(options => options.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
           
            
            services.AddControllersWithViews().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
            });
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
