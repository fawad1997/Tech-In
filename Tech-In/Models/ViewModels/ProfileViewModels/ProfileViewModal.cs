using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Tech_In.Models.Model;

namespace Tech_In.Models.ViewModels.ProfileViewModels
{
    public class ProfileViewModal
    {
        public string Nam { get; set; }
        public UserPersonalViewModel UserPersonalVM = new UserPersonalViewModel();

        public IEnumerable<EducationVM> EduVMList { get; set; }
        public IEnumerable<ExperienceVM> ExpVMList { get; set; }
    }
}
