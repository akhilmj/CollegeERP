using System;
using  System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollegeAPI.Data.Models
{
    public class ActivityLog
    {
        public int? IsActive { get; set; }     
        public int?  CreatedBy { get; set; }
        [ForeignKey("CreatedBy")]
        public virtual Users UserCreated { get; set; }       
        
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        // [ForeignKey("UpdatedBy")]
        // public virtual Users UserUpdated { get; set; }
        public DateTime? updatedDate { get; set; }
    }
}