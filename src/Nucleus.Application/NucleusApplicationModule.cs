using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Nucleus.Authorization;

namespace Nucleus
{
    [DependsOn(
        typeof(NucleusCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class NucleusApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<NucleusAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(NucleusApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
