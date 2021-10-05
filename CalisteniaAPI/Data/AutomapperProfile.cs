using AutoMapper;
using CalisteniaAPI.Data.Entities;
using CalisteniaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalisteniaAPI.Data
{
    public class AutomapperProfile:Profile
    {
        public AutomapperProfile()
        {
            this.CreateMap<CompetitionEntity, CompetitionModel>()
                .ReverseMap();

            this.CreateMap<ParticipantEntity, ParticipantModel>()
                .ReverseMap();
        }
    }
}
