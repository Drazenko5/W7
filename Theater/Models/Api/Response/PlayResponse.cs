using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Theater.Models.Api.Response
{
    public class PlayResponse
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public ICollection<ActorResponse> Actors { get; set; }
        public DateTime ScheduleTime { get; set; }
    }
}
