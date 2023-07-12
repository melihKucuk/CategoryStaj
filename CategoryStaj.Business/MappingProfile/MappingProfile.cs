using AutoMapper;
using Category.Entities;
using CategoryStaj.Business.ViewModels;

namespace CategoryStaj.Business.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductListViewModel>();
            CreateMap<Category.Entities.Category, CategoryListViewModel>();
        }
    }
}
