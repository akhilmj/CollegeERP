using System.Linq;
using CollegeAPI.Contracts;
using CollegeAPI.Data.DBConnection;
using CollegeAPI.Data.Models;
using CollegeAPI.Repository.Common;

namespace CollegeAPI.Repository
{
    public class ClassRepository : RepositoryBase<Classes>, IClassRepository
    {
        public ClassRepository(ApplicationContext context) : base(context)
        {
            
        }

        public IQueryable<Classes> ListClass(int PageIndex = 1, int PageSize = 2)
        {
                return FIndAll().Skip(PageIndex -1).Take(PageSize);
        }

    }
}