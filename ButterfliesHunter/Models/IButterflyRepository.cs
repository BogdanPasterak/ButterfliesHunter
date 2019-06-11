using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ButterfliesHunter.Models
{
    interface IButterflyRepository
    {
        IEnumerable<Butterfly> GetButterflies();
        Butterfly GetButterfly(int id);
    }

}
