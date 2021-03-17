using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Theater.Models.Api.Response;
using Theater.Models.Dashboard.Models;

namespace Theater.Mapper.Profiles
{
    public class ActorProfile : Profile
    {

        public ActorProfile()
        {
            CreateMap<Actor, ActorResponse>();
        }
    }
}
