using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CategoryStaj.Business.Abstract;
using CategoryStaj.Business.Concrete;
using CategoryStaj.DataAccess;
using CategoryStaj.DataAccess.Concrete;
using CategoryStaj.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;

namespace CategoryStaj.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Dependency Injection için gerekli bağımlılıkların eklendiği yer
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddDbContext<CategoryDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("Server=DESKTOP-NC4RCNO\\SQLEXPRESS;Database=CategoryDb;Trusted_Connection=True;TrustServerCertificate=true;")));

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
