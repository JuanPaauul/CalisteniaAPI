using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalisteniaAPI.Data.Entities
{
    public class CompetitionEntity
    {
        public int Id { get; set; }
        public IEnumerable<ParticipantEntity> Participants { get; set; }
        public DateTime? CompetitionDate { get; set; }
        public int? Reward { get; set; }
        //public List<ParticipantModel> Judges { get; set; }
    }
}
