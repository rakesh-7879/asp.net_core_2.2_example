﻿// <auto-generated />
using System;
using FinalAssignment.DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FinalAssignment.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FinalAssignment.DataLayer.Entiry.Appraisal", b =>
                {
                    b.Property<int>("AppraisalId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CurrentAppraisal");

                    b.Property<int>("EmployeeId");

                    b.Property<string>("FilesName");

                    b.Property<DateTime>("NextAppraisal");

                    b.Property<string>("Remark")
                        .HasMaxLength(250);

                    b.HasKey("AppraisalId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Appraisals");
                });

            modelBuilder.Entity("FinalAssignment.DataLayer.Entiry.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("StateId");

                    b.HasKey("CityId");

                    b.HasIndex("StateId");

                    b.ToTable("Citys");
                });

            modelBuilder.Entity("FinalAssignment.DataLayer.Entiry.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("DepartmentId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("FinalAssignment.DataLayer.Entiry.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<int>("CityId");

                    b.Property<DateTime>("CreationDate");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<int>("DepartmentId");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime>("JoiningDate");

                    b.Property<DateTime>("LastModificationDate");

                    b.Property<DateTime>("LeavingDate");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("Zip")
                        .IsRequired()
                        .HasMaxLength(6);

                    b.HasKey("EmployeeId");

                    b.HasIndex("CityId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("FinalAssignment.DataLayer.Entiry.State", b =>
                {
                    b.Property<int>("StateId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StateName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("StateId");

                    b.ToTable("States");
                });

            modelBuilder.Entity("FinalAssignment.DataLayer.Entiry.Test1", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Test1");
                });

            modelBuilder.Entity("FinalAssignment.DataLayer.Entiry.Test2", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int>("TestId");

                    b.HasKey("Id");

                    b.HasIndex("TestId");

                    b.ToTable("Test2");
                });

            modelBuilder.Entity("FinalAssignment.DataLayer.Entiry.Appraisal", b =>
                {
                    b.HasOne("FinalAssignment.DataLayer.Entiry.Employee", "Employee")
                        .WithMany("Appraisals")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FinalAssignment.DataLayer.Entiry.City", b =>
                {
                    b.HasOne("FinalAssignment.DataLayer.Entiry.State", "State")
                        .WithMany("Cities")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FinalAssignment.DataLayer.Entiry.Employee", b =>
                {
                    b.HasOne("FinalAssignment.DataLayer.Entiry.City", "City")
                        .WithMany("Employees")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FinalAssignment.DataLayer.Entiry.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FinalAssignment.DataLayer.Entiry.Test2", b =>
                {
                    b.HasOne("FinalAssignment.DataLayer.Entiry.Test1")
                        .WithMany("Test2s")
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
