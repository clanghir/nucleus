using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Nucleus.Configuration;

namespace Nucleus.Web.Host.Startup
{
    [DependsOn(
       typeof(NucleusWebCoreModule))]
    public class NucleusWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public NucleusWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(NucleusWebHostModule).GetAssembly());
        }
    }
}
