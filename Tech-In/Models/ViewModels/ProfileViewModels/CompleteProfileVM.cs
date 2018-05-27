using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tech_In.Models.ViewModels.ProfileViewModels
{
    public class CompleteProfileVM
    {
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

        [Display(Name ="Date of Birth Visibility")]
        public Boolean DOBVisibility { get; set; }

        public Gender Gender { get; set; }

        public City City { get; set; }
        public List<SelectListItem> Cities { get; set; } = new List<SelectListItem>();

        public Country Country { get; set; }
        public List<SelectListItem> Countries { get; set; } = new List<SelectListItem>();
    }

    public enum Gender
    {
        Male, Female
    }
}
