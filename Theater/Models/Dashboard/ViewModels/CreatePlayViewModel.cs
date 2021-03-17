using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Threading.Tasks;
using Theater.Models.Dashboard.Models;
using Microsoft.AspNetCore.Http;
using System.ComponentModel;

namespace Theater.Models.Dashboard.ViewModels
{
    public class CreatePlayViewModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [DisplayName("New image")]
        public IFormFile ImageFile { get; set; }
        [Required]
        public ICollection<long> Actors { get; set; }
        [Required]
        [DisplayName("Schedule time")]
        public DateTime ScheduleTime { get; set; }
    }
}
