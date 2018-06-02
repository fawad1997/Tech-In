using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tech_In.Models.ViewModels.ProfileViewModels
{
    public class EducationVM
    {
        [StringLength(maximumLength: 100, MinimumLength = 3), Required]
        public string SchoolName { get; set; }
        [StringLength(maximumLength: 50, MinimumLength = 3), Required]
        public string Title { get; set; }
        [StringLength(maximumLength: 200, MinimumLength = 10)]
        public string Details { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-mm-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-mm-dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }
        public Boolean CurrentStatus { get; set; }
    }
}
