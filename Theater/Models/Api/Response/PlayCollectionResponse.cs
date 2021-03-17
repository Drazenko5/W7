using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Theater.Models.Api.Response
{
    public class PlayCollectionResponse
    {
        public ICollection<PlayResponse> Plays { get; set; }
    }
}
