using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tech_In.Models.Database
{
    public class UserQuestion
    {
        [Key]
        public int UserQuestionID { get; set; }
        [StringLength(maximumLength: 50, MinimumLength = 3), Required]
        public string Title { get; set; }
        [StringLength(maximumLength: 200, MinimumLength = 10),Required]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-mm-dd}", ApplyFormatInEditMode = true)]
        public DateTime PostTime { get; set; }

        //AspNetUser
        [StringLength(maximumLength: 450)]
        public string UserID { get; set; }
    }
}
