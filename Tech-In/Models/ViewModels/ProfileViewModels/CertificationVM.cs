using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tech_In.Models.ViewModels.ProfileViewModels
{
    public class CertificationVM
    {
        public int UserCertificationId { get; set; }
        [StringLength(maximumLength: 50, MinimumLength = 3), Required]
        public string Name { get; set; }
        [DataType(DataType.Url)]
        [StringLength(maximumLength: 200)]
        public string URL { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-mm-dd}", ApplyFormatInEditMode = true)]
        public DateTime CertificationDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-mm-dd}", ApplyFormatInEditMode = true)]
        public DateTime ExpirationDate { get; set; }
        [StringLength(maximumLength: 50, MinimumLength = 3)]
        public string LiscenceNo { get; set; }

        //ApNetUser
        public string UserId { get; set; }
    }
}
