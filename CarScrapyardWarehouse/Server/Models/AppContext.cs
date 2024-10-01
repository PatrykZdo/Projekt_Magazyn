using System;
using System.Collections.Generic;
using CarScrapyardWarehouse.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Attribute = CarScrapyardWarehouse.Shared.Models.Attribute;

namespace CarScrapyardWarehouse.Server.Models
{
    public partial class AppContext : DbContext
    {
        public AppContext()
        {
        }

        public AppContext(DbContextOptions<AppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<Attribute> Attributes { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Part> Parts { get; set; }
        public virtual DbSet<PartImage> PartImages { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<VehicleAttributeValue> VehicleAttributeValues { get; set; }
        public virtual DbSet<VehicleImage> VehicleImages { get; set; }
        public virtual DbSet<VehicleTypeAttribute> VehicleTypeAttributes { get; set; }
        public virtual DbSet<VehiclesType> VehiclesTypes { get; set; }
        public virtual DbSet<Warehouse> Warehouses { get; set; }
        public virtual DbSet<PartsCategory> PartsCatergories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Area>(entity =>
            {
                entity.ToTable("areas", "part_hub");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AreaCode)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("area_code");

                entity.Property(e => e.AreaName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("area_name");

                entity.Property(e => e.IdWarehouse).HasColumnName("id_warehouse");

                entity.HasOne(d => d.IdWarehouseNavigation)
                    .WithMany(p => p.Areas)
                    .HasForeignKey(d => d.IdWarehouse)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_warehouse");
            });

            modelBuilder.Entity<Attribute>(entity =>
            {
                entity.ToTable("attributes", "part_hub");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AttriburteName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("attriburte_name");

                entity.Property(e => e.DefaultValue)
                    .HasMaxLength(255)
                    .HasColumnName("default_value");

                entity.Property(e => e.StaticValues)
                    .HasMaxLength(255)
                    .HasColumnName("static_values");

                entity.Property(e => e.Type)
                    .HasMaxLength(255)
                    .HasColumnName("type");

                entity.Property(e => e.Unit)
                    .HasMaxLength(255)
                    .HasColumnName("unit");
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.ToTable("images", "part_hub");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Image1)
                    .IsRequired()
                    .HasColumnName("image");
            });

            modelBuilder.Entity<PartsCategory>(entity =>
            {
                entity.ToTable("parts_category", "part_hub");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CategoryName).HasColumnName("category_name");
			});

            modelBuilder.Entity<Part>(entity =>
            {
                entity.ToTable("parts", "part_hub");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Archived)
                    .HasColumnName("archived");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.IdPosition).HasColumnName("id_position");

                entity.Property(e => e.IdVehicle).HasColumnName("id_vehicle");

                entity.Property(e => e.InsertDate)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("insert_date");

                entity.Property(e => e.IsWaste).HasColumnName("is_waste");

                entity.Property(e => e.IdCategory).HasColumnName("id_category");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.User)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("user");

                entity.HasOne(d => d.IdPositionNavigation)
                    .WithMany(p => p.Parts)
                    .HasForeignKey(d => d.IdPosition)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_position");

                entity.HasOne(d => d.IdVehicleNavigation)
                    .WithMany(p => p.Parts)
                    .HasForeignKey(d => d.IdVehicle)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_vehicle");

                entity.HasOne(d => d.IdPartCategoryNavigation)
                    .WithMany(p => p.Parts)
                    .HasForeignKey(d => d.IdCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_category");
            });

