using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using parking_lot.Models;

#nullable disable

namespace parking_lot.Data
{
    public partial class parking_lotContext : DbContext
    {
        public parking_lotContext()
        {
        }

        public parking_lotContext(DbContextOptions<parking_lotContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ParkingLot> ParkingLots { get; set; }
        public virtual DbSet<ParkingLotSpaceType> ParkingLotSpaceTypes { get; set; }
        public virtual DbSet<ParkingSpace> ParkingSpaces { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }

        //Model for retrieving Parking space overview
        public virtual DbSet<ParkingOverview> ParkingOverview { get; set; }

        //Model for retrieving overview by vehicle type
        public virtual DbSet<OverviewByVehicle> OverviewByVehicle { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /**
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-PKV4O8U\\SQLEXPRESS;Initial Catalog=parking_lot;Integrated Security=True");
            }
            **/
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ParkingLot>(entity =>
            {
                entity.ToTable("parking_lot");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<ParkingLotSpaceType>(entity =>
            {
                entity.ToTable("parking_lot_space_type");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Weight)
                    .HasColumnName("weight")
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<ParkingSpace>(entity =>
            {
                entity.ToTable("parking_space");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IsFull)
                    .HasColumnName("is_full")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LeftSpace).HasColumnName("Left_space");

                entity.Property(e => e.Lot).HasColumnName("lot");

                entity.Property(e => e.RightSpace).HasColumnName("right_space");

                entity.Property(e => e.SpaceType).HasColumnName("space_type");

                entity.Property(e => e.Vehicle).HasColumnName("vehicle");
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.ToTable("vehicle");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Make)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("make");

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("model");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("type");
            });

            modelBuilder.Entity<ParkingOverview>(entity =>
            {
                entity.HasNoKey();

            });
            modelBuilder.Entity<OverviewByVehicle>(entity =>
            {
                entity.HasNoKey();

            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
