using CalisteniaAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalisteniaAPI.Data.Repository
{
    public class CompetitionRepository : ICompetitionRepository
    {
        private IList<CompetitionEntity> _competitions;
        private IList<ParticipantEntity> _participants;
        public CompetitionRepository()
        {
            _competitions = new List<CompetitionEntity>();
            _competitions.Add(new CompetitionEntity()
            {
                Id = 1,
                CompetitionDate = new DateTime(2012, 8, 12),
                Reward = 100
            });
            _competitions.Add(new CompetitionEntity()
            {
                Id = 2,
                CompetitionDate = new DateTime(2015, 8, 12),
                Reward = 200
            });
            _competitions.Add(new CompetitionEntity()
            {
                Id = 3,
                CompetitionDate = new DateTime(2020, 8, 12),
                Reward = 500
            });
            _competitions.Add(new CompetitionEntity()
            {
                Id = 4,
                CompetitionDate = new DateTime(2021, 10, 4),
                Reward = 0
            });
            _competitions.Add(new CompetitionEntity()
            {
                Id = 5,
                CompetitionDate = new DateTime(2021, 10, 4),
                Reward = 0
            });
            _competitions.Add(new CompetitionEntity()
            {
                Id = 6,
                CompetitionDate = new DateTime(2021, 10, 4),
                Reward = 0
            });
            _competitions.Add(new CompetitionEntity()
            {
                Id = 7,
                CompetitionDate = new DateTime(2021, 10, 4),
                Reward = 0
            });
            _competitions.Add(new CompetitionEntity()
            {
                Id = 8,
                CompetitionDate = new DateTime(2021, 10, 4),
                Reward = 0
            });
            _participants = new List<ParticipantEntity>();
            _participants.Add(new ParticipantEntity()
            {
                Names = "Pedro",
                LastNames = "Perez",
                BirthYear = 2000,
                CI = 3103875,
                CellphoneNumber = 75989769,
                CompetitionsWon = 1,
                CompetitionPlaced = { { "2", "2nd" }, { "3", "1st" }, { "4", "1st" }, { "6", "1st" } }
            });
            _participants.Add(new ParticipantEntity()
            {
                Names = "Juan",
                LastNames = "Lopes",
                BirthYear = 2001,
                CI = 3458267,
                CellphoneNumber = 65874589,
                CompetitionsWon = 1,
                CompetitionPlaced = { { "1", "2nd" }, { "2", "1st" }, { "7", "1st" }, { "8", "1st" } }
            });
            _participants.Add(new ParticipantEntity()
            {
                Names = "Maria",
                LastNames = "La Fuente",
                BirthYear = 2000,
                CI = 6584157,
                CellphoneNumber = 65897694,
                CompetitionsWon = 1,
                CompetitionPlaced = { { "1", "1st" }, { "4", "3rd" }, { "5", "1st" }, { "6", "2nd" } }
            });
            _participants.Add(new ParticipantEntity()
            {
                Names = "Jonah",
                LastNames = "Morales",
                BirthYear = 1991,
                CI = 6584167,
                CellphoneNumber = 64512348,
                CompetitionsWon = 1,
                CompetitionPlaced = { { "1", "3rd" }, { "2", "3rd" }, { "3", "2nd" }, { "5", "2nd" } }
            });
        }
        public CompetitionEntity CreateCompetition(CompetitionEntity competition)
        {
            var lastCompetition = _competitions.OrderByDescending(r => r.Id).FirstOrDefault();
            int nextId = lastCompetition != null ? lastCompetition.Id + 1 : 1;
            competition.Id = nextId;
            _competitions.Add(competition);
            return competition;
        }

        public ParticipantEntity CreateParticipant(ParticipantEntity participant)
        {
            _participants.Add(participant);
            return participant;
        }

        public void DeleteCompetition(int competitionId)
        {
            var deletedCompetition = _competitions.SingleOrDefault(r => r.Id == competitionId);
            _competitions.Remove(deletedCompetition);
        }

        public void DeleteParticipant(int participantCI)
        {
            var deletedParticipants = _participants.SingleOrDefault(r => r.CI == participantCI);
            _participants.Remove(deletedParticipants);
        }

        public CompetitionEntity GetCompetition(int competitionId)
        {
            var competition = _competitions.SingleOrDefault(r => r.Id == competitionId);
            var participants = _participants.Where(r => r.CompetitionPlaced.ContainsKey(competitionId.ToString()));
            competition.Participants = participants;
            return competition;
        }

        public IEnumerable<CompetitionEntity> GetCompetitions(string direction, string orderBy)
        {
            IEnumerable<CompetitionEntity> competitions;
            switch (orderBy.ToLower())
            {
                case "id":
                    competitions = direction == "descending" ? _competitions.OrderByDescending(r => r.Id) : _competitions.OrderBy(r => r.Id);
                    break;
                case "competitiondate":
                    competitions = direction == "descending" ? _competitions.OrderByDescending(r => r.CompetitionDate) : _competitions.OrderBy(r => r.CompetitionDate);
                    break;
                case "reward":
                    competitions = direction == "descending" ? _competitions.OrderByDescending(r => r.Reward) : _competitions.OrderBy(r => r.Reward);
                    break;
                default:
                    return _competitions.OrderBy(r => r.Id);
            }
            foreach (var competition in competitions)
            {
                var participants = _participants.Where(r => r.CompetitionPlaced.ContainsKey(competition.Id.ToString()));
                competition.Participants = participants;
            }
            return competitions;
        }

        public ParticipantEntity GetParticipant(int participantCI)
        {
            var deletedParticipant = _participants.SingleOrDefault(r => r.CI == participantCI);
            return deletedParticipant;
        }

        public IEnumerable<ParticipantEntity> GetParticipants(int competitionId, string direction, string orderBy)
        {
            IEnumerable<ParticipantEntity> participants;
            participants = _participants.Where(r => r.CompetitionPlaced.ContainsKey(competitionId.ToString()));
            switch (orderBy.ToLower())
            {
                case "ci":
                    participants = direction == "descending" ? participants.OrderByDescending(r => r.CI) : participants.OrderBy(r => r.CI);
                    break;
                case "names":
                    participants = direction == "descending" ? participants.OrderByDescending(r => r.Names) : participants.OrderBy(r => r.Names);
                    break;
                case "lastnames":
                    participants = direction == "descending" ? participants.OrderByDescending(r => r.LastNames) : participants.OrderBy(r => r.LastNames);
                    break;
                default:
                    participants = participants.OrderByDescending(r => r.CI);
                    break;
            }
            return participants;
        }

        public CompetitionEntity UpdateCompetition(int competitionId, CompetitionEntity competition)
        {
            var updatedCompetition = _competitions.FirstOrDefault(r => r.Id == competitionId);
            updatedCompetition.CompetitionDate = competition.CompetitionDate ?? updatedCompetition.CompetitionDate;
            updatedCompetition.Reward = competition.Reward ?? updatedCompetition.Reward;
            return updatedCompetition;
        }

        public ParticipantEntity UpdateParticipant(int participantCI, ParticipantEntity participant)
        {
            var updatedParticipant = _participants.FirstOrDefault(r => r.CI == participantCI);
            updatedParticipant.Names = participant.Names ?? updatedParticipant.Names;
            updatedParticipant.LastNames = participant.LastNames ?? updatedParticipant.LastNames;
            updatedParticipant.BirthYear = participant.BirthYear ?? updatedParticipant.BirthYear;
            updatedParticipant.CellphoneNumber = participant.CellphoneNumber ?? updatedParticipant.CellphoneNumber;
            updatedParticipant.CompetitionsWon = participant.CompetitionsWon ?? updatedParticipant.CompetitionsWon;
            updatedParticipant.CompetitionPlaced = participant.CompetitionPlaced.Count==0 ? updatedParticipant.CompetitionPlaced: participant.CompetitionPlaced;
            return updatedParticipant;
        }
    }
}