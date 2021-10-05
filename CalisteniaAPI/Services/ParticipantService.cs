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
    public class ParticipantService : IParticipantsService
    {
        private ICompetitionRepository _competitionRepository;
        private IMapper _mapper;
        public ParticipantService(ICompetitionRepository competitionRepository, IMapper mapper)
        {
            _competitionRepository = competitionRepository;
            _mapper = mapper;
        }

        private HashSet<string> _allowedSortValues = new HashSet<string>() { "ci", "names", "lastnames" };
        private HashSet<string> _allowedDirectionValues = new HashSet<string>() { "descending", "ascending" };
        public ParticipantModel CreateParticipant(ParticipantModel participant)
        {
            var participantEntity = _mapper.Map<ParticipantEntity>(participant);
            _competitionRepository.CreateParticipant(participantEntity);
            return participant;
        }

        public void DeleteParticipant(int competitionId, int participantCI)
        {
            GetParticipant(competitionId, participantCI);
            _competitionRepository.DeleteParticipant(participantCI);
        }

        public ParticipantModel GetParticipant(int competitionId, int participantCI)
        {
            GetCompetition(competitionId);
            var participant = _competitionRepository.GetParticipant(participantCI);
            if (participant != null)
                return _mapper.Map<ParticipantModel>(participant);
            throw new NotFoundElementException($"The participant with CI: {participantCI} does not exist");
        }

        public IEnumerable<ParticipantModel> GetParticipants(int competitionId, string direction, string orderBy)
        {
            GetCompetition(competitionId);
            if (!_allowedSortValues.Contains(orderBy.ToLower()))
                throw new InvalidElementOperationException($"OrderBy operation: {orderBy} is not recognized. The allowed values for this paramater are: {string.Join(", ", _allowedSortValues)}");
            if (!_allowedDirectionValues.Contains(direction.ToLower()))
                throw new InvalidElementOperationException($"Direction operation: {direction} is not recognized. The allowed values for this paramater are: {string.Join(", ", _allowedDirectionValues)}");

            return _mapper.Map<IEnumerable<ParticipantModel>>(_competitionRepository.GetParticipants(competitionId, direction, orderBy));
        }

        public ParticipantModel UpdateParticipant(int competitionId, int participantCI, ParticipantModel participant)
        {
            GetParticipant(competitionId, participantCI);
            return _mapper.Map<ParticipantModel>(_competitionRepository.UpdateParticipant(participantCI, _mapper.Map<ParticipantEntity>(participant)));
        }

        private void GetCompetition(int competitionId)
        {
            if(_competitionRepository.GetCompetition(competitionId)==null)
                throw new NotFoundElementException($"The competition with id: {competitionId} does not exist");
        }
    }
}
