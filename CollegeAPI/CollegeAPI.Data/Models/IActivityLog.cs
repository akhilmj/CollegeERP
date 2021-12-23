using System;
using  System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollegeAPI.Data.Models
{
    public interface IActivityLog
    {
         int? IsActive { get; set; }     
         int?  CreatedBy { get; set; } 
         DateTime? CreatedDate { get; set; }
         int? UpdatedBy { get; set; }       
         DateTime? updatedDate { get; set; }
    }
}