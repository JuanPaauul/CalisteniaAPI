using CalisteniaAPI.Exceptions;
using CalisteniaAPI.Models;
using CalisteniaAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalisteniaAPI.Controllers
{
    [Route("api/competitions/{competitionId}/[controller]")]
    public class ParticipantsController:Controller
    {
        private IParticipantsService _participantService;
        public ParticipantsController(IParticipantsService participantService)
        {
            _participantService = participantService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<CompetitionModel>> GetParticipants(int competitionId,[FromQuery] string direction = "ascending", string orderBy = "CI")
        {
            try
            {
                var participants = _participantService.GetParticipants(competitionId,direction, orderBy);
                return Ok(participants);
            }
            catch (NotFoundElementException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidElementOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Uups, something happened.");
            }
        }
        [HttpGet("{CI:int}")]
        public ActionResult<CompetitionModel> GetParticipant(int competitionId, int CI)
        {
            try
            {
                var participants = _participantService.GetParticipant(competitionId, CI);
                return Ok(participants);
            }
            catch (NotFoundElementException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidElementOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Uups, something happened.");
            }
        }
        public ActionResult<CompetitionModel> PostParticipant([FromBody] ParticipantModel participant)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var participants = _participantService.CreateParticipant(participant);
            return Created($"/api/competitions/0/participants/{participant.CI}", participants);
        }
        [HttpPut("{CI:int}")]
        public ActionResult<CompetitionModel> PutParticipant(int competitionId, int CI, [FromBody] ParticipantModel participant)
        {
            try
            {
                var updatedParticipant = _participantService.UpdateParticipant(competitionId, CI, participant);
                return Ok(updatedParticipant);
            }
            catch (NotFoundElementException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Uups, something happened.");
            }
        }
        [HttpDelete("{CI:int}")]
        public ActionResult DeleteCompetition(int competitionId, int CI)
        {
            try
            {
                _participantService.DeleteParticipant(competitionId, CI);
                return Ok();
            }
            catch (NotFoundElementException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Uups, something happened.");
            }
        }
    }
}
