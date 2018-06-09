using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tech_In.Models.Database
{
    public class UserHobby
    {
        [Key]
        public int UserHobbyId { get; set; }
        [StringLength(maximumLength: 20, MinimumLength = 3), Required]
        public string HobbyOrIntrest { get; set; }
        //ApNetUser
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
