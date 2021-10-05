using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalisteniaAPI.Data.Entities
{
    public class ParticipantEntity
    {
        public string Names { get; set; }
        public int? BirthYear { get; set; }
        public int? CI { get; set; }
        public string LastNames { get; set; }
        public int? CellphoneNumber { get; set; }
        public int? CompetitionsWon { get; set; }
        public IDictionary<string, string>? CompetitionPlaced { get; set; }
        public ParticipantEntity()
        {
            CompetitionPlaced = new Dictionary<string, string>();
        }
    }
}
