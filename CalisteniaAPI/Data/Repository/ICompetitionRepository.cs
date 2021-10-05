using CalisteniaAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalisteniaAPI.Data.Repository
{
    public interface ICompetitionRepository
    {

        //Competition

        IEnumerable<CompetitionEntity> GetCompetitions(string direction, string orderBy);
        CompetitionEntity GetCompetition(int competitionId);
        CompetitionEntity CreateCompetition(CompetitionEntity competition);
        CompetitionEntity UpdateCompetition(int competitionId, CompetitionEntity competition);
        void DeleteCompetition(int competitionId);

        //Participants

        IEnumerable<ParticipantEntity> GetParticipants(int competitionId, string direction, string orderBy);
        ParticipantEntity GetParticipant(int competitionId);
        ParticipantEntity CreateParticipant(ParticipantEntity competition);
        ParticipantEntity UpdateParticipant(int competitionId, ParticipantEntity competition);
        void DeleteParticipant(int competitionId);
    }
}
