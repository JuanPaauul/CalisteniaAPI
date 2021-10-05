using CalisteniaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalisteniaAPI.Services
{
    public interface ICompetitionsService
    {
        IEnumerable<CompetitionModel> GetCompetitions(string direction, string orderBy);
        CompetitionModel GetCompetition(int competitionId);
        CompetitionModel CreateCompetition(CompetitionModel competition);
        CompetitionModel UpdateCompetition(int competitionId, CompetitionModel competition);
        void DeleteCompetition(int competitionId);
    }
}
