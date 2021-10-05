using CalisteniaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalisteniaAPI.Services
{
    public interface IParticipantsService
    {
        IEnumerable<ParticipantModel> GetParticipants(int competitionId,string direction, string orderBy);
        ParticipantModel GetParticipant(int competitionId, int participantCI);
        ParticipantModel CreateParticipant(ParticipantModel competition);
        ParticipantModel UpdateParticipant(int competitionId, int participantCI, ParticipantModel competition);
        void DeleteParticipant(int competitionId, int participantCI);
    }
}
