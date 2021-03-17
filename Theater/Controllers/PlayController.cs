using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Theater.Context;
using Theater.Models.Dashboard.Models;
using Theater.Models.Dashboard.ViewModels;

namespace Theater.Controllers
{
    public class PlayController : Controller
    {
        private readonly IMapper _mapper;
        private readonly DataContext _dataxContext;

        public PlayController(DataContext dataContext, IMapper mapper)
        {
            _dataxContext = dataContext;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(long id)
        {
            var play = await _dataxContext.Plays.Include(p => p.PlayActors).ThenInclude(pa => pa.Actor).FirstOrDefaultAsync(p => p.Id == id);

            if (play == null)
                return NotFound();

            return View(_mapper.Map<PlayViewModel>(play));

        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var actors = await _dataxContext.Actors.ToListAsync();
            ViewBag.Actors = new SelectList(actors, "Id", "FirstName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePlayViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var actors = await _dataxContext.Actors.ToListAsync();
                ViewBag.Actors = new SelectList(actors, "Id", "FirstName");
                return View(model);
            }

            var _actors = new List<PlayActor>();
            foreach (var id in model.Actors)
            {
                _actors.Add(new PlayActor() { PkFkActorId = id });
            }
            Play play = new Play() { Title = model.Title, Description = model.Description, ScheduleTime = model.ScheduleTime, PlayActors = _actors };

            using (var ms = new MemoryStream())
            {
                await model.ImageFile.CopyToAsync(ms);
                play.Image = ms.ToArray();
            }

            _dataxContext.Plays.Add(play);
            await _dataxContext.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Delete(long id)
        {
            var play = await _dataxContext.Plays.FirstOrDefaultAsync(p => p.Id == id);

            if (play == null)
                return NotFound();

            _dataxContext.Plays.Remove(play);
            await _dataxContext.SaveChangesAsync();

            return RedirectToAction("Index", "Home");

        }

        [HttpGet]
        public async Task<IActionResult> Edit(long id)
        {
            var play = await _dataxContext.Plays.Include(p => p.PlayActors).FirstOrDefaultAsync(p => p.Id == id);

            if (play == null)
                return NotFound();

            var actors = await _dataxContext.Actors.ToListAsync();
            var actorsSelectList = new MultiSelectList(actors, "Id", "FirstName", play.PlayActors.Select(pa => pa.PkFkActorId));
            ViewBag.Actors = actorsSelectList;
            return View(_mapper.Map<EditPlayViewModel>(play));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditPlayViewModel model)
        {

            if (!ModelState.IsValid)
            {
                var actors = await _dataxContext.Actors.ToListAsync();
                var actorsSelectList = new MultiSelectList(actors, "Id", "FirstName", model.Actors);
                ViewBag.Actors = actorsSelectList;
                return View(model);
            }

            var play = await _dataxContext.Plays.Include(p => p.PlayActors).FirstOrDefaultAsync(p => p.Id == model.Id);

            if (play == null)
                return NotFound();

            play.Title = model.Title;
            play.Description = model.Description;
            play.ScheduleTime = model.ScheduleTime;

            var playActors = new List<PlayActor>();
            foreach (var id in model.Actors)
            {
                playActors.Add(new PlayActor() { PkFkActorId = id, PkFkPlayId=play.Id});
            }

            if (model.NewImageFile != null)
            {
                using (var ms = new MemoryStream())
                {
                    await model.NewImageFile.CopyToAsync(ms);
                    play.Image = null;
                    play.Image = ms.ToArray();
                }
            }

            _dataxContext.Plays.Update(play);
            _dataxContext.PlayActors.RemoveRange(play.PlayActors);
            _dataxContext.PlayActors.AddRange(playActors);
            await _dataxContext.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
    }

}
}