using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using CategoryStaj.Business.Abstract;
using CategoryStaj.Business.Concrete;
using CategoryStaj.DataAccess.Abstract;
using CategoryStaj.DataAccess.Concrete;
using Microsoft.EntityFrameworkCore;
using CategoryStaj.DataAccess;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Caching.Memory;
using AutoMapper;
using CategoryStaj.Business.Mappings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using CategoryStaj.API.Log;

namespace CategoryStaj.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<ICategoryService, CategoryManager>();
            builder.Services.AddScoped<IProductService, ProductManager>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();

            builder.Services.AddDbContext<CategoryDbContext>(options =>
            {
                var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connectionString);
            });

            builder.Services.AddMemoryCache(); // Bellek önbelleðini ekleyin

            builder.Services.AddAutoMapper(typeof(MappingProfile)); // AutoMapper

            builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
                options.InvalidModelStateResponseFactory = context =>
                {
                    var responseObj = new
                    {
                        Path = context.HttpContext.Request.Path.ToString(),
                        Method = context.HttpContext.Request.Method,
                        Controller = (context.ActionDescriptor as ControllerActionDescriptor)?.ControllerName,
                        Action = (context.ActionDescriptor as ControllerActionDescriptor)?.ActionName,
                        Errors = context.ModelState.Keys.Select(k => new
                        {
                            Field = k,
                            Messages = context.ModelState[k]?.Errors.Select(e => e.ErrorMessage)
                        })
                    };
                    return new BadRequestObjectResult(responseObj);
                };
            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication(); 
            app.UseAuthorization();
            app.UseLogging("D:\\VSRepos\\CategoryStaj\\CategoryStaj.API\\Log\\log.txt");



            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
