using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tech_In.Models;
using Tech_In.Models.Database;
using Tech_In.Models.Model;

namespace Tech_In.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        //public ApplicationDbContext()
        //{
        //}

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Country> Country { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<UserPersonalDetail> UserPersonalDetail { get; set; }
        public DbSet<UserExperience> UserExperience { get; set; }
        public DbSet<UserEducation> UserEducation { get; set; }
        public DbSet<UserCertification> UserCertification { get; set; }
        public DbSet<UserHobby> UserHobby { get; set; }
        public DbSet<UserLanguageSkill> UserLanguageSkill { get; set; }
        public DbSet<UserPublication> UserPublication { get; set; }
        public DbSet<UserAcheivement> UserAcheivement { get; set; }
        public DbSet<SkillTag> SkillTag { get; set; }

        public DbSet<UserQAComment> UserQAComment { get; set; }
        public DbSet<UserQAnswer> UserQAnswer { get; set; }
        public DbSet<UserQAVoting> UserQAVoting { get; set; }
        public DbSet<UserQuestion> UserQuestion { get; set; }
        public DbSet<UserSkill> UserSkill { get; set; }
        public DbSet<QuestionSkill> QuestionSkill { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            //"Server=tcp:techin.database.windows.net,1433;Initial Catalog=techin;Persist Security Info=False;User ID=tech;Password=Fawad1997;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
            //Data Source=DESKTOP-RJ6TPH2;Initial Catalog=techin;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
