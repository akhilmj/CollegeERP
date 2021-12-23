using System;
using  System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollegeAPI.Data.Models
{
    public abstract class ActivityLog : IActivityLog
    {
        public int? IsActive { get; set; }     
        public int?  CreatedBy { get; set; }
        [ForeignKey("CreatedBy")]
        public virtual Users UserCreated { get; set; }       
        
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }        
        public DateTime? updatedDate { get; set; }
    }
}