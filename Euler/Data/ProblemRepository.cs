using Euler.Models;
using System.Collections.Generic;
using System.Linq;

namespace Euler.Data
{
    public class ProblemRepository : CsvRepository<Problem>, IProblemRepository
    {
        public ProblemRepository(IEnumerable<Problem> problems) : base(problems)
        {
        }

        public Problem GetByEulerId(int eulerId)
        {
            return _entities.Where(x => x.EulerId == eulerId).Single();
        }
    }
}
