using Microsoft.EntityFrameworkCore;

namespace CourDuSoirBackEnd.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Etudiant> Etudiants { get; set; }
        public DbSet<Cours> Courses { get; set; }
        public DbSet<Group> Groups { get; set; }
    }
}
