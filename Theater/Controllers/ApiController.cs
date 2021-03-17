using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Theater.Context;
using Theater.Models.Api.Response;

namespace Theater.Controllers
{
    [Route("api")]
    [ApiController]
    public class ApiController : ControllerBase
    {

        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public ApiController(DataContext dataContext, IMapper mapper) 
        { 
            _dataContext = dataContext;
            _mapper = mapper; 
        }

        [HttpGet("plays")]
        public async Task<PlayCollectionResponse> GetAllPlays()
        {
            var plays =await _dataContext.Plays.Include(p => p.PlayActors).ThenInclude(pa => pa.Actor).ToListAsync();

            return new PlayCollectionResponse() { Plays = _mapper.Map<ICollection<PlayResponse>>(plays) };

        }

    }
}