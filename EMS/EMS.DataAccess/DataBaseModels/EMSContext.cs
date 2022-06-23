using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace EMS.DataAccess.DataBaseModels
{
	public partial class EMSContext : DbContext
	{
		public EMSContext()
		{
		}

		public EMSContext(DbContextOptions<EMSContext> options)
			: base(options)
		{
		}

		public virtual DbSet<Voter> Voters { get; set; }
		public virtual DbSet<User> Users { get; set; }
		public virtual DbSet<Party> Party { get; set; }
		public virtual DbSet<ElectionSymbol> Symbols { get; set; }
		public virtual DbSet<Constituency> Constituency { get; set; }
		public virtual DbSet<Candidate> Candidates { get; set; }
		public virtual DbSet<Election> Elections { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{

			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

			modelBuilder.Entity<Voter>(entity =>
			{
				entity.ToTable("Voter");

				entity.Property(e => e.FirstName)
					.IsRequired()
					.HasMaxLength(50);
				entity.Property(e => e.LastName)
					.HasMaxLength(50);
				entity.Property(e => e.Aadhar)
					.HasMaxLength(12);
				entity.Property(e => e.Mobile)
					.HasMaxLength(10);
				entity.Property(e => e.Email)
					.HasMaxLength(50);
				entity.Property(e => e.Address)
					.HasMaxLength(50);
				entity.Property(e => e.DateOfBirth)
				  .HasMaxLength(50);
			});

			modelBuilder.Entity<Candidate>(entity =>
			{
				entity.ToTable("Candidate");

				entity.Property(e => e.Name)
					.IsRequired()
					.HasMaxLength(50);
				entity.Property(e => e.Party)
					.HasMaxLength(50);
				entity.Property(e => e.Address)
					.HasMaxLength(120);
				entity.Property(e => e.Constituency)
					.HasMaxLength(100);
			});
			modelBuilder.Entity<Election>(entity =>
						{
							entity.ToTable("Election");

							entity.Property(e => e.Candidate)
								.IsRequired()
								.HasMaxLength(50);
							entity.Property(e => e.Party)
								.HasMaxLength(50);
							entity.Property(e => e.Symbol)
								.HasMaxLength(50);
							entity.Property(e => e.Constituency)
								.HasMaxLength(100);
							entity.Property(e => e.Votes)
								.HasMaxLength(100);
						});
			modelBuilder.Entity<Party>(entity =>
			{
				entity.ToTable("Party");

				entity.Property(e => e.Name)
					.IsRequired()
					.HasMaxLength(50);
				entity.Property(e => e.Description)
					.HasMaxLength(50);
				entity.Property(e => e.Address)
					.HasMaxLength(12);
				entity.Property(e => e.Symbol)
					.HasMaxLength(10);
			});

			modelBuilder.Entity<Constituency>(entity =>
						{
							entity.ToTable("Constituency");

							entity.Property(e => e.ConstituencyName)
								.IsRequired()
								.HasMaxLength(50);
							entity.Property(e => e.State)
								.HasMaxLength(50);
							entity.Property(e => e.CurrentMember)
								.HasMaxLength(12);
						});
			modelBuilder.Entity<ElectionSymbol>(entity =>
			{
				entity.ToTable("ElectionSymbols");

				entity.Property(e => e.Name)
					.IsRequired()
					.HasMaxLength(50);
				entity.Property(e => e.Symbol)
					.HasMaxLength(1000);
			});
			modelBuilder.Entity<User>(entity =>
			{
				entity.ToTable("User");

				entity.Property(e => e.Name)
					.IsRequired()
					.HasMaxLength(50);

				entity.Property(e => e.Password)
					.IsRequired()
					.HasMaxLength(500);
			});

			OnModelCreatingPartial(modelBuilder);
		}

		partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
	}
}
