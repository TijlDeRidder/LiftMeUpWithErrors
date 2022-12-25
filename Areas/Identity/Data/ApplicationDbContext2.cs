using LiftMeUp2.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LiftMeUp2.Data;

public class ApplicationDbContext2 : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext2(DbContextOptions<ApplicationDbContext2> options)
        : base(options)
    {
    }
    public DbSet<LiftMeUp2.Models.Lift> Lift { get; set; } = default!;

    public DbSet<LiftMeUp2.Models.Station> Station { get; set; }

    public DbSet<LiftMeUp2.Models.Melding> Melding { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);


        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
