using Microsoft.EntityFrameworkCore;

namespace SimpleCrud.Storage.Models
{
    public class EascahireDbContext : DbContext
    {
        internal EascahireDbContext(string connectionString) : base(GetOptions(connectionString))
        {
        }

        private static DbContextOptions Options { get; set; }

        private static DbContextOptions GetOptions(string connectionString)
        {
            return Options ??= new DbContextOptionsBuilder().UseSqlServer(connectionString).Options;
        }

        public virtual DbSet<Candidate> Candidates { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
    }
}
