using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tech_In.Data.interfaces;
using Tech_In.Models.Model;

namespace Tech_In.Data.Repository
{
    public class UserPersonalDetailRepository : Repository<UserPersonalDetail>, IUserPersonalDetailRepository
    {
        public UserPersonalDetailRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
