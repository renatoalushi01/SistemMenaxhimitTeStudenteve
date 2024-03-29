﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemMenaxhimitTeStudenteve.Repository;

namespace SistemMenaxhimitTeStudenteve.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20210602134803_fixDb")]
    partial class fixDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SistemMenaxhimitTeStudenteve.Models.Lendet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Emer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Info")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Lendet");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Emer = "Lenda1",
                            Info = "Test Test"
                        },
                        new
                        {
                            Id = 2,
                            Emer = "Lenda2",
                            Info = "Test Test"
                        },
                        new
                        {
                            Id = 3,
                            Emer = "Lenda3",
                            Info = "Test Test"
                        },
                        new
                        {
                            Id = 4,
                            Emer = "Lenda4",
                            Info = "Test Test"
                        });
                });

            modelBuilder.Entity("SistemMenaxhimitTeStudenteve.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Emer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fjalkalimi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mbiemer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("NotaMesartare")
                        .HasColumnType("float");

                    b.Property<string>("ProfesioniDeshiruar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TedhenaTePergj")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("SistemMenaxhimitTeStudenteve.Models.StudentLend", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int>("LendId")
                        .HasColumnType("int");

                    b.Property<int?>("LendetId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<bool>("Subscribe")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("LendetId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentLends");
                });

            modelBuilder.Entity("SistemMenaxhimitTeStudenteve.Models.StudentLend", b =>
                {
                    b.HasOne("SistemMenaxhimitTeStudenteve.Models.Lendet", "Lendet")
                        .WithMany()
                        .HasForeignKey("LendetId");

                    b.HasOne("SistemMenaxhimitTeStudenteve.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
