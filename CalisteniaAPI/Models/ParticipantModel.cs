using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CalisteniaAPI.Models
{
    public class ParticipantModel
    {
        [Required]
        public string Names { get; set; }
        public int? BirthYear { get; set; }
        [Required]
        public int? CI { get; set; }
        [Required]
        public string LastNames { get; set; }
        public int? CellphoneNumber { get; set; }
        public int? CompetitionsWon { get; set; }
        public IDictionary<string, string> CompetitionPlaced { get; set; }
        public ParticipantModel()
        {
            CompetitionPlaced = new Dictionary<string, string>();
        }
    }
}
