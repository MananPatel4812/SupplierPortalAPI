using System;
using System.Collections.Generic;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccess.DataActionsContext
{
    public partial class SupplierPortalDBContext : DbContext
    {
        public SupplierPortalDBContext()
        {
        }

        public SupplierPortalDBContext(DbContextOptions<SupplierPortalDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AssociatePipeline> AssociatePipelines { get; set; } = null!;
        public virtual DbSet<Contact> Contacts { get; set; } = null!;
        public virtual DbSet<DocumentRequiredStatus> DocumentRequiredStatuses { get; set; } = null!;
        public virtual DbSet<DocumentStatus> DocumentStatuses { get; set; } = null!;
        public virtual DbSet<DocumentType> DocumentTypes { get; set; } = null!;
        public virtual DbSet<Facility> Facilities { get; set; } = null!;
        public virtual DbSet<FacilityReportingPeriodDataStatus> FacilityReportingPeriodDataStatuses { get; set; } = null!;
        public virtual DbSet<FacilityRequiredDocumentType> FacilityRequiredDocumentTypes { get; set; } = null!;
        public virtual DbSet<ReportingPeriod> ReportingPeriods { get; set; } = null!;
        public virtual DbSet<ReportingPeriodFacility> ReportingPeriodFacilities { get; set; } = null!;
        public virtual DbSet<ReportingPeriodFacilityDocument> ReportingPeriodFacilityDocuments { get; set; } = null!;
        public virtual DbSet<ReportingPeriodStatus> ReportingPeriodStatuses { get; set; } = null!;
        public virtual DbSet<ReportingPeriodSupplier> ReportingPeriodSuppliers { get; set; } = null!;
        public virtual DbSet<ReportingPeriodSupplierDocument> ReportingPeriodSupplierDocuments { get; set; } = null!;
        public virtual DbSet<ReportingPeriodType> ReportingPeriodTypes { get; set; } = null!;
        public virtual DbSet<ReportingType> ReportingTypes { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Supplier> Suppliers { get; set; } = null!;
        public virtual DbSet<SupplierReportingPeriodStatus> SupplierReportingPeriodStatuses { get; set; } = null!;
        public virtual DbSet<SupplyChainStage> SupplyChainStages { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=DBConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssociatePipeline>(entity =>
            {
                entity.ToTable("AssociatePipeline");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.UpdatedBy).HasMaxLength(100);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("Contact");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Contacts)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contact_Supplier");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Contacts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contact_User");
            });

            modelBuilder.Entity<DocumentRequiredStatus>(entity =>
            {
                entity.ToTable("DocumentRequiredStatus");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<DocumentStatus>(entity =>
            {
                entity.ToTable("DocumentStatus");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<DocumentType>(entity =>
            {
                entity.ToTable("DocumentType");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Facility>(entity =>
            {
                entity.ToTable("Facility");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.UpdatedBy).HasMaxLength(100);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.AssociatePipeline)
                    .WithMany(p => p.Facilities)
                    .HasForeignKey(d => d.AssociatePipelineId)
                    .HasConstraintName("FK_Facility_AssociatePipeline");

                entity.HasOne(d => d.ReportingType)
                    .WithMany(p => p.Facilities)
                    .HasForeignKey(d => d.ReportingTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Facility_ReportingType");

                entity.HasOne(d => d.SupplyChainStage)
                    .WithMany(p => p.Facilities)
                    .HasForeignKey(d => d.SupplyChainStageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Facility_SupplyChainStage");
            });

            modelBuilder.Entity<FacilityReportingPeriodDataStatus>(entity =>
            {
                entity.ToTable("FacilityReportingPeriodDataStatus");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<FacilityRequiredDocumentType>(entity =>
            {
                entity.ToTable("FacilityRequiredDocumentType");

                entity.HasOne(d => d.DocumentRequiredStatus)
                    .WithMany(p => p.FacilityRequiredDocumentTypes)
                    .HasForeignKey(d => d.DocumentRequiredStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FacilityRequiredDocumentType_DocumentRequiredStatus");

                entity.HasOne(d => d.DocumentType)
                    .WithMany(p => p.FacilityRequiredDocumentTypes)
                    .HasForeignKey(d => d.DocumentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FacilityRequiredDocumentType_DocumentType");

                entity.HasOne(d => d.ReportingType)
                    .WithMany(p => p.FacilityRequiredDocumentTypes)
                    .HasForeignKey(d => d.ReportingTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FacilityRequiredDocumentType_ReportingType");

                entity.HasOne(d => d.SupplyChainStage)
                    .WithMany(p => p.FacilityRequiredDocumentTypes)
                    .HasForeignKey(d => d.SupplyChainStageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FacilityRequiredDocumentType_SupplyChainStage");
            });

            modelBuilder.Entity<ReportingPeriod>(entity =>
            {
                entity.ToTable("ReportingPeriod");

                entity.Property(e => e.CollectionTimePeriod).HasMaxLength(100);

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(100);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.ReportingPeriodStatus)
                    .WithMany(p => p.ReportingPeriods)
                    .HasForeignKey(d => d.ReportingPeriodStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReportingPeriod_ReportingPeriodStatus");

                entity.HasOne(d => d.ReportingPeriodType)
                    .WithMany(p => p.ReportingPeriods)
                    .HasForeignKey(d => d.ReportingPeriodTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReportingPeriod_ReportingPeriodType");
            });

            modelBuilder.Entity<ReportingPeriodFacility>(entity =>
            {
                entity.ToTable("ReportingPeriodFacility");

                entity.HasOne(d => d.Facility)
                    .WithMany(p => p.ReportingPeriodFacilities)
                    .HasForeignKey(d => d.FacilityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReportingPeriodFacility_Facility");

                entity.HasOne(d => d.FacilityReportingPeriodDataStatus)
                    .WithMany(p => p.ReportingPeriodFacilities)
                    .HasForeignKey(d => d.FacilityReportingPeriodDataStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReportingPeriodFacility_FacilityReportingPeriodDataStatus");

                entity.HasOne(d => d.ReportingPeriodSupplier)
                    .WithMany(p => p.ReportingPeriodFacilities)
                    .HasForeignKey(d => d.ReportingPeriodSupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReportingPeriodFacility_ReportingPeriodSupplier");

                entity.HasOne(d => d.ReportingType)
                    .WithMany(p => p.ReportingPeriodFacilities)
                    .HasForeignKey(d => d.ReportingTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReportingPeriodFacility_ReportingType");
            });

            modelBuilder.Entity<ReportingPeriodFacilityDocument>(entity =>
            {
                entity.ToTable("ReportingPeriodFacilityDocument");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdatedBy).HasMaxLength(100);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.Version).HasMaxLength(50);

                entity.HasOne(d => d.DocumentStatus)
                    .WithMany(p => p.ReportingPeriodFacilityDocuments)
                    .HasForeignKey(d => d.DocumentStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReportingPeriodFacilityDocument_DocumentStatus");

                entity.HasOne(d => d.DocumentType)
                    .WithMany(p => p.ReportingPeriodFacilityDocuments)
                    .HasForeignKey(d => d.DocumentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReportingPeriodFacilityDocument_DocumentType");

                entity.HasOne(d => d.ReportingPeriodFacility)
                    .WithMany(p => p.ReportingPeriodFacilityDocuments)
                    .HasForeignKey(d => d.ReportingPeriodFacilityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReportingPeriodFacilityDocument_ReportingPeriodFacility");
            });

            modelBuilder.Entity<ReportingPeriodStatus>(entity =>
            {
                entity.ToTable("ReportingPeriodStatus");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<ReportingPeriodSupplier>(entity =>
            {
                entity.ToTable("ReportingPeriodSupplier");

                entity.HasOne(d => d.ReportingPeriod)
                    .WithMany(p => p.ReportingPeriodSuppliers)
                    .HasForeignKey(d => d.ReportingPeriodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReportingPeriodSupplier_ReportingPeriod");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.ReportingPeriodSuppliers)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReportingPeriodSupplier_Supplier");

                entity.HasOne(d => d.SupplierReportingPeriodStatus)
                    .WithMany(p => p.ReportingPeriodSuppliers)
                    .HasForeignKey(d => d.SupplierReportingPeriodStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReportingPeriodSupplier_SupplierReportingPeriodStatus");
            });

            modelBuilder.Entity<ReportingPeriodSupplierDocument>(entity =>
            {
                entity.ToTable("ReportingPeriodSupplierDocument");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdatedBy).HasMaxLength(100);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.Version).HasMaxLength(50);

                entity.HasOne(d => d.DocumentStatus)
                    .WithMany(p => p.ReportingPeriodSupplierDocuments)
                    .HasForeignKey(d => d.DocumentStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReportingPeriodSupplierDocument_DocumentStatus");

                entity.HasOne(d => d.DocumentType)
                    .WithMany(p => p.ReportingPeriodSupplierDocuments)
                    .HasForeignKey(d => d.DocumentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReportingPeriodSupplierDocument_DocumentType");

                entity.HasOne(d => d.ReportingPeriodSupplier)
                    .WithMany(p => p.ReportingPeriodSupplierDocuments)
                    .HasForeignKey(d => d.ReportingPeriodSupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReportingPeriodSupplierDocument_ReportingPeriodSupplier");
            });

            modelBuilder.Entity<ReportingPeriodType>(entity =>
            {
                entity.ToTable("ReportingPeriodType");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<ReportingType>(entity =>
            {
                entity.ToTable("ReportingType");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.ToTable("Supplier");

                entity.Property(e => e.Alias).HasMaxLength(100);

                entity.Property(e => e.ContactNo).HasMaxLength(50);

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.UpdatedBy).HasMaxLength(100);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<SupplierReportingPeriodStatus>(entity =>
            {
                entity.ToTable("SupplierReportingPeriodStatus");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<SupplyChainStage>(entity =>
            {
                entity.ToTable("SupplyChainStage");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.ContactNo).HasMaxLength(50);

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.UpdatedBy).HasMaxLength(100);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
