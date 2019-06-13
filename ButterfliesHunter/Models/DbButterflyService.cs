using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ButterfliesHunter.Models
{
    public class DbButterflyService : IButterflyRepository
    {
        private readonly AppDbContext _appDbContext;

        public DbButterflyService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Butterfly> GetButterflies()
        {
            return _appDbContext.Butterflies.OrderBy(b => b.Ranking).Reverse();
        }

        public Butterfly GetButterfly(int id)
        {
            return _appDbContext.Butterflies.FirstOrDefault(b => b.Id == id);
        }
    }
}
