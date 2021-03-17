using AutoMapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Theater.Models.Dashboard.Models;
using Theater.Models.Dashboard.ViewModels;

namespace Theater.Mapper.Profiles
{
    public class PlayProfile : Profile
    {

        public PlayProfile()
        {
            
            CreateMap<Play, PlayViewModel>().ForMember(pwm=>pwm.Actors,m=>m.MapFrom(p=>p.PlayActors.Select(pa=>pa.Actor)));

            CreateMap<Play, EditPlayViewModel>().ForMember(epwm => epwm.Actors, m => m.MapFrom(p => p.PlayActors.Select(pa => pa.Actor.Id)));

        }

    }
}
