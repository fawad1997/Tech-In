using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tech_In.Models.Database
{
    public class UserQAComment
    {
        [Key]
        public int UserQACommentID { get; set; }

        public string Description { get; set; }

        public Boolean Visibility { get; set; }

        public Boolean IsAnswer { get; set; }

        public UserQuestion Question { get; set; }
        public UserQAnswer Answer { get; set; }
        //AspNetUser
        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
