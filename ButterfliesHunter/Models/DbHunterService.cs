using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ButterfliesHunter.Models
{
    public class DbHunterService : IHunterRepository
    {
        private readonly AppDbContext _appDbContext;

        public DbHunterService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Hunter GetHunter(int id)
        {
            return _appDbContext.Hunters.FirstOrDefault(h => h.HunterId == id);
        }

        public IEnumerable<Hunter> GetHunters()
        {
            return _appDbContext.Hunters.OrderBy(h => h.Name);
        }

        public string getName(string email)
        {
            Hunter hunter = _appDbContext.Hunters.FirstOrDefault(h => h.Email == email);

            return (hunter == null) ? null : hunter.Name;
        }
    }
}
