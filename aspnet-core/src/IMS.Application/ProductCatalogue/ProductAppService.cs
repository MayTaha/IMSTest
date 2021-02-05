using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.IdentityFramework;
using Abp.Linq.Extensions;
using Abp.MultiTenancy;
using Abp.Runtime.Security;
using IMS.Authorization;
using IMS.Authorization.Roles;
using IMS.Authorization.Users;
using IMS.Editions;
using IMS.ProductCatalogue.Dto;
using Microsoft.AspNetCore.Identity;

namespace IMS.ProductCatalogue
{
    [AbpAuthorize()]
    public class ProductAppService : AsyncCrudAppService<Product, ProductDto, int, PagedProductResultRequestDto, ProductDto, ProductDto>, IProductAppService
    {
        public ProductAppService(
             IRepository<Product, int> repository,
             IAbpZeroDbMigrator abpZeroDbMigrator)
             : base(repository)
        { }
        public async Task<ProductDto> CreateOrEditAsync(ProductDto input)
        {
            if (input.Id == 0)
            {
               return await CreateAsync(input);
            }
            else
            {
                return await UpdateAsync(input);
            }
        }

        protected override IQueryable<Product> CreateFilteredQuery(PagedProductResultRequestDto input)
        {
            Expression<Func<Product, bool>> pQuantity = null;
            if (input.Quantity.HasValue)
            {
                switch (input.QuantityOperator)
                {
                    case QuantityOperator.GreaterThan:
                        pQuantity = x => x.Quantity > input.Quantity;
                        break;
                    case QuantityOperator.LessThan:
                        pQuantity = x => x.Quantity < input.Quantity;
                        break;
                    default:
                        pQuantity = x => x.Quantity == input.Quantity;
                        break;
                }
            }

            return Repository.GetAll()
            .WhereIf(!input.Title.IsNullOrWhiteSpace(), x => x.Title.Contains(input.Title))
            .WhereIf(!input.Code.IsNullOrWhiteSpace(), x => x.Code.Contains(input.Code))
            .WhereIf(input.CreationTime.HasValue, x => x.CreationTime.Date == input.CreationTime.Value.Date)
            .WhereIf(pQuantity != null, pQuantity);
        }
    }
}

