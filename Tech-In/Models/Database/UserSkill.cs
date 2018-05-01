using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tech_In.Models.Database
{
    public class UserSkill
    {
        [Key]
        public string UserSkillID { get; set; }

        public SkillTag SkillTag { get; set; }
        //AspNetUser
        [StringLength(maximumLength: 450)]
        public string UserID { get; set; }
    }
}
