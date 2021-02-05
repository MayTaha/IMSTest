using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using IMS.Configuration;
using IMS.Web;

namespace IMS.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class IMSDbContextFactory : IDesignTimeDbContextFactory<IMSDbContext>
    {
        public IMSDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<IMSDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            IMSDbContextConfigurer.Configure(builder, configuration.GetConnectionString(IMSConsts.ConnectionStringName));

            return new IMSDbContext(builder.Options);
        }
    }
}
