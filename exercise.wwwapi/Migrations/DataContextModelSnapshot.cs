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

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("birthdate");

                    b.Property<DateTime>("CourseStartDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("start_date");

                    b.Property<string>("CourseTitle")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("course_title");

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
                            AverageGrade = 3.5f,
                            Birthdate = new DateTime(2000, 1, 14, 23, 0, 0, 0, DateTimeKind.Utc),
                            CourseStartDate = new DateTime(2023, 8, 31, 22, 0, 0, 0, DateTimeKind.Utc),
                            CourseTitle = "Computer Science",
                            FirstName = "John",
                            LastName = "Doe"
                        },
                        new
                        {
                            Id = 2,
                            AverageGrade = 3.8f,
                            Birthdate = new DateTime(1999, 5, 21, 22, 0, 0, 0, DateTimeKind.Utc),
                            CourseStartDate = new DateTime(2023, 8, 31, 22, 0, 0, 0, DateTimeKind.Utc),
                            CourseTitle = "Mathematics",
                            FirstName = "Jane",
                            LastName = "Smith"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
