using DomainManagement.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainManagement.Identity.DbContext
{
    public class DomainManagementIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public DomainManagementIdentityDbContext(DbContextOptions<DomainManagementIdentityDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(DomainManagementIdentityDbContext).Assembly);
        }
    }
}
