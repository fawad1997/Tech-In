using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tech_In.Models.Database
{
    public class QuestionSkill
    {
        [Key]
        public int QuestionSkillID { get; set; }
        public SkillTag Tag { get; set; }
        public UserQuestion Question { get; set; }
    }
}
