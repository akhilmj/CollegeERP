using System.ComponentModel.DataAnnotations.Schema;

namespace CollegeAPI.Data.Models
{
    public class Subject : ActivityLog
    {
         public int Id { get; set; }        
        public string SubjectName { get; set; }
        public int TeacherId { get; set; } 
        [ForeignKey("TeacherId")]
        public Teacher teacher { get; set; }
        public int ClassId { get; set; }    
        [ForeignKey("ClassId")]
        public Classes classes { get; set; }
        
    }
}