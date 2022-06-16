using Microsoft.EntityFrameworkCore;

namespace ResumeOurCompany.Models
{
    public class HRDBContext: DbContext
    {
        public DbSet<Recruit> Recruits { get; set; }

        public HRDBContext (DbContextOptions<HRDBContext> options): base (options)
        {

        }
    }
}
