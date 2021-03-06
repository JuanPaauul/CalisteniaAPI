using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CalisteniaAPI.Models
{
    public class CompetitionModel
    {
        public int Id { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime? CompetitionDate { get; set; }
        [Required]
        public int? Reward { get; set; }
        public IEnumerable<ParticipantModel> Participants { get; set; }
        //public List<ParticipantModel> Judges { get; set; }
    }
}
