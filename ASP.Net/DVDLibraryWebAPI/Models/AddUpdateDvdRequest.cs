using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DVDLibraryWebAPI.Models
{
    public class AddUpdateDvdRequest
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public int ReleaseYear { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Rating { get; set; }
        [Required]
        public string Notes { get; set; }
    }
}