using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tech_In.Models.Model
{
    public class Company
    {
        [Key]
        public int CompanyID { get; set; }
        [StringLength(maximumLength:50),Required]
        public string CompanyName { get; set; }
    }
}
