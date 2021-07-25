using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NAS.Data.Entities;
using NAS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NAS.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
        public DbSet<NAS_Empty> NASEmptys { get; set; }
        public DbSet<HardDrive> HardDrives { get; set; }
        public DbSet<BasicCost> BasicCosts { get; set; }

        public DbSet<Comision> Comisions { get; set; }
        public DbSet<Price> Prices { get; set; }

        public DbSet<PriceHardDrive> PriceHardDrives { get; set; }
    }
}
