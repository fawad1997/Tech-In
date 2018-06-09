using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tech_In.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        [StringLength(maximumLength:50),Display(Name ="City")]
        public string CityName { get; set; }
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
    }
}
