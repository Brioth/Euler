using Euler.Models;

namespace Euler.Data
{
    public interface IProblemRepository : IRepository<Problem>
    {
        Problem GetByEulerId(int eulerId);
    }
}
