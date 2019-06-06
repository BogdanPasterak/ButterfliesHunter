using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ButterfliesHunter.Models
{
    public class HunterService : IHunterRepository
    {
        private List<Hunter> _hunters;

        public HunterService(List<Hunter> hunters)
        {
            _hunters = hunters;
        }

        public Hunter GetHunter(int id)
        {
            return _hunters.FirstOrDefault(h => h.HunterId == id);
        }

        public IEnumerable<Hunter> GetHunters()
        {
            return _hunters;
        }
    }
}
