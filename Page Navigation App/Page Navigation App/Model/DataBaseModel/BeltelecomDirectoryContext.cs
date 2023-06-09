﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Page_Navigation_App.Model.Entity;

namespace Page_Navigation_App.Model.DataBaseModel;

public partial class BeltelecomDirectoryContext : DbContext
{
    public BeltelecomDirectoryContext()
    {
    }

    public BeltelecomDirectoryContext(DbContextOptions<BeltelecomDirectoryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Unit> Units { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BeltelecomDirectory;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Cyrillic_General_100_CI_AS");

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Categori__6DB38D4E7E591A88");

            entity.Property(e => e.CategoryId).HasColumnName("Category_ID");
            entity.Property(e => e.CategoryType)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Category_Type");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__Departme__151675D1FCF3E1B0");

            entity.Property(e => e.DepartmentId).HasColumnName("Department_ID");
            entity.Property(e => e.DepartmentCity)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Department_City");
            entity.Property(e => e.DepartmentName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Department_Name");
            entity.Property(e => e.DepartmentPhoneNumber)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Department_PhoneNumber");
            entity.Property(e => e.DepartmentSpecification)
                .IsRequired()
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Department_Specification");
            entity.Property(e => e.DepartmentStreet)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Department_Street");
            entity.Property(e => e.EmployeeCount).HasColumnName("Employee_Count");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__78113481E5D5CED4");

            entity.Property(e => e.EmployeeId).HasColumnName("Employee_ID");
            entity.Property(e => e.BirthDate)
                .HasColumnType("date")
                .HasColumnName("Birth_Date");
            entity.Property(e => e.DepartmentId).HasColumnName("Department_ID");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("First_Name");
            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Last_Name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.PositionId).HasColumnName("Position_ID");
            entity.Property(e => e.UniqueNumber)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Unique_Number");

            entity.HasOne(d => d.Department).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_Department");

            entity.HasOne(d => d.Position).WithMany(p => p.Employees)
                .HasForeignKey(d => d.PositionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_Position");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.PositionId).HasName("PK__Position__3C3EAFE6B078993B");

            entity.Property(e => e.PositionId).HasColumnName("Position_ID");
            entity.Property(e => e.PositionDescription)
                .IsRequired()
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Position_Description");
            entity.Property(e => e.PositionName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Position_Name");
            entity.Property(e => e.UnitId).HasColumnName("Unit_ID");

            entity.HasOne(d => d.Unit).WithMany(p => p.Positions)
                .HasForeignKey(d => d.UnitId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Position_Unit");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.ServiceId).HasName("PK__Services__BD1A239C4E588DAD");

            entity.Property(e => e.ServiceId).HasColumnName("Service_ID");
            entity.Property(e => e.CategoryId).HasColumnName("Category_ID");
            entity.Property(e => e.Price).HasColumnType("decimal(8, 2)");
            entity.Property(e => e.ServiceCategoryType).HasColumnName("Service_Category_Type");
            entity.Property(e => e.ServiceDescription)
                .HasColumnType("text")
                .HasColumnName("Service_Description");
            entity.Property(e => e.ServiceName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Service_Name");

            entity.HasOne(d => d.Category).WithMany(p => p.Services)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Service_Category");
        });

        modelBuilder.Entity<Unit>(entity =>
        {
            entity.HasKey(e => e.UnitId).HasName("PK__Units__27556B9829279FB9");

            entity.Property(e => e.UnitId).HasColumnName("Unit_ID");
            entity.Property(e => e.DepartmentId).HasColumnName("Department_ID");
            entity.Property(e => e.UnitDescription)
                .IsRequired()
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Unit_Description");
            entity.Property(e => e.UnitName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Unit_Name");

            entity.HasOne(d => d.Department).WithMany(p => p.Units)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Unit_Department");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__206D919099A4B251");

            entity.Property(e => e.UserId).HasColumnName("User_ID");
            entity.Property(e => e.EmployeeId).HasColumnName("Employee_ID");
            entity.Property(e => e.Login)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Role)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Employee).WithMany(p => p.Users)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Employee");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
