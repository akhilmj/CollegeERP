using System;
using CollegeAPI.Contracts;
using CollegeAPI.Data.Models;
using CollegeAPI.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CollegeAPI.Controllers
{
    public class ClassController : BaseController
    {
        private IClassRepository _repository;   
        public ClassController(IClassRepository repository) 
        { 
            _repository = repository;           
        }
        
        [HttpGet] 
        public IActionResult GetAll() 
        { 
            try 
            { 
                var data = _repository.FIndAll();
                return Ok(new ReturnType { Status = 1, Data = data, Message = "" });
            } 
            catch (Exception ex) 
            {                 
                Console.WriteLine(ex.Message);
                return StatusCode(500, new ReturnType { Status = 0, Data = { }, Message = ex.Message });               
            } 
        }

        [HttpGet("{id}")] 
        public IActionResult GetById(int id) 
        { 
            try 
            { 
                var data = _repository.FInd(id); 
                if (data == null) 
                {                    
                    return NotFound(new ReturnType { Status = 0, Data = id, Message = "Record no found" }); 
                } 
                else 
                {  
                    return Ok(new ReturnType { Status = 1, Data = data, Message = "" }); 
                } 
            } 
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.Message);
                return StatusCode(500, new ReturnType { Status = 0, Data = id, Message = ex.Message });

            }
        }

        [HttpPost]
        public IActionResult Create([FromBody]Classes  data)
        {
            try
            {
                if (data == null)
                {
                    return BadRequest(new ReturnType { Status = 0, Data = data, Message = "Classes object is null" });
                }

                if (!ModelState.IsValid)
                {                    
                    return BadRequest(new ReturnType { Status = 0, Data = data, Message = "Invalid model object" });
                }
                _repository.Create(
                    );
                _repository.Save();                
                return Ok(new ReturnType { Status = 1, Data = data, Message = "Created SuccessFully" });
            }
            catch (Exception ex)
            {            
                Console.WriteLine(ex.Message);
                return StatusCode(500, new ReturnType { Status = 0, Data = data, Message = ex.Message });

            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id,[FromBody]Classes data)
        {
            try
            {
                if (data == null)
                {   
                    return BadRequest(new ReturnType { Status = 0, Data = data, Message = "Classes object is null" });
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(new ReturnType { Status = 0, Data = data, Message = "Invalid model object" });                    
                }

                var dataupdate = _repository.FInd(id);
                if (dataupdate == null)
                {
                    return NotFound(new ReturnType { Status = 0, Data = data, Message = "Record not found" });
                }
                dataupdate.CourseName = data.CourseName;                
                _repository.Update(dataupdate);
                _repository.Save();

                return Ok(new ReturnType { Status = 1, Data = data, Message = "Updated SuccessFully" });

            }
            catch (Exception ex)
            {         
                Console.WriteLine(ex.Message);
                return StatusCode(500, new ReturnType { Status = 0, Data = { }, Message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var data = _repository.FInd(id);
                if (data == null)
                {                    
                    return NotFound(new ReturnType { Status = 0, Data = "", Message = "Record not found" });
                }

                _repository.Delete(data);
                _repository.Save();

                return Ok(new ReturnType { Status = 1, Data = id, Message = "Deleted SuccessFully" });
            }
            catch (Exception ex)
            {                
                Console.WriteLine(ex.Message);
                return StatusCode(500, new ReturnType { Status = 0, Data = { }, Message = ex.Message });
            }
        }
        
    }
}