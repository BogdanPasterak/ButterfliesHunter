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
        public int ButterflyId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public int AuthorId { get; set; }

        [Required]
        public int Ranking { get; set; }

        [Required]
        public bool IsProceted { get; set; }

        [Required]
        public string Description { get; set; }

    }
}
