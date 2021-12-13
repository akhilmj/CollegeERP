using System.Linq;
using CollegeAPI.Contracts;
using CollegeAPI.Data.DBConnection;
using CollegeAPI.Data.Models;
using CollegeAPI.Repository.Common;

namespace CollegeAPI.Repository
{
    public class UserRepositorycs : RepositoryBase<Users>,IUserRepository
    {
        public UserRepositorycs(ApplicationContext context) : base(context)
        {
            
        }
    }
}