﻿// <auto-generated />
using System;
using GarageUsingDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GarageUsingDB.Migrations
{
    [DbContext(typeof(GarageContext))]
    [Migration("20220531155650_GarageDB")]
    partial class GarageDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GarageUsingDB.Models.Car", b =>
                {
                    b.Property<int>("LicensePlate")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10)
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LicensePlate"), 1L, 1);

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Manufacturer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.HasKey("LicensePlate");

                    b.ToTable("cars");
                });

            modelBuilder.Entity("GarageUsingDB.Models.Garage", b =>
                {
                    b.Property<int>("ReferenceNumber")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(8)
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReferenceNumber"), 1L, 1);

                    b.Property<double>("CostToFix")
                        .HasColumnType("float");

                    b.Property<DateTime>("EnteredGarage")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsFixed")
                        .HasColumnType("bit");

                    b.Property<int>("LicensePlate")
                        .HasColumnType("int");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<string>("OwnerName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ReferenceNumber");

                    b.ToTable("Garage");
                });

            modelBuilder.Entity("GarageUsingDB.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("peoples");
                });
#pragma warning restore 612, 618
        }
    }
}
