using Microsoft.EntityFrameworkCore;

namespace WebApplicationExample
{
    public class OsobaDb : DbContext
    {
        public DbSet<Osoba> Osoby { get; set; }
        public OsobaDb(DbContextOptions<OsobaDb> options) : base(options) { }
    }
}
