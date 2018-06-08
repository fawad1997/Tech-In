using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tech_In.Models.ViewModels.ProfileViewModels
{
    public class EducationVM
    {
        public int UserEducationID { get; set; }
        [StringLength(maximumLength: 50, MinimumLength = 3), Required]
        public string Title { get; set; }
        [StringLength(maximumLength: 100, MinimumLength = 3), Required]
        public string SchoolName { get; set; }
        [StringLength(maximumLength: 200, MinimumLength = 10)]
        public string Details { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-mm-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-mm-dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        public Boolean CurrentStatusCheck { get; set; }

        public int CityId { get; set; }
        public int CountryId { get; set; }
        public string CityName { get; set; }
        public string CountryName { get; set; }
        [StringLength(maximumLength: 450)]
        public string UserId { get; set; }

    }
}
