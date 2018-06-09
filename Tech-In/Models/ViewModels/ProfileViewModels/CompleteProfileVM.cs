using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Tech_In.Models.Model;

namespace Tech_In.Models.ViewModels.ProfileViewModels
{
    public class CompleteProfileVM
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        [Display(Name = "First Name ")]
        [RegularExpression(@"^[a-zA-Z\s]+$",ErrorMessage ="First Name can only contain aplhabets")]
        public string FirstName { get; set; }

        [StringLength(100, MinimumLength = 2)]
        [Display(Name = "Last Name")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Last Name can only contain aplhabets")]
        public string LastName { get; set; }

        //AspNetUsers
        public string UserID { get; set; }

        public byte[] CVImage { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-mm-dd}", ApplyFormatInEditMode = true,NullDisplayText ="Date of Birth can't be Null")]
        [Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }

        [Display(Name = "Date of Birth Visibility")]
        public Boolean DOBVisibility { get; set; }

        public Gender Gender { get; set; }

        [Required]
        public int CityId { get; set; }

        public int CountryId { get; set; }

    }
}