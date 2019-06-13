using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ButterfliesHunter.Models
{
    public class Vote
    {
        public Butterfly Butterfly { get; set; }
        public Hunter Hunter { get; set; }
    }
}
