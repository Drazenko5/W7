using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Theater.Models.Dashboard.ViewModels
{
    public class EditPlayViewModel
    {
        [Required]
        public long Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public ICollection<long> Actors { get; set; }
        [Required]
        [DisplayName("Schedule time")]
        public DateTime ScheduleTime { get; set; }

        public byte[] Image { get; set; }
        [DisplayName("New image")]
        public IFormFile NewImageFile { get; set; }
    }
}
