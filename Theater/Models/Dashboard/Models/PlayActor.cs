using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Theater.Models.Dashboard.Models
{
    public class PlayActor
    {
        [Key]
        public long PkFkActorId { get; set; }
        [ForeignKey("PkFkActorId")]
        public Actor Actor { get; set; }

        [Key]
        public long PkFkPlayId { get; set; }
        [ForeignKey("PkFkPlayId")]
        public Play Play { get; set; }
    }
}
