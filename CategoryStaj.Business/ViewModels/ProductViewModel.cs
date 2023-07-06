using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Category.Entities;
using System.Text.Json.Serialization;


namespace CategoryStaj.Business.ViewModels
{
    public class ProductViewModel : Category.Entities.Product
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        [JsonIgnore]
        public CategoryViewModel Category { get; set; }
    }
}
