using System;
using CollegeAPI.Contracts;
using CollegeAPI.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace CollegeAPI.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class UserContorller : ControllerBase
    {
       
        private IUserRepository _repository;   
        public UserContorller(IUserRepository repository) 
        { 
            _repository = repository;           
        }
        
        [HttpGet] 
        public IActionResult GetAllUsers() 
        { 
            try 
            { 
                var users = _repository.FIndAll();  
                return Ok(users); 
            } 
            catch (Exception ex) 
            {                 
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal server error"); 
            } 
        }

        [HttpGet("{id}", Name = "usersById")] 
        public IActionResult GetusersById(int id) 
        { 
            try 
            { 
                var users = _repository.FInd(id); 
                if (users == null) 
                {                    
                    return NotFound(); 
                } 
                else 
                {  
                    return Ok(users); 
                } 
            } 
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal server error"); 
            } 
        }

        [HttpPost]
        public IActionResult CreateUsers([FromBody]Users  users)
        {
            try
            {
                if (users == null)
                {
                   return BadRequest("Users object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                _repository.Create(users);
                _repository.Save();
                return CreatedAtRoute("UsersById", new { id = users.Id }, users);
            }
            catch (Exception ex)
            {            
                Console.WriteLine(ex.Message);  
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUsers(int id,[FromBody]Users users)
        {
            try
            {
                if (users == null)
                {                  
                    return BadRequest("Users object is null");
                }

                if (!ModelState.IsValid)
                {                 
                    return BadRequest("Invalid model object");
                }

                var UsersEntity = _repository.FInd(id);
                if (UsersEntity == null)
                {
                    return NotFound();
                }
                UsersEntity.Name = users.Name;
                _repository.Update(UsersEntity);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {         
                Console.WriteLine(ex.Message);       
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUsers(int id)
        {
            try
            {
                var Users = _repository.FInd(id);
                if (Users == null)
                {                    
                    return NotFound();
                }

                _repository.Delete(Users);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {                
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}