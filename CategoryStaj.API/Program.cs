using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using CategoryStaj.Business.Abstract;
using CategoryStaj.Business.Concrete;
using CategoryStaj.DataAccess.Abstract;
using CategoryStaj.DataAccess.Concrete;
using Microsoft.EntityFrameworkCore;
using CategoryStaj.DataAccess;

namespace CategoryStaj.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();

            builder.Services.AddDbContext<CategoryDbContext>(options =>
                options.UseSqlServer("Server=DESKTOP-NC4RCNO\\SQLEXPRESS; Database=CategoryDb; Trusted_Connection=True; TrustServerCertificate=true;"));

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
