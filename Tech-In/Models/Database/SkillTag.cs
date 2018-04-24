using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tech_In.Models.Database
{
    public class SkillTag
    {
        [Key]
        public int SkillTagID { get; set; }

        [Required,StringLength(maximumLength:20,MinimumLength =1)]
        public string SkillName { get; set; }

        public Boolean ApprovedStatus { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-mm-dd}", ApplyFormatInEditMode = true)]
        public DateTime TimeApproved { get; set; }

        //AspNetUser
        public string AddedByUserId { get; set; }
    }
}
