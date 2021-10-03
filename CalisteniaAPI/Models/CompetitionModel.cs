using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalisteniaAPI.Models
{
    public class CompetitionModel
    {
        public int Id { get; set; }
        //public List<ParticipantModel> Participants { get; set; }
        public DateTime? CompetitionDate { get; set; }
        public int? Reward { get; set; }
        //public List<ParticipantModel> Judges { get; set; }
    }
}
