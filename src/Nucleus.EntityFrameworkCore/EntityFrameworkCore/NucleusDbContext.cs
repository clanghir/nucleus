using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Nucleus.Authorization.Roles;
using Nucleus.Authorization.Users;
using Nucleus.MultiTenancy;

namespace Nucleus.EntityFrameworkCore
{
    public class NucleusDbContext : AbpZeroDbContext<Tenant, Role, User, NucleusDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public NucleusDbContext(DbContextOptions<NucleusDbContext> options)
            : base(options)
        {
        }
    }
}
