using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tech_In.Models.Database
{
    public class UserCertification
    {
        [Key]
        public int UserCertificationID { get; set; }
        [StringLength(maximumLength: 50, MinimumLength = 3), Required]
        public string Name { get; set; }
        [DataType(DataType.Url)]
        [StringLength(maximumLength:200)]
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
        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
