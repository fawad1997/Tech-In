using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Tech_In.Models.Model;

namespace Tech_In.Models.ViewModels.ProfileViewModels
{
    public class UserPersonalViewModel
    {
        public int UserPersonalDetailID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        public string FirstName { get; set; }

        [StringLength(100, MinimumLength = 2)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        [StringLength(maximumLength: 300, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 50)]
        public string Summary { get; set; }
        //AspNetUsers
        public string UserID { get; set; }

        public byte[] CVImage { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-mm-dd}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }
        public short DOBVisibility { get; set; }
        public short EmailVisibility { get; set; }
        public short PhonoNoVisibility { get; set; }

        public Gender Gender { get; set; }

        public int CityID { get; set; }
        public City City { get; }
    }
}
