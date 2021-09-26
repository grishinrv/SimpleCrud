using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SimpleCrud.Storage.Models
{
    public partial class EascahireDBContext : DbContext
    {
        public EascahireDBContext()
        {
        }

        public EascahireDBContext(DbContextOptions<EascahireDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Candidate> Candidates { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Position> Positions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=EascahireDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Candidate>(entity =>
            {
                entity.Property(e => e.CandidateId)
                    .ValueGeneratedNever()
                    .HasColumnName("CandidateID");

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FullTime).HasColumnName("Full time");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.OtherInfo).HasColumnName("Other info");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Phone number");

                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PositionId).HasColumnName("PositionID");

                entity.Property(e => e.University).HasMaxLength(50);

                entity.Property(e => e.YearsOfExperience).HasColumnName("Years of experience");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.Property(e => e.CompanyId)
                    .ValueGeneratedNever()
                    .HasColumnName("CompanyID");

                entity.Property(e => e.Activity).HasMaxLength(50);

                entity.Property(e => e.AmountOfWorkers).HasColumnName("Amount of workers");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Company name");

                entity.Property(e => e.Industry).HasMaxLength(50);

                entity.Property(e => e.OtherInfo).HasColumnName("Other info");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Company)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.FullRemote).HasColumnName("Full remote");

                entity.Property(e => e.LinkToPosition).HasColumnName("Link to position");

                entity.Property(e => e.MasterSDegree).HasColumnName("Master's degree");

                entity.Property(e => e.OtherInfoNeeded).HasColumnName("Other info needed");

                entity.Property(e => e.PartialRemoteAuthorized).HasColumnName("Partial remote authorized");

                entity.Property(e => e.Position1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Position");

                entity.Property(e => e.PositionId).HasColumnName("PositionID");

                entity.Property(e => e.Salary).HasMaxLength(50);

                entity.Property(e => e.StartingDate)
                    .HasColumnType("date")
                    .HasColumnName("Starting date");

                entity.Property(e => e.YearsOfExperience).HasColumnName("Years of experience");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
