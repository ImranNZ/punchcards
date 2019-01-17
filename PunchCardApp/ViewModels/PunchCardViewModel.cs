using System;
using System.ComponentModel.DataAnnotations;

namespace PunchCardApp.ViewModels
{
    public class PunchCardViewModel
    {
        [Required]
        public DateTime PunchIn { get; set; }

        [Required]
        public DateTime PunchOut { get; set; }

        [Required]
        public string Description { get; set; }
    }
}