using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TE.NetCore.Models
{
    public class HelpDBContext : DbContext //: IdentityDbContext<ApplicationUser>  //配置Identity框架
    {
        public HelpDBContext() { }

        public HelpDBContext(DbContextOptions<HelpDBContext> options) : base(options)
        { }

        //public DbSet<ApplicationUser> applicationUsers { get; set; }

        public DbSet<Sys_User> sys_User { get; set; }

        //public DbSet<User> users { get; set; }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("");
        //}
    }
}
