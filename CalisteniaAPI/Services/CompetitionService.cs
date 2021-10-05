using AutoMapper;
using CalisteniaAPI.Data.Entities;
using CalisteniaAPI.Data.Repository;
using CalisteniaAPI.Exceptions;
using CalisteniaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalisteniaAPI.Services
{
    public class CompetitionService : ICompetitionsService
    {
        private ICompetitionRepository _competitionRepository;
        private IMapper _mapper;

        public CompetitionService(ICompetitionRepository competitionRepository, IMapper mapper)
        {
            _competitionRepository = competitionRepository;
            _mapper = mapper;
        }

        private HashSet<string> _allowedSortValues = new HashSet<string>() { "id", "competitiondate", "reward" };
        private HashSet<string> _allowedDirectionValues = new HashSet<string>() { "descending", "ascending"};

        public CompetitionModel CreateCompetition(CompetitionModel competition)
        {
            var competitionEntity = _mapper.Map<CompetitionEntity>(competition);
            competition = _mapper.Map<CompetitionModel>(_competitionRepository.CreateCompetition(competitionEntity));
            return competition;
        }

        public void DeleteCompetition(int competitionId)
        {
            GetCompetition(competitionId);
            _competitionRepository.DeleteCompetition(competitionId);
        }

        public CompetitionModel GetCompetition(int competitionId)
        {
            var competition = _competitionRepository.GetCompetition(competitionId);
            if (competition != null)
                return _mapper.Map<CompetitionModel>(competition);
            throw new NotFoundElementException($"The competition with id: {competitionId} does not exist");
        }

        public IEnumerable<CompetitionModel> GetCompetitions(string direction, string orderBy)
        {
            if (!_allowedSortValues.Contains(orderBy.ToLower()))
                throw new InvalidElementOperationException($"OrderBy operation: {orderBy} is not recognized. The allowed values for this paramater are: {string.Join(", ",_allowedSortValues)}");
            if (!_allowedDirectionValues.Contains(direction.ToLower()))
                throw new InvalidElementOperationException($"Direction operation: {direction} is not recognized. The allowed values for this paramater are: {string.Join(", ", _allowedDirectionValues)}");
            
            return _mapper.Map<IEnumerable<CompetitionModel>>(_competitionRepository.GetCompetitions(direction, orderBy));
        }
        
        public CompetitionModel UpdateCompetition(int competitionId, CompetitionModel competition)
        {
            GetCompetition(competitionId);
            return _mapper.Map<CompetitionModel>(_competitionRepository.UpdateCompetition(competitionId, _mapper.Map<CompetitionEntity>(competition)));
        }
    }
}
