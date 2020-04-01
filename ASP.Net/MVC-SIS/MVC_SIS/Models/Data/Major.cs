using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercises.Models.Data
{
    public class Major
    {
        [Required(ErrorMessage ="Please select major")]
        public int MajorId { get; set; }
        
        public string MajorName { get; set; }
    }
}