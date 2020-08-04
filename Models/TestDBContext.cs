using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace InsuranceCore.Models
{
    public partial class TestDBContext : DbContext
    {
        public TestDBContext()
        {
        }

        public TestDBContext(DbContextOptions<TestDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contracts> Contracts { get; set; }
        public virtual DbSet<CoveragePlan> CoveragePlan { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<RateChart> RateChart { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.\\SQLExpress1111;Initial Catalog=TestDB;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contracts>(entity =>
            {
                entity.HasKey(e => e.CustomerId);

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Country)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CoveragePlan).HasMaxLength(50);

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("date");

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.SaleDate).HasColumnType("date");
            });

            modelBuilder.Entity<CoveragePlan>(entity =>
            {
                entity.HasKey(e => e.PlanId);

                entity.Property(e => e.PlanId).ValueGeneratedNever();

                entity.Property(e => e.EligibilityCountry).HasMaxLength(50);

                entity.Property(e => e.EligibilityDateFrom).HasColumnType("date");

                entity.Property(e => e.EligibilityDateTo).HasColumnType("date");

                entity.Property(e => e.Plan).HasMaxLength(50);
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("DEPARTMENT");

                entity.Property(e => e.Deptid).HasColumnName("deptid");

                entity.Property(e => e.Deptname)
                    .HasColumnName("deptname")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EMPLOYEE");

                entity.Property(e => e.Autoid)
                    .HasColumnName("AUTOID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Depid).HasColumnName("depid");

                entity.Property(e => e.Dob)
                    .HasColumnName("dob")
                    .HasColumnType("date");

                entity.Property(e => e.Empid).HasColumnName("empid");

                entity.Property(e => e.Empname)
                    .HasColumnName("empname")
                    .HasMaxLength(50);

                entity.Property(e => e.Managerid).HasColumnName("managerid");

                entity.Property(e => e.Salary).HasColumnName("salary");
            });

            modelBuilder.Entity<RateChart>(entity =>
            {
                entity.Property(e => e.Age).HasMaxLength(50);

                entity.Property(e => e.CoveragePlan).HasMaxLength(50);

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
