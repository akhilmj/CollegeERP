using System.ComponentModel.DataAnnotations.Schema;

namespace CollegeAPI.Data.Models
{
    public class Student : ActivityLog
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Address { get; set; }        
        public string Phone { get; set; }        
        public string Email { get; set; }
        public int ClassId { get; set; }
        [ForeignKey("ClassId")]
        public Classes classes { get; set; }
                    
    }
}