using Microsoft.EntityFrameworkCore;
namespace WebAPI_Pratices.Models
{
    public class Databasecontext:DbContext
    {
        public Databasecontext()
        {

        }
        public Databasecontext(DbContextOptions<Databasecontext> options) : base(options) { }

        public virtual DbSet<CurdModel> CurdModel { get; set; }

    }
}
