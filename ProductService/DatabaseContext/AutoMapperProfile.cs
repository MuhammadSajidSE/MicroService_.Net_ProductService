using AutoMapper;
using ProductService.DTO;
using ProductService.Models;

namespace ProductService.DatabaseContext
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Productscs, ProductDTO>().ReverseMap();
        }
    }
}
