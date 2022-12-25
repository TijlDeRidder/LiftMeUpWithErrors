using LiftMeUp2.Areas.Identity.Data;
using LiftMeUp2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace LiftMeUp2.Data
{
    public class SeedDataContext
    {
        public static async void Initialize(IServiceProvider serviceProvider, UserManager<ApplicationUser> userManager)
        {
            using (var context = new ApplicationDbContext2(serviceProvider.GetRequiredService
                                                              <DbContextOptions<ApplicationDbContext2>>()))
            {
                ApplicationUser admin = null;
                ApplicationUser tijl = null;
                context.Database.EnsureCreated();    // Zorg dat de databank bestaat
                if (!context.Users.Any())
                {
                    admin = new ApplicationUser
                    {
                        FirstName = "System",
                        LastName = "Administrator",
                        UserName = "SysAdmin",
                        Email = "System.Administrator@Test.com",
                        EmailConfirmed = true
                    };
                    tijl = new ApplicationUser
                    {
                        FirstName = "Tijl",
                        LastName = "De Ridder",
                        UserName = "TijlDe",
                        Email = "Tijl-de-ridder@hotmail.com",
                        EmailConfirmed = true
                    };
                    userManager.CreateAsync(admin, "Abc!12345");
                    userManager.CreateAsync(tijl, "wxcVBN12345!");

                    context.Roles.AddRange(
                    new IdentityRole { Id = "User", Name = "User", NormalizedName = "USER" },
                    new IdentityRole { Id = "SystemAdministrator", Name = "SystemAdministrator", NormalizedName = "SystemAdministrator"}
                    );
                    context.SaveChanges();
                    context.UserRoles.AddRange
                        (
                            new IdentityUserRole<string> { UserId = admin.Id, RoleId = "SystemAdministrator" },
                            new IdentityUserRole<string> { UserId = admin.Id, RoleId = "User" }
                        );
                    context.SaveChanges();
                    if (!context.Station.Any())
                    {
                        context.Station.AddRange(
                            new Station { stationName = "Elizabeth", hasElevator = true, isAccesible = true },
                            new Station { stationName = "Simonis", hasElevator = true, isAccesible = true }
                            );
                    }
                    if (!context.Lift.Any())      // Voeg enkele liften toe
                    {
                        context.Lift.AddRange
                                (
                                         new Lift { name = "Elizabeth 1", stationId = 1, isWorking = false },
                                         new Lift { name = "Elizabeth 2", stationId = 1, isWorking = true },
                                         new Lift { name = "Simonis 1", stationId = 2, isWorking = true },
                                         new Lift { name = "Simonis 2", stationId = 2, isWorking = false }
                                );
                        if (!context.Melding.Any())
                        {
                            context.Melding.AddRange(
                                new Melding { stationId = 1, liftId = 1, uitleg = "De deur werkt niet meer" },
                                new Melding { stationId = 2, liftId = 4, uitleg = "De knoppen zijn kapot" }
                                );

                        }
                        context.SaveChanges();
                    }

                }
            }
        }

        internal static void Initialize(IApplicationBuilder app)
        {
            throw new NotImplementedException();
        }
    }
}
