using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tech_In.Models
{
    public class Country
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CountryId { get; set; }

        [StringLength(maximumLength:50),Display(Name ="Country"),Required]
        public string CountryName { get; set; }

        [StringLength(maximumLength:3,MinimumLength =2),Required]
        public string CountryCode { get; set; }

        [StringLength(maximumLength:5)]
        public string CountryPhoneCode { get; set; }

        public ICollection<City> Cities { get; set; }

    }
}
