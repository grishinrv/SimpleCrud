using Microsoft.EntityFrameworkCore;

namespace SimpleCrud.Storage.Models
{
    public class EascahireDbContext : DbContext
    {
        public virtual DbSet<Candidate> Candidates { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
    }
}
