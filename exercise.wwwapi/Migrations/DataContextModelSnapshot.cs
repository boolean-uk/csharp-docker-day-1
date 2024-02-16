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

                    b.Property<char>("AverageGrade")
                        .HasColumnType("character(1)")
                        .HasColumnName("average_grade");

                    b.Property<string>("CourseTitle")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("course_title");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("start_date");

                    b.HasKey("Id");

                    b.ToTable("courses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AverageGrade = 'B',
                            CourseTitle = "Mathematics",
                            StartDate = new DateTime(2024, 2, 16, 10, 6, 7, 298, DateTimeKind.Utc).AddTicks(2813)
                        },
                        new
                        {
                            Id = 2,
                            AverageGrade = 'D',
                            CourseTitle = "Physics",
                            StartDate = new DateTime(2024, 1, 17, 10, 6, 7, 298, DateTimeKind.Utc).AddTicks(2815)
                        },
                        new
                        {
                            Id = 3,
                            AverageGrade = 'C',
                            CourseTitle = "Biology",
                            StartDate = new DateTime(2023, 12, 18, 10, 6, 7, 298, DateTimeKind.Utc).AddTicks(2822)
                        });
                });

            modelBuilder.Entity("exercise.wwwapi.DataModels.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date_of_birth");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("last_name");

                    b.Property<int>("course")
                        .HasColumnType("integer")
                        .HasColumnName("fk_course");

                    b.HasKey("Id");

                    b.ToTable("students");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateOfBirth = new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                            FirstName = "John",
                            LastName = "Doe",
                            course = 0
                        },
                        new
                        {
                            Id = 2,
                            DateOfBirth = new DateTime(1999, 5, 10, 0, 0, 0, 0, DateTimeKind.Utc),
                            FirstName = "Alice",
                            LastName = "Smith",
                            course = 0
                        },
                        new
                        {
                            Id = 3,
                            DateOfBirth = new DateTime(2001, 8, 20, 0, 0, 0, 0, DateTimeKind.Utc),
                            FirstName = "Bob",
                            LastName = "Johnson",
                            course = 0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
