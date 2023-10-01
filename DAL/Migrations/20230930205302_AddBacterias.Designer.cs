﻿// <auto-generated />
using System.Collections.Generic;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(CholecystitisContext))]
    [Migration("20230930205302_AddBacterias")]
    partial class AddBacterias
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CholecystitStone", b =>
                {
                    b.Property<int>("CholecystitsId")
                        .HasColumnType("integer");

                    b.Property<int>("StonesId")
                        .HasColumnType("integer");

                    b.HasKey("CholecystitsId", "StonesId");

                    b.HasIndex("StonesId");

                    b.ToTable("CholecystitStone");
                });

            modelBuilder.Entity("DAL.Model.Bacterium", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Bacteriums");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Escherichia coli"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Klebsiella spp"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Enterobacter spp"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Bacteroides"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Clostridia spp"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Fusobacterium spp"
                        },
                        new
                        {
                            Id = 7,
                            Name = "enterococci"
                        });
                });

            modelBuilder.Entity("DAL.Model.Cholecystit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<List<int>>("BacteriasIds")
                        .HasColumnType("integer[]");

                    b.Property<string>("CausedComplications")
                        .HasColumnType("text");

                    b.Property<int>("Degree")
                        .HasColumnType("integer");

                    b.Property<string>("Histology")
                        .HasColumnType("text");

                    b.Property<string>("Pathophysiology")
                        .HasColumnType("text");

                    b.Property<string>("Symptoms")
                        .HasColumnType("text");

                    b.Property<string>("Treatment")
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Cholecystits");
                });

            modelBuilder.Entity("DAL.Model.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("integer");

                    b.Property<int>("CholecystitId")
                        .HasColumnType("integer");

                    b.Property<int>("Gender")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("RiskFactors")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CholecystitId")
                        .IsUnique();

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("DAL.Model.Stone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Color")
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<string>("Сomposition")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Stones");
                });

            modelBuilder.Entity("CholecystitStone", b =>
                {
                    b.HasOne("DAL.Model.Cholecystit", null)
                        .WithMany()
                        .HasForeignKey("CholecystitsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Model.Stone", null)
                        .WithMany()
                        .HasForeignKey("StonesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DAL.Model.Patient", b =>
                {
                    b.HasOne("DAL.Model.Cholecystit", "Cholecystit")
                        .WithOne("Patient")
                        .HasForeignKey("DAL.Model.Patient", "CholecystitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cholecystit");
                });

            modelBuilder.Entity("DAL.Model.Cholecystit", b =>
                {
                    b.Navigation("Patient");
                });
#pragma warning restore 612, 618
        }
    }
}
