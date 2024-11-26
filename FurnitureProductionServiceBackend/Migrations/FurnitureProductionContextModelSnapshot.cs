﻿// <auto-generated />
using System;
using FurnitureProductionServiceBackend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FurnitureProductionServiceBackend.Migrations
{
    [DbContext(typeof(FurnitureProductionContext))]
    partial class FurnitureProductionContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EmployeeFurnituresProduction", b =>
                {
                    b.Property<int>("EmployeesId")
                        .HasColumnType("int");

                    b.Property<int>("FurnituresProductionsId")
                        .HasColumnType("int");

                    b.HasKey("EmployeesId", "FurnituresProductionsId");

                    b.HasIndex("FurnituresProductionsId");

                    b.ToTable("InvolvedEmployees", (string)null);
                });

            modelBuilder.Entity("FurnitureMaterial", b =>
                {
                    b.Property<int>("FurnituresId")
                        .HasColumnType("int");

                    b.Property<int>("MaterialsId")
                        .HasColumnType("int");

                    b.HasKey("FurnituresId", "MaterialsId");

                    b.HasIndex("MaterialsId");

                    b.ToTable("MaterialsInFurniture", (string)null);
                });

            modelBuilder.Entity("FurnitureProductionServiceBackend.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("FurnitureProductionServiceBackend.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ContactPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ManufactureId")
                        .HasColumnType("int");

                    b.Property<int>("SpecializationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ManufactureId");

                    b.HasIndex("SpecializationId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("FurnitureProductionServiceBackend.Models.EmployeeSpecialization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EmployeeSpecializations");
                });

            modelBuilder.Entity("FurnitureProductionServiceBackend.Models.Furniture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<double>("Depth")
                        .HasColumnType("float");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FurnitureCollectionId")
                        .HasColumnType("int");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Length")
                        .HasColumnType("float");

                    b.Property<double>("MaximumLoad")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.Property<double>("Width")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("FurnitureCollectionId");

                    b.ToTable("Furnitures");
                });

            modelBuilder.Entity("FurnitureProductionServiceBackend.Models.FurnitureCollection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CollectionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FurnitureCollections");
                });

            modelBuilder.Entity("FurnitureProductionServiceBackend.Models.FurnituresProduction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AccountNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("FurnitureId")
                        .HasColumnType("int");

                    b.Property<int>("QuantityOfProducedGoods")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalCost")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("FurnitureId");

                    b.HasIndex("StatusId");

                    b.ToTable("FurnituresProductions");
                });

            modelBuilder.Entity("FurnitureProductionServiceBackend.Models.Manufacture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<int>("ManufactureSpecializationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("ManufactureSpecializationId");

                    b.ToTable("Manufactures");
                });

            modelBuilder.Entity("FurnitureProductionServiceBackend.Models.ManufactureSpecialization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ManufactureSpecializations");
                });

            modelBuilder.Entity("FurnitureProductionServiceBackend.Models.Material", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaterialComponents")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Materials");
                });

            modelBuilder.Entity("FurnitureProductionServiceBackend.Models.ProductionStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("FurnitureProductionServiceBackend.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("FurnitureProductionServiceBackend.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EmployeeFurnituresProduction", b =>
                {
                    b.HasOne("FurnitureProductionServiceBackend.Models.Employee", null)
                        .WithMany()
                        .HasForeignKey("EmployeesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FurnitureProductionServiceBackend.Models.FurnituresProduction", null)
                        .WithMany()
                        .HasForeignKey("FurnituresProductionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FurnitureMaterial", b =>
                {
                    b.HasOne("FurnitureProductionServiceBackend.Models.Furniture", null)
                        .WithMany()
                        .HasForeignKey("FurnituresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FurnitureProductionServiceBackend.Models.Material", null)
                        .WithMany()
                        .HasForeignKey("MaterialsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FurnitureProductionServiceBackend.Models.Employee", b =>
                {
                    b.HasOne("FurnitureProductionServiceBackend.Models.Manufacture", "Manufacture")
                        .WithMany("Employees")
                        .HasForeignKey("ManufactureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FurnitureProductionServiceBackend.Models.EmployeeSpecialization", "EmployeeSpecialization")
                        .WithMany("Employees")
                        .HasForeignKey("SpecializationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EmployeeSpecialization");

                    b.Navigation("Manufacture");
                });

            modelBuilder.Entity("FurnitureProductionServiceBackend.Models.Furniture", b =>
                {
                    b.HasOne("FurnitureProductionServiceBackend.Models.FurnitureCollection", "FurnitureCollection")
                        .WithMany("Furnitures")
                        .HasForeignKey("FurnitureCollectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FurnitureCollection");
                });

            modelBuilder.Entity("FurnitureProductionServiceBackend.Models.FurnituresProduction", b =>
                {
                    b.HasOne("FurnitureProductionServiceBackend.Models.Furniture", "Furniture")
                        .WithMany()
                        .HasForeignKey("FurnitureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FurnitureProductionServiceBackend.Models.ProductionStatus", "Status")
                        .WithMany("FurnituresProductions")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Furniture");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("FurnitureProductionServiceBackend.Models.Manufacture", b =>
                {
                    b.HasOne("FurnitureProductionServiceBackend.Models.City", "City")
                        .WithMany("Manufactures")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FurnitureProductionServiceBackend.Models.ManufactureSpecialization", "ManufactureSpecialization")
                        .WithMany("Manufactures")
                        .HasForeignKey("ManufactureSpecializationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("ManufactureSpecialization");
                });

            modelBuilder.Entity("FurnitureProductionServiceBackend.Models.User", b =>
                {
                    b.HasOne("FurnitureProductionServiceBackend.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("FurnitureProductionServiceBackend.Models.City", b =>
                {
                    b.Navigation("Manufactures");
                });

            modelBuilder.Entity("FurnitureProductionServiceBackend.Models.EmployeeSpecialization", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("FurnitureProductionServiceBackend.Models.FurnitureCollection", b =>
                {
                    b.Navigation("Furnitures");
                });

            modelBuilder.Entity("FurnitureProductionServiceBackend.Models.Manufacture", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("FurnitureProductionServiceBackend.Models.ManufactureSpecialization", b =>
                {
                    b.Navigation("Manufactures");
                });

            modelBuilder.Entity("FurnitureProductionServiceBackend.Models.ProductionStatus", b =>
                {
                    b.Navigation("FurnituresProductions");
                });

            modelBuilder.Entity("FurnitureProductionServiceBackend.Models.Role", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
