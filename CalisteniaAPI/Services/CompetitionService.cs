using CalisteniaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalisteniaAPI.Services
{
    public class CompetitionService : ICompetitionsService
    {
        private IList<CompetitionModel> _competitions;
        public CompetitionService()
        {
            _competitions = new List<CompetitionModel>();
            _competitions.Add(new CompetitionModel()
            {
                Id = 1,
                CompetitionDate = new DateTime(2012, 8, 12),
                Reward = 100
            });
            _competitions.Add(new CompetitionModel()
            {
                Id = 2,
                CompetitionDate = new DateTime(2015, 8, 12),
                Reward = 200
            });
            _competitions.Add(new CompetitionModel()
            {
                Id = 3,
                CompetitionDate = new DateTime(2020, 8, 12),
                Reward = 500
            });
        }
        public CompetitionModel CreateCompetition(CompetitionModel competition)
        {
            var lastCompetition = _competitions.OrderByDescending(r => r.Id).FirstOrDefault();
            int nextId = lastCompetition != null ? lastCompetition.Id + 1 : 1;
            competition.Id = nextId;
            _competitions.Add(competition);
            return competition;
        }

        public bool DeleteCompetition(int competitionId)
        {
            var deletedCompetition = _competitions.FirstOrDefault(r => r.Id == competitionId);
            if (deletedCompetition == null)
                return false;
            _competitions.Remove(deletedCompetition);
            return true;
        }

        public CompetitionModel GetCompetition(int competitionId)
        {
            var competition = _competitions.FirstOrDefault(r => r.Id == competitionId);
            if (competition != null)
                return competition;
            throw new Exception("competitions was not found");
        }

        public IEnumerable<CompetitionModel> GetCompetitions()
        {
            return _competitions;
        }
        
        public CompetitionModel UpdateCompetition(int competitionId, CompetitionModel competition)
        {
            var updatedCompetition = _competitions.FirstOrDefault(r => r.Id == competitionId);

            updatedCompetition.CompetitionDate = competition.CompetitionDate ?? updatedCompetition.CompetitionDate;
            updatedCompetition.Reward = competition.Reward ?? updatedCompetition.Reward;

            return updatedCompetition;
        }
    }
}
