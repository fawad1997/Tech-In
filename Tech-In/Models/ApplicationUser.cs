using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Tech_In.Models.Database;
using Tech_In.Models.Model;

namespace Tech_In.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<UserSkill> UserSkill { get; set; }
        public virtual ICollection<UserCertification> UserCertifications { get; set; }
        public virtual ICollection<UserExperience> UserExperiences { get; set; }
        public virtual ICollection<UserEducation> UserEducations { get; set; }
        public virtual ICollection<UserPersonalDetail> UserPersonalDetails { get; set; }
        public virtual ICollection<UserHobby> UserHobbies { get; set; }
        public virtual ICollection<UserLanguageSkill> UserLanguageSkills { get; set; }
        public virtual ICollection<UserPublication> UserPublications { get; set; }
        public virtual ICollection<UserAcheivement> UserAcheivements { get; set; }
        public virtual ICollection<UserQuestion> Questions { get; set; }
        public virtual ICollection<UserQAnswer> UserQAnswers { get; set; }
        public virtual ICollection<UserQAVoting> UserQAVotings { get; set; }
        public virtual ICollection<UserQAComment> UserQAComments { get; set; }
    }
}
