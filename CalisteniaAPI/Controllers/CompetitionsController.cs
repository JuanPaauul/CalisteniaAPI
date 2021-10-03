using CalisteniaAPI.Models;
using CalisteniaAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalisteniaAPI.Controllers
{
    [Route("/api/competitions")]
    public class CompetitionsController
    {
        private ICompetitionsService _competitionService;
        public CompetitionsController(ICompetitionsService competitionService)
        {
            _competitionService = competitionService;
        }
        [HttpGet]
        public IEnumerable<CompetitionModel> GetCompetitions()
        {
            var competitions = _competitionService.GetCompetitions();
            return competitions;
        }
        [HttpGet("{id:int}")]
        public CompetitionModel GetCompetition(int id)
        {
            var competitions = _competitionService.GetCompetition(id);
            return competitions;
        }
        public CompetitionModel PostCompetition([FromBody]CompetitionModel competition)
        {
            var competitions = _competitionService.CreateCompetition(competition);
            return competitions;
        }
        [HttpPut("{id:int}")]
        public CompetitionModel PutCompetition(int id, [FromBody]CompetitionModel competition)
        {
            var updatedCompetition = _competitionService.UpdateCompetition(id, competition);
            return updatedCompetition;
        }
        [HttpDelete("{id:int}")]
        public bool DeleteCompetition(int id)
        {
            return _competitionService.DeleteCompetition(id);
        }
    }
}
