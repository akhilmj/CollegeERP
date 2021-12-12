using System.ComponentModel.DataAnnotations.Schema;

namespace CollegeAPI.Data.Models
{
    public class Classes : ActivityLog
    {
        public int Id { get; set; }        
        public string CourseName { get; set; } 
        public int ClassTeacherId { get; set; }         
    }
}