using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using API.Domain.Models;
using API.Domain.Repositories;
using API.Domain.Services;
using API.DTO;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddEntityFrameworkSqlServer().AddDbContext<ApplicationContext>();

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            services.AddScoped<IDepartmentRepository, DepartmentRepository>();

            services.AddScoped<IEmployeeService, EmployeeService>();

            services.AddScoped<IDepartmentService, DepartmentService>();

            services.AddAutoMapper(typeof(AutoMapperConfig));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API",
                    Version = "v1"
                });
            });

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder
                    .SetIsOriginAllowed((host) => true)
                    .AllowAnyMethod()
                    .AllowCredentials()
                    .AllowAnyHeader()
                    ;
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
            }
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
