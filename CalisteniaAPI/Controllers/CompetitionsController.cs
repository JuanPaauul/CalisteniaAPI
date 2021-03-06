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
    [Route("/api/competitions")]
    public class CompetitionsController:Controller
    {
        private ICompetitionsService _competitionService;
        public CompetitionsController(ICompetitionsService competitionService)
        {
            _competitionService = competitionService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<CompetitionModel>> GetCompetitions([FromQuery]string direction = "ascending", string orderBy = "id")
        {
            try
            {
                var competitions = _competitionService.GetCompetitions(direction,orderBy);
                return Ok(competitions);
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
        [HttpGet("{id:int}")]
        public ActionResult<CompetitionModel> GetCompetition(int id)
        {
            try
            {
                var competitions = _competitionService.GetCompetition(id);
                return Ok(competitions);
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
        public ActionResult<CompetitionModel> PostCompetition([FromBody]CompetitionModel competition)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var competitions = _competitionService.CreateCompetition(competition);
            return Created($"/api/competitions/{competitions.Id}", competitions);
        }
        [HttpPut("{id:int}")]
        public ActionResult<CompetitionModel> PutCompetition(int id, [FromBody]CompetitionModel competition)
        {
            try
            {
                /*if (!ModelState.IsValid)
                {
                    if (competition.CompetitionDate != null && ModelState.ContainsKey("competitiondate") && ModelState["competitiondate"].Errors.Count > 0)
                    {
                        return BadRequest(ModelState["competitiondate"].Errors);
                    }
                    if (competition.Reward != null && ModelState.ContainsKey("reward") && ModelState["reward"].Errors.Count > 0)
                    {
                        return BadRequest(ModelState["reward"].Errors);
                    }
                }*/
                var updatedCompetition = _competitionService.UpdateCompetition(id, competition);
                return Ok(updatedCompetition);
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
        [HttpDelete("{id:int}")]
        public ActionResult DeleteCompetition(int id)
        {
            try
            {
                _competitionService.DeleteCompetition(id);
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
