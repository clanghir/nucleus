using System;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.AspNetCore.SignalR;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.Configuration;
using Nucleus.Authentication.JwtBearer;
using Nucleus.Configuration;
using Nucleus.EntityFrameworkCore;
using Abp.Runtime.Caching.Redis;
using Abp.Threading;
using System.Net;
using Castle.Core.Logging;

namespace Nucleus
{
    [DependsOn(
         typeof(NucleusApplicationModule),
         typeof(NucleusEntityFrameworkModule),
         typeof(AbpAspNetCoreModule)
        ,typeof(AbpAspNetCoreSignalRModule),
        typeof(AbpRedisCacheModule)
     )]
    public class NucleusWebCoreModule : AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;
        public ILogger Logger { get; set; }

        public NucleusWebCoreModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
            Logger = NullLogger.Instance;
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                NucleusConsts.ConnectionStringName
            );

            Configuration.Caching.UseRedis();


            //Configuration.Caching.UseRedis(options =>
           // {
                //var connectionString = _appConfiguration["Abp:RedisCache:ConnectionString"];
               // var connectionString = _appConfiguration.GetConnectionString("Redis");
               // Logger.Info("Redis-Connection: " + connectionString);

               //options.ConnectionString = connectionString;
                /*
                if (connectionString != null && connectionString != "localhost")
                {
                    options.ConnectionString = AsyncHelper.RunSync(() => Dns.GetHostAddressesAsync(connectionString))[0].ToString();
                }*/
            //});

            // Use database for language management
            Configuration.Modules.Zero().LanguageManagement.EnableDbLocalization();

            Configuration.Modules.AbpAspNetCore()
                 .CreateControllersForAppServices(
                     typeof(NucleusApplicationModule).GetAssembly()
                 );

            ConfigureTokenAuth();
        }

        private void ConfigureTokenAuth()
        {
            IocManager.Register<TokenAuthConfiguration>();
            var tokenAuthConfig = IocManager.Resolve<TokenAuthConfiguration>();

            tokenAuthConfig.SecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_appConfiguration["Authentication:JwtBearer:SecurityKey"]));
            tokenAuthConfig.Issuer = _appConfiguration["Authentication:JwtBearer:Issuer"];
            tokenAuthConfig.Audience = _appConfiguration["Authentication:JwtBearer:Audience"];
            tokenAuthConfig.SigningCredentials = new SigningCredentials(tokenAuthConfig.SecurityKey, SecurityAlgorithms.HmacSha256);
            tokenAuthConfig.Expiration = TimeSpan.FromDays(1);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(NucleusWebCoreModule).GetAssembly());
        }
    }
}
