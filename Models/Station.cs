using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace LiftMeUp2.Models
{
    public class Station
    {
        public static List<Station> Stations { get; set; }
        [Required]
        public int stationId { get; set; }
        [Required]
        [Display(Name = "Naam")]
        public string stationName { get; set; }
        [Required]
        [Display(Name = "Is Toegankelijk")]
        public bool isAccesible { get; set; }
        [Required]
        [Display(Name = "Heeft Lift")]
        public bool hasElevator { get; set; }
        [Required]
        public bool isDeleted { get; set; } = false;
    }

}

