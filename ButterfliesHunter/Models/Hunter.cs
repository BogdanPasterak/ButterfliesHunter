using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ButterfliesHunter.Models
{
    public class Hunter
    {
        [BindNever]
        public int HunterId { get; set; }

        [Display(Name = "Hunter name")]
        [Required(ErrorMessage = "The name is required")]
        [MinLength(2, ErrorMessage = "The name must have at least two characters")]
        [MaxLength(50, ErrorMessage = "Up to 50 characters")]
        public string Name { get; set; }

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$")]
        public string Email { get; set; }

        [Display(Name = "Whether he voted")]
        public bool Voted { get; set; }

        [Display(Name = "Display data in public")]
        public bool Display { get; set; }
    }
}
