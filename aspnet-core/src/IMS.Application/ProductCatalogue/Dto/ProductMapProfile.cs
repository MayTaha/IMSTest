using AutoMapper;
using IMS.Authorization.Users;

namespace IMS.ProductCatalogue.Dto
{
    public class ProductMapProfile : Profile
    {
        public ProductMapProfile()
        {
            CreateMap<ProductDto, Product>().ReverseMap();
        }
    }
}
