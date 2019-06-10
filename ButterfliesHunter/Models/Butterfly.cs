using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ButterfliesHunter.Models
{
    public class Butterfly
    {
        [BindNever]
        public int Id { get; set; }

        [Display(Name = "Butterfly name")]
        [Required(ErrorMessage = "The name is required")]
        [MinLength(2, ErrorMessage = "The name must have at least two characters")]
        [MaxLength(50, ErrorMessage = "Up to 50 characters")]
        public string Name { get; set; }


        public string Range { get; set; }

        [Required]
        public int Ranking { get; set; }

        [Required]
        public bool IsProtected { get; set; }

        [Required]
        public int HunterId { get; set; }

        public string Description { get; set; }

    }
}
