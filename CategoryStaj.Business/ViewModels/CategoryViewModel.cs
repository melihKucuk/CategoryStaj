using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Category.Entities;

namespace CategoryStaj.Business.ViewModels
{
    public class CategoryViewModel : Category.Entities.Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<ProductViewModel> Products { get; set; }
    }
}
