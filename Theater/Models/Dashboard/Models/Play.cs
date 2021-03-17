using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Theater.Models.Dashboard.Models
{
    public class Play
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public byte[] Image { get; set; }

        [Required]
        public ICollection<PlayActor> PlayActors { get; set; }

        [Required]
        public DateTime ScheduleTime { get; set; }


    }
}
