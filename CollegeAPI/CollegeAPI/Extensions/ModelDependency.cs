using CollegeAPI.Contracts;
using CollegeAPI.Repository;
using Microsoft.Extensions.DependencyInjection;
using CollegeAPI.Data.Models;
using CollegeAPI.Repository.Common;

namespace CollegeAPI.Extensions
{
    public static class ModelDependency
    {
        public static void ConfigureServices(IServiceCollection services)
        {         
            services.AddScoped<IClassRepository, ClassRepository>();
            services.AddScoped<IUserRepository, UserRepositorycs>();
        }
    }
}