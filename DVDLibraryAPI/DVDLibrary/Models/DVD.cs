using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DVDLibrary.Models
{
    public class DVD
    {
        public int DVDId { get; set; }
        [Required]
        public string Title { get; set; }
        [Range( 1940, 2021,
            ErrorMessage = "Must be within 1940 - 2021")]
        public int ReleaseYear { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Rating { get; set; }
        public string Notes { get; set; }
    }
}