using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ButterfliesHunter.Models
{
    public interface IHunterRepository
    {
        IEnumerable<Hunter> GetHunters();
        Hunter GetHunter(int id);
        string getName(string email);
    }
}
