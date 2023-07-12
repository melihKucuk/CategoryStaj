using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Category.Entities;


namespace CategoryStaj.Business.ViewModels
{
    public class ProductCreateViewModel
    {
      

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        
    }
}
