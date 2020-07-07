using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace SCM.BusinessRuleEngine.Web.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration appConfiguration;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration Configuration) : base(options)
        {
            this.appConfiguration = Configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.appConfiguration["ConnectionStrings:SCMBusinessEngineDb"]);
        }
    }
}
