using System.Linq;
using Microsoft.EntityFrameworkCore;
using Abp.MultiTenancy;
using IMS.Editions;
using IMS.MultiTenancy;
using IMS.ProductCatalogue;

namespace IMS.EntityFrameworkCore.Seed.Products
{
    public class DefaultProductsBuilder
    {
        private readonly IMSDbContext _context;

        public DefaultProductsBuilder(IMSDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateDefaultProducts();
        }

        private void CreateDefaultProducts()
        {
            // Default tenant

            var hasProducts = _context.Products.IgnoreQueryFilters().Any();
            if (!hasProducts)
            {
                for (int i = 1; i <= 12; i++)
                {
                    var title = $"Product{i.ToString("00")}";
                    var code = $"{title}Code";
                    var quantity = i * 2;

                    _context.Products.Add(new Product
                    {
                        Title = title,
                        Code = code,
                        Quantity = quantity
                    });
                }
                _context.SaveChanges();
            }
        }
    }
}
