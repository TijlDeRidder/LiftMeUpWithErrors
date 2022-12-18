using LiftMeUp2.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace LiftMeUp2.Data
{
    public class SeedDataContext
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new LiftMeUp2Context(serviceProvider.GetRequiredService
                                                              <DbContextOptions<LiftMeUp2Context>>()))
            {
                context.Database.EnsureCreated();    // Zorg dat de databank bestaat

                if (!context.Station.Any())
                {
                    context.Station.AddRange(
                        new Station { stationName = "Elizabeth", hasElevator = true, isAccesible = true },
                        new Station { stationName= "Simonis", hasElevator =true, isAccesible = true }
                        );
                }
                if (!context.Lift.Any())      // Voeg enkele liften toe
                {
                    context.Lift.AddRange
                            (
                                     new Lift { name = "Elizabeth 1", stationId = 1, isWorking = false },
                                     new Lift { name = "Elizabeth 2", stationId = 1, isWorking = true},
                                     new Lift { name = "Simonis 1", stationId = 2, isWorking = true},
                                     new Lift { name = "Simonis 2", stationId = 2, isWorking = false}
                            );
                    if (!context.Melding.Any())
                    {
                        context.Melding.AddRange(
                            new Melding { stationId = 1, liftId = 1,uitleg = "De deur werkt niet meer" },
                            new Melding { stationId = 2, liftId = 4, uitleg ="De knoppen zijn kapot" }
                            );
                    }
                    context.SaveChanges();
                }
               
            }
        }
    }
}
