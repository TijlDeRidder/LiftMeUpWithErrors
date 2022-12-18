﻿// <auto-generated />
using System;
using LiftMeUp2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LiftMeUp2.Migrations
{
    [DbContext(typeof(LiftMeUp2Context))]
    [Migration("20221217213743_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("LiftMeUp2.Models.Lift", b =>
                {
                    b.Property<int>("liftId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("liftId"), 1L, 1);

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("isWorking")
                        .HasColumnType("bit");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("stationId")
                        .HasColumnType("int");

                    b.HasKey("liftId");

                    b.ToTable("Lift");
                });

            modelBuilder.Entity("LiftMeUp2.Models.Melding", b =>
                {
                    b.Property<int>("MeldingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MeldingId"), 1L, 1);

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("liftId")
                        .HasColumnType("int");

                    b.Property<DateTime>("startDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("stationId")
                        .HasColumnType("int");

                    b.Property<string>("uitleg")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MeldingId");

                    b.ToTable("Melding");
                });

            modelBuilder.Entity("LiftMeUp2.Models.Station", b =>
                {
                    b.Property<int>("stationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("stationId"), 1L, 1);

                    b.Property<bool>("hasElevator")
                        .HasColumnType("bit");

                    b.Property<bool>("isAccesible")
                        .HasColumnType("bit");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("stationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("stationId");

                    b.ToTable("Station");
                });
#pragma warning restore 612, 618
        }
    }
}