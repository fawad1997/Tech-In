using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tech_In.Models
{
    public class ApplicationJob
    {
        
        int JobID { set; get; }
        string JobTitle { set; get; }
        string JobCategory { set; get; }
        string Experience { set; get; }
        string Salary { set; get; }
        string JobType { set; get; }
        string JobShift { set; get; }
        string Qualification { set; get; }
        string TotalVacancies { set; get; }
        string JobDescription { set; get; }
        string JobSpecification { set; get; }
        string PositionRequirment { set; get; }
    }
}
