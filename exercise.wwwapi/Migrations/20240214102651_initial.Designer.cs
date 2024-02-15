﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using exercise.wwwapi.Data;

#nullable disable

namespace exercise.wwwapi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240214102651_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<float>("AverageGrade")
                        .HasColumnType("real")
                        .HasColumnName("average_grade");

                    b.Property<DateOnly>("CourseStartDate")
                        .HasColumnType("date")
                        .HasColumnName("course_start_date");

                    b.Property<string>("CourseTitle")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("course_title");

                    b.HasKey("Id");

                    b.ToTable("couses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AverageGrade = 1f,
                            CourseStartDate = new DateOnly(2024, 1, 4),
                            CourseTitle = "Title"
                        },
                        new
                        {
                            Id = 2,
                            AverageGrade = 3f,
                            CourseStartDate = new DateOnly(2024, 6, 15),
                            CourseTitle = "Another Title"
                        },
                        new
                        {
                            Id = 3,
                            AverageGrade = 2f,
                            CourseStartDate = new DateOnly(2025, 1, 26),
                            CourseTitle = "Yet another Title"
                        });
                });

            modelBuilder.Entity("exercise.wwwapi.DataModels.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CourseId")
                        .HasColumnType("integer")
                        .HasColumnName("course_id");

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("date")
                        .HasColumnName("date_of_birth");

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
                            CourseId = 1,
                            DateOfBirth = new DateOnly(2000, 1, 26),
                            FirstName = "First",
                            LastName = "Second"
                        },
                        new
                        {
                            Id = 2,
                            CourseId = 2,
                            DateOfBirth = new DateOnly(2000, 6, 3),
                            FirstName = "First",
                            LastName = "Third"
                        },
                        new
                        {
                            Id = 3,
                            CourseId = 1,
                            DateOfBirth = new DateOnly(2000, 12, 15),
                            FirstName = "First",
                            LastName = "Fourth"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
