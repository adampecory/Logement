using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MonLogement.Models
{
    public class Role
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}