using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DAL.Models;

#nullable disable

namespace DAL.Data
{
    public partial class TelevisionRadioCompanyContext : DbContext
    {
        public TelevisionRadioCompanyContext()
        {
        }

        public TelevisionRadioCompanyContext(DbContextOptions<TelevisionRadioCompanyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<RadioStation> RadioStations { get; set; }
        public virtual DbSet<Residence> Residences { get; set; }
        public virtual DbSet<Resident> Residents { get; set; }
        public virtual DbSet<Street> Streets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=TelevisionRadioCompany;Username=postgres;Password=qaz16073011");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Ukrainian_Ukraine.1251");

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("address");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Flat).HasColumnName("flat");

                entity.Property(e => e.House).HasColumnName("house");

                entity.Property(e => e.StreetId).HasColumnName("street_id");

                entity.HasOne(d => d.Street)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.StreetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("address_street_id_fkey");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("company");

                entity.HasIndex(e => e.Name, "company_name_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AddressId).HasColumnName("address_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("phone");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Companies)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("company_address_id_fkey");
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.ToTable("district");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.RadioStationId).HasColumnName("radio_station_id");

                entity.HasOne(d => d.RadioStation)
                    .WithMany(p => p.Districts)
                    .HasForeignKey(d => d.RadioStationId)
                    .HasConstraintName("district_radio_station_id_fkey");
            });

            modelBuilder.Entity<RadioStation>(entity =>
            {
                entity.ToTable("radio_station");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.RadioStations)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("radio_station_company_id_fkey");
            });

            modelBuilder.Entity<Residence>(entity =>
            {
                entity.ToTable("residence");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AddressId).HasColumnName("address_id");

                entity.Property(e => e.ResidentId).HasColumnName("resident_id");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Residences)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("residence_address_id_fkey");

                entity.HasOne(d => d.Resident)
                    .WithMany(p => p.Residences)
                    .HasForeignKey(d => d.ResidentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("residence_resident_id_fkey");
            });

            modelBuilder.Entity<Resident>(entity =>
            {
                entity.ToTable("resident");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Street>(entity =>
            {
                entity.ToTable("street");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DistrictId).HasColumnName("district_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.HasOne(d => d.District)
                    .WithMany(p => p.Streets)
                    .HasForeignKey(d => d.DistrictId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("street_district_id_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
