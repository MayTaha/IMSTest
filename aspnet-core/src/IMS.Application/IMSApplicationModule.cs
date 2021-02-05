using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using IMS.Authorization;

namespace IMS
{
    [DependsOn(
        typeof(IMSCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class IMSApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<IMSAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(IMSApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
