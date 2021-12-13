using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CollegeAPI.Contracts;
using CollegeAPI.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CollegeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IClassRepository _classrepo;
        public WeatherForecastController(IClassRepository classrepo)
        {
            _classrepo = classrepo;
        }

        [HttpGet]
        public IEnumerable<Classes> Get()
        {
          return _classrepo.FIndAll().ToList().ToArray();
        }
    }
}
