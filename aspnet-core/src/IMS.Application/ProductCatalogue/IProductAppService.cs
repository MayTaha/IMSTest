using Abp.Application.Services;
using IMS.ProductCatalogue.Dto;
using System.Threading.Tasks;

namespace IMS.ProductCatalogue
{
    public interface IProductAppService : IAsyncCrudAppService<ProductDto, int, PagedProductResultRequestDto, ProductDto, ProductDto>
    {
        Task<ProductDto> CreateOrEditAsync(ProductDto input);
    }
}

