using System;
using  System.ComponentModel;


namespace CollegeAPI.Data.Models
{
    public class ActivityLog
    {
        public int IsActive { get; set; }     
        public int  CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime updatedDate { get; set; }
    }
}