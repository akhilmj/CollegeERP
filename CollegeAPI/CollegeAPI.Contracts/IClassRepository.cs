using System.Linq;
using CollegeAPI.Data.Models;

namespace CollegeAPI.Contracts
{
    public interface IClassRepository : IRepositoryBase<Classes>
    {
          IQueryable<Classes> ListClass(int PageIndex,int PageSize);
    }
}