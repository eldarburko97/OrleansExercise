using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Orleans.Runtime;
using OrleansExercise.Database;
using OrleansExercise.Grains;

namespace OrleansExercise
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(setupAction: c => { c.SwaggerDoc(name: "v1", info: new OpenApiInfo { Title = "OrleansExercise", Version = "v1" }); });
            services.AddDbContext<OrleansDbContext>(optionsAction: options => options.UseSqlServer(connectionString: Configuration.GetConnectionString(name: "DefaultConnection")));
            services.AddAutoMapper(typeof(Startup));
            services.AddTransient<IStudentGrain, StudentGrain>();
            services.AddTransient<IPersistentState<Student>, StudentPersistentState>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(setupAction: c => c.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "OrleansExercise v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(configure: endpoints => { endpoints.MapControllers(); });
        }
    }
}