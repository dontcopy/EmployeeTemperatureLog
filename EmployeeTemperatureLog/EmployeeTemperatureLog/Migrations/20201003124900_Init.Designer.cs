﻿// <auto-generated />
using System;
using EmployeeTemperatureLog.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EmployeeTemperatureLog.Migrations
{
    [DbContext(typeof(EmpTempContext))]
    [Migration("20201003124900_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EmployeeTemperatureLog.Models.Employee", b =>
                {
                    b.Property<Guid>("EmployeeNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeNumber");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("EmployeeTemperatureLog.Models.TemperatureRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid?>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("RecordDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Temperature")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("TemperatureRecords");
                });

            modelBuilder.Entity("EmployeeTemperatureLog.Models.TemperatureRecord", b =>
                {
                    b.HasOne("EmployeeTemperatureLog.Models.Employee", "Employee")
                        .WithMany("TemperatureRecords")
                        .HasForeignKey("EmployeeId");
                });
#pragma warning restore 612, 618
        }
    }
}