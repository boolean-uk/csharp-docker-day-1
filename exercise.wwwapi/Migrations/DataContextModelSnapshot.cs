﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using exercise.wwwapi.Data;

#nullable disable

namespace exercise.wwwapi.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("exercise.wwwapi.DataModels.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("start_date");

                    b.Property<string>("Teacher")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("teacher");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.ToTable("courses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            StartDate = new DateTime(2024, 3, 9, 19, 30, 47, 132, DateTimeKind.Utc).AddTicks(4891),
                            Teacher = "Ms. Rosamund",
                            Title = "Math"
                        },
                        new
                        {
                            Id = 2,
                            StartDate = new DateTime(2024, 3, 9, 19, 30, 47, 132, DateTimeKind.Utc).AddTicks(4976),
                            Teacher = "Mr. Dostoyevski",
                            Title = "Literature"
                        },
                        new
                        {
                            Id = 3,
                            StartDate = new DateTime(2024, 3, 9, 19, 30, 47, 132, DateTimeKind.Utc).AddTicks(4981),
                            Teacher = "Mr. Bacon",
                            Title = "Arts"
                        });
                });

            modelBuilder.Entity("exercise.wwwapi.DataModels.CourseStudent", b =>
                {
                    b.Property<int>("CourseId")
                        .HasColumnType("integer")
                        .HasColumnName("course_id");

                    b.Property<int>("StudentId")
                        .HasColumnType("integer")
                        .HasColumnName("student_id");

                    b.HasKey("CourseId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("CourseStudents");

                    b.HasData(
                        new
                        {
                            CourseId = 1,
                            StudentId = 1
                        },
                        new
                        {
                            CourseId = 3,
                            StudentId = 1
                        },
                        new
                        {
                            CourseId = 2,
                            StudentId = 2
                        },
                        new
                        {
                            CourseId = 3,
                            StudentId = 3
                        });
                });

            modelBuilder.Entity("exercise.wwwapi.DataModels.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<float>("AverageGrade")
                        .HasColumnType("real")
                        .HasColumnName("average_grade");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("dob");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("last_name");

                    b.HasKey("Id");

                    b.ToTable("students");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AverageGrade = 3f,
                            DOB = new DateTime(2024, 3, 9, 19, 30, 47, 132, DateTimeKind.Utc).AddTicks(5061),
                            FirstName = "Sandra",
                            LastName = "Collins"
                        },
                        new
                        {
                            Id = 2,
                            AverageGrade = 4f,
                            DOB = new DateTime(2024, 3, 9, 19, 30, 47, 132, DateTimeKind.Utc).AddTicks(5068),
                            FirstName = "Mike",
                            LastName = "Smith"
                        },
                        new
                        {
                            Id = 3,
                            AverageGrade = 5f,
                            DOB = new DateTime(2024, 3, 9, 19, 30, 47, 132, DateTimeKind.Utc).AddTicks(5072),
                            FirstName = "Heather",
                            LastName = "Dunst"
                        });
                });

            modelBuilder.Entity("exercise.wwwapi.DataModels.CourseStudent", b =>
                {
                    b.HasOne("exercise.wwwapi.DataModels.Course", "Course")
                        .WithMany("CourseStudents")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("exercise.wwwapi.DataModels.Student", "Student")
                        .WithMany("CourseStudent")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("exercise.wwwapi.DataModels.Course", b =>
                {
                    b.Navigation("CourseStudents");
                });

            modelBuilder.Entity("exercise.wwwapi.DataModels.Student", b =>
                {
                    b.Navigation("CourseStudent");
                });
#pragma warning restore 612, 618
        }
    }
}
