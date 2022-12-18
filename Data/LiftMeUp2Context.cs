using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LiftMeUp2.Models;

namespace LiftMeUp2.Data
{
    public class LiftMeUp2Context : DbContext
    {
        public LiftMeUp2Context (DbContextOptions<LiftMeUp2Context> options)
            : base(options)
        {
        }

        public DbSet<LiftMeUp2.Models.Lift> Lift { get; set; } = default!;

        public DbSet<LiftMeUp2.Models.Station> Station { get; set; }

        public DbSet<LiftMeUp2.Models.Melding> Melding { get; set; }
    }
}
