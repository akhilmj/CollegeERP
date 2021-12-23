using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeAPI.Data.ViewModels
{
    public class ReturnType
    {
        public int Status { get; set; }       
        public object Data { get; set; }
        public string Message { get; set; }       
    }
}
