﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NZWalksAPI.Data;

#nullable disable

namespace NZWalksAPI.Migrations
{
    [DbContext(typeof(NZWalksDbContext))]
    [Migration("20250102121514_seeding region and dificulties")]
    partial class seedingregionanddificulties
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NZWalksAPI.Models.Domains.Dificulty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("dificulties");

                    b.HasData(
                        new
                        {
                            Id = new Guid("2512c7f7-d46b-4328-9a9c-57aa6ca7e1c5"),
                            Name = "Easy"
                        },
                        new
                        {
                            Id = new Guid("047ac5c3-ff02-4843-b378-01ccbd237444"),
                            Name = "Medium"
                        },
                        new
                        {
                            Id = new Guid("605f416a-44dc-467e-bc95-5400c26bb0de"),
                            Name = "Hard"
                        },
                        new
                        {
                            Id = new Guid("5359fa24-b74c-475f-9f64-d3cfeb40e436"),
                            Name = "Nigeria"
                        },
                        new
                        {
                            Id = new Guid("a1b2c3d4-e5f6-7890-1234-567890abcdef"),
                            Name = "United States"
                        },
                        new
                        {
                            Id = new Guid("b2c3d4e5-f678-9012-3456-7890abcdef01"),
                            Name = "Canada"
                        },
                        new
                        {
                            Id = new Guid("c3d4e5f6-7890-1234-5678-90abcdef0123"),
                            Name = "United Kingdom"
                        },
                        new
                        {
                            Id = new Guid("d4e5f678-9012-3456-7890-abcdef012345"),
                            Name = "Japan"
                        });
                });

            modelBuilder.Entity("NZWalksAPI.Models.Domains.Region", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegionImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("NZWalksAPI.Models.Domains.Walk", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("DifcultyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DificultyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RegionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("WalkImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lenghtInKm")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DificultyId");

                    b.HasIndex("RegionId");

                    b.ToTable("Walks");
                });

            modelBuilder.Entity("NZWalksAPI.Models.Domains.Walk", b =>
                {
                    b.HasOne("NZWalksAPI.Models.Domains.Dificulty", "Dificulty")
                        .WithMany()
                        .HasForeignKey("DificultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NZWalksAPI.Models.Domains.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dificulty");

                    b.Navigation("Region");
                });
#pragma warning restore 612, 618
        }
    }
}
