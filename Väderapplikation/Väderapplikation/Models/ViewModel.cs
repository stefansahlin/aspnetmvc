using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Väderapplikation.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Väderapplikation.Models
{
    public class ViewModel
    {
        [DisplayName("Name")]
        [Required]
        [StringLength(100)]
        public string place { get; set; }
    }
}