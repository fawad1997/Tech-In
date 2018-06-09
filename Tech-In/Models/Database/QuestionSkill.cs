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
        public int QuestionSkillId { get; set; }
        public int SkillTagId { get; set; }
        public int UserQuestionId { get; set; }
        public SkillTag SkillTag { get; set; }
        public UserQuestion UserQuestion { get; set; }
    }
}
