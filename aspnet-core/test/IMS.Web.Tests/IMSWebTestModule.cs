﻿using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using IMS.EntityFrameworkCore;
using IMS.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace IMS.Web.Tests
{
    [DependsOn(
        typeof(IMSWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class IMSWebTestModule : AbpModule
    {
        public IMSWebTestModule(IMSEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(IMSWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(IMSWebMvcModule).Assembly);
        }
    }
}