using System;
using System.Collections.Generic;
using Theater.Models.Dashboard.Models;

namespace Theater.Models.Dashboard.ViewModels
{
    public class PlayViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public ICollection<Actor> Actors { get; set; }
        public DateTime ScheduleTime { get; set; }
    }
}
