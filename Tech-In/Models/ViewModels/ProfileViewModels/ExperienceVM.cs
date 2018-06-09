using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tech_In.Models.ViewModels.ProfileViewModels
{
    public class ExperienceVM
    {
        public int UserExperienceId { get; set; }
        [StringLength(maximumLength: 50, MinimumLength = 3), Required]
        public string Title { get; set; }
        [StringLength(maximumLength: 200, MinimumLength = 10)]
        public string Description { get; set; }
        [StringLength(maximumLength: 100, MinimumLength = 2)]
        public string CompanyName { get; set; }
        public Boolean CurrentWorkCheck { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-mm-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-mm-dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        public int CityId { get; set; }

        public int CountryId { get; set; }

        //ApNetUser
        public string UserId { get; set; }


        public string CountryName { get; set; }
        public string CityName { get; set; }

    }
}
