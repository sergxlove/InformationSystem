﻿// <auto-generated />
using System;
using InformationSystem.DataAccess.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InformationSystem.DataAccess.Sqlite.Migrations
{
    [DbContext(typeof(InformationSystemDbContext))]
    partial class InformationSystemDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("InformationSystem.DataAccess.Sqlite.Models.GroupsEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Specialization")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Groups", (string)null);
                });

            modelBuilder.Entity("InformationSystem.DataAccess.Sqlite.Models.ResultSessionEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly>("DateResult")
                        .HasColumnType("TEXT");

                    b.Property<int>("Grade")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdStudent")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdSubject")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Semestr")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("IdStudent");

                    b.HasIndex("IdSubject");

                    b.ToTable("ResultSession", (string)null);
                });

            modelBuilder.Entity("InformationSystem.DataAccess.Sqlite.Models.StudentsEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("IdGroup")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SecondName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("IdGroup");

                    b.ToTable("Students", (string)null);
                });

            modelBuilder.Entity("InformationSystem.DataAccess.Sqlite.Models.SubjectsEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("IdTeacher")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("IdTeacher");

                    b.ToTable("Subjects", (string)null);
                });

            modelBuilder.Entity("InformationSystem.DataAccess.Sqlite.Models.TeachersEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<string>("Departament")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SecondName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Teachers", (string)null);
                });

            modelBuilder.Entity("InformationSystem.DataAccess.Sqlite.Models.UsersEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("StudentsEntitySubjectsEntity", b =>
                {
                    b.Property<int>("StudentsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SubjectsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("StudentsId", "SubjectsId");

                    b.HasIndex("SubjectsId");

                    b.ToTable("StudentsEntitySubjectsEntity");
                });

            modelBuilder.Entity("InformationSystem.DataAccess.Sqlite.Models.ResultSessionEntity", b =>
                {
                    b.HasOne("InformationSystem.DataAccess.Sqlite.Models.StudentsEntity", "Students")
                        .WithMany("Results")
                        .HasForeignKey("IdStudent")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InformationSystem.DataAccess.Sqlite.Models.SubjectsEntity", "Subjects")
                        .WithMany("Results")
                        .HasForeignKey("IdSubject")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Students");

                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("InformationSystem.DataAccess.Sqlite.Models.StudentsEntity", b =>
                {
                    b.HasOne("InformationSystem.DataAccess.Sqlite.Models.GroupsEntity", "Group")
                        .WithMany("Students")
                        .HasForeignKey("IdGroup")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");
                });

            modelBuilder.Entity("InformationSystem.DataAccess.Sqlite.Models.SubjectsEntity", b =>
                {
                    b.HasOne("InformationSystem.DataAccess.Sqlite.Models.TeachersEntity", "Teachers")
                        .WithMany("Subjects")
                        .HasForeignKey("IdTeacher")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teachers");
                });

            modelBuilder.Entity("StudentsEntitySubjectsEntity", b =>
                {
                    b.HasOne("InformationSystem.DataAccess.Sqlite.Models.StudentsEntity", null)
                        .WithMany()
                        .HasForeignKey("StudentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InformationSystem.DataAccess.Sqlite.Models.SubjectsEntity", null)
                        .WithMany()
                        .HasForeignKey("SubjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InformationSystem.DataAccess.Sqlite.Models.GroupsEntity", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("InformationSystem.DataAccess.Sqlite.Models.StudentsEntity", b =>
                {
                    b.Navigation("Results");
                });

            modelBuilder.Entity("InformationSystem.DataAccess.Sqlite.Models.SubjectsEntity", b =>
                {
                    b.Navigation("Results");
                });

            modelBuilder.Entity("InformationSystem.DataAccess.Sqlite.Models.TeachersEntity", b =>
                {
                    b.Navigation("Subjects");
                });
#pragma warning restore 612, 618
        }
    }
}
