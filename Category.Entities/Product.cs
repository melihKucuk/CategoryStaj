using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Category.Entities
{
    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        // Ürünün hangi kategoriye ait olduğunu belirtmek için 
        public int CategoryId { get; set; }

        // Kategori ile Ürün arasındaki ilişkiyi temsil eden Kategori nesnesini ekleyebilirsiniz.
        public Category Category { get; set; }
    }

}
