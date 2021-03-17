using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Theater.Context;
using Theater.Models;
using Theater.Models.Dashboard.ViewModels;

namespace Theater.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, DataContext dataContext, IMapper mapper)
        {
            _logger = logger;
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var plays = await _dataContext.Plays.Include(p => p.PlayActors).ThenInclude(pa=>pa.Actor).ToListAsync();
            return View(_mapper.Map<ICollection<PlayViewModel>>(plays));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
