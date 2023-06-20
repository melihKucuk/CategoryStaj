using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using CategoryStaj.Business.Abstract;
using CategoryStaj.Business.Concrete;
using CategoryStaj.DataAccess;
using CategoryStaj.DataAccess.Concrete;
using CategoryStaj.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var services = builder.Services;

// Add services to the container.
services.AddControllers();
services.AddScoped<IProductService, ProductService>();
services.AddScoped<IProductRepository, ProductRepository>();
services.AddDbContext<CategoryDbContext>(options =>
    options.UseSqlServer(
        configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
