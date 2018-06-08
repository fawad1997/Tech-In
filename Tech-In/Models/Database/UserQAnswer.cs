using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tech_In.Models.Database
{
    public class UserQAnswer
    {
        [Key]
        public int UserQAnswerId { get; set; }
        [StringLength(maximumLength: 50, MinimumLength = 3), Required]

        public string Description { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-mm-dd}", ApplyFormatInEditMode = true)]
        public DateTime PostTime { get; set; }

        public int UserQuestionId { get; set; }
        public virtual UserQuestion UserQuestion { get; set; }


        //ApNetUser
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
