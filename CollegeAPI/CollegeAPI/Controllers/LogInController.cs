using CollegeAPI.Contracts;
using CollegeAPI.Contracts.Common;
using CollegeAPI.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CollegeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogInController : ControllerBase
    {
        private IUserRepository _repository;
        private readonly IConfiguration _config;
        public LogInController(IUserRepository repository, IConfiguration config)
        {
            _repository = repository;
            _config = config;
        }
        // POST api/<LogInController>
        [HttpPost]
        public IActionResult Post([FromBody] LogInVModel user)
        {
            try
            {
                if (string.IsNullOrEmpty(user.Name) || string.IsNullOrEmpty(user.Password))
                {
                    return BadRequest(new ReturnType { Status = 0,Data=user,Message = "Please enter user name and password." });
                }

                var loginUser = _repository.FIndByConditon(x => x.Name == user.Name && x.Password == user.Password).FirstOrDefault();
                if (loginUser != null)
                {
                    var tokenString = BCommon.GenerateJSONWebToken(user.Name, _config["Jwt:Issuer"], _config["Jwt:Key"]);
                    return Ok(new ReturnType { Status = 1, Data = new { token = tokenString, user = user }, Message = "Login Successful." });
                }
                else
                {
                    return NotFound(new ReturnType { Status = 0, Data = user, Message = "Please enter valid username and password." });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);               
                return StatusCode(500, new ReturnType { Status = 0, Data = user, Message = ex.Message });
            }
        }
        

    }
    
}
