using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Category.Entities;

namespace CategoryStaj.Business.ViewModels
{
    public class CategoryListViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<ProductListViewModel> Products { get; set; }
    }
}
