using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using IMS.Authorization.Roles;
using IMS.Authorization.Users;
using IMS.MultiTenancy;
using IMS.ProductCatalogue;

namespace IMS.EntityFrameworkCore
{
    public class IMSDbContext : AbpZeroDbContext<Tenant, Role, User, IMSDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Product> Products { get; set; }
        public IMSDbContext(DbContextOptions<IMSDbContext> options)
            : base(options)
        { }
    }
}
