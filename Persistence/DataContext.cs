using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence;
public class DataContext : IdentityDbContext<AppUser>
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Activity> activities { get; set; }
    public DbSet<AppUserActivity> appUserActivities { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<AppUserActivity>(x => x.HasKey(aa => new { aa.AppUSerId, aa.ActiviyId }));
        builder.Entity<AppUserActivity>().HasOne(x=>x.AppUser).WithMany(x=>x.Activities).HasForeignKey(x=>x.AppUSerId);
        builder.Entity<AppUserActivity>().HasOne(x=>x.Activity).WithMany(x=>x.AppUsers).HasForeignKey(x=>x.ActiviyId);
    }
}
