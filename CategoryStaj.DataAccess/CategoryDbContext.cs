
using DocumentFormat.OpenXml.Drawing.Diagrams;
using Microsoft.EntityFrameworkCore;
using Category.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unipluss.Sign.ExternalContract.Entities;

namespace CategoryStaj.DataAccess
{
    public class CategoryDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DESKTOP-NC4RCNO\\SQLEXPRESS;Database=CategoryDb;Trusted_Connection=True;TrustServerCertificate=true;");
        }

        public DbSet<Category.Entities.Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