            modelBuilder.Entity<PartImage>(entity =>
            {
                entity.ToTable("part_images", "part_hub");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdImage).HasColumnName("id_image");

                entity.Property(e => e.IdPart).HasColumnName("id_part");

                entity.Property(e => e.InsertDate)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("insert_date");

                entity.HasOne(d => d.IdImageNavigation)
                    .WithMany(p => p.PartImages)
                    .HasForeignKey(d => d.IdImage)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_image");

                entity.HasOne(d => d.IdPartNavigation)
                    .WithMany(p => p.PartImages)
                    .HasForeignKey(d => d.IdPart)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_part");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.ToTable("positions", "part_hub");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdArea).HasColumnName("id_area");

                entity.Property(e => e.PositionCode)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("position_code");

                entity.Property(e => e.PositionName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("position_name");

                entity.HasOne(d => d.IdAreaNavigation)
                    .WithMany(p => p.Positions)
                    .HasForeignKey(d => d.IdArea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_area");
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.ToTable("vehicles", "part_hub");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdType).HasColumnName("id_type");

                entity.Property(e => e.InsertDate)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("insert_date");

                entity.Property(e => e.Vin)
                    .HasMaxLength(255)
                    .HasColumnName("vin");

                entity.Property(e => e.Brand)
                    .HasMaxLength(255)
                    .HasColumnName("brand");
                
                entity.Property(e => e.Model)
                    .HasMaxLength(255)
                    .HasColumnName("model");
                
                entity.Property(e => e.Year)
                    .HasColumnName("year");

                entity.Property(e => e.User)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("user");

                entity.Property(e => e.PurchasePrice)
                    .HasColumnName("purchase_price");

                entity.Property(e => e.Archived)
                    .HasColumnName("archived");

                entity.HasOne(d => d.IdTypeNavigation)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.IdType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("vehicles_fk0");
            });

            modelBuilder.Entity<VehicleAttributeValue>(entity =>
            {
                entity.ToTable("vehicle_attribute_values", "part_hub");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdAttribute).HasColumnName("id_attribute");

                entity.Property(e => e.IdVehicle).HasColumnName("id_vehicle");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("value");

                entity.HasOne(d => d.IdAttributeNavigation)
                    .WithMany(p => p.VehicleAttributeValues)
                    .HasForeignKey(d => d.IdAttribute)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_attribute");

                entity.HasOne(d => d.IdVehicleNavigation)
                    .WithMany(p => p.VehicleAttributeValues)
                    .HasForeignKey(d => d.IdVehicle)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_vehicle");
            });

            modelBuilder.Entity<VehicleImage>(entity =>
            {
                entity.ToTable("vehicle_images", "part_hub");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdImage).HasColumnName("id_image");

                entity.Property(e => e.IdVehicle).HasColumnName("id_vehicle");

                entity.Property(e => e.InsertDate)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("insert_date");

                entity.HasOne(d => d.IdImageNavigation)
                    .WithMany(p => p.VehicleImages)
                    .HasForeignKey(d => d.IdImage)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_image");

                entity.HasOne(d => d.IdVehicleNavigation)
                    .WithMany(p => p.VehicleImages)
                    .HasForeignKey(d => d.IdVehicle)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_vehicle");
            });

            modelBuilder.Entity<VehicleTypeAttribute>(entity =>
            {
                entity.ToTable("vehicle_type_attributes", "part_hub");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdAttribute).HasColumnName("id_attribute");

                entity.Property(e => e.IdVehiclesType).HasColumnName("id_vehicles_type");

                entity.Property(e => e.OrderNumber).HasColumnName("order_number");

                entity.HasOne(d => d.IdAttributeNavigation)
                    .WithMany(p => p.VehicleTypeAttributes)
                    .HasForeignKey(d => d.IdAttribute)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("vehicle_type_attributes_fk0");

                entity.HasOne(d => d.IdVehiclesTypeNavigation)
                    .WithMany(p => p.VehicleTypeAttributes)
                    .HasForeignKey(d => d.IdVehiclesType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("vehicle_type_attributes_fk1");
            });

            modelBuilder.Entity<VehiclesType>(entity =>
            {
                entity.ToTable("vehicles_types", "part_hub");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("type");
            });

            modelBuilder.Entity<Warehouse>(entity =>
            {
                entity.ToTable("warehouses", "part_hub");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.WarehouseCode)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("warehouse_code");

                entity.Property(e => e.WarehouseName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("warehouse_name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
