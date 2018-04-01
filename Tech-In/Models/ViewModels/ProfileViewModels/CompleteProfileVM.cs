using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tech_In.Models.ViewModels.ProfileViewModels
{
    public class CompleteProfileVM
    {
        public int UserPersonalDetailID { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        [Display(Name ="First Name ")]
        public string FirstName { get; set; }

        [StringLength(100, MinimumLength = 2)]
        [Display(Name ="Last Name")]
        public string LastName { get; set; }
        //AspNetUsers
        public string UserID { get; set; }

        public byte[] CVImage { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-mm-dd}", ApplyFormatInEditMode = true)]
        [Display(Name ="Date of Birth")]
        public DateTime DOB { get; set; }
        [Display(Name ="Visibility")]
        public short DOBVisibility { get; set; }

        public Gender Gender { get; set; }

        public int CityID { get; set; }
        public City City { get; set; }
    }

    public enum Gender
    {
        Male, Female
    }
}
