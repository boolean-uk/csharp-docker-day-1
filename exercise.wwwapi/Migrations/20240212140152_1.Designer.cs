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
    [Migration("20240212140152_1")]
    partial class _1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("exercise.wwwapi.DataModels.CourseModels.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Starts")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("startDate");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.ToTable("course");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Starts = new DateTime(2024, 2, 12, 14, 1, 51, 764, DateTimeKind.Utc).AddTicks(494),
                            Title = "Mathematics"
                        },
                        new
                        {
                            Id = 2,
                            Starts = new DateTime(2024, 2, 12, 14, 1, 51, 764, DateTimeKind.Utc).AddTicks(498),
                            Title = "Physics"
                        });
                });

            modelBuilder.Entity("exercise.wwwapi.DataModels.StudentModels.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("AverageGrade")
                        .HasColumnType("double precision")
                        .HasColumnName("average_grade");

                    b.Property<int>("CourseId")
                        .HasColumnType("integer")
                        .HasColumnName("course_id");

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

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("student");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AverageGrade = 85.5,
                            CourseId = 1,
                            DateOfBirth = new DateTime(2024, 2, 12, 14, 1, 51, 764, DateTimeKind.Utc).AddTicks(693),
                            FirstName = "John",
                            LastName = "Doe"
                        },
                        new
                        {
                            Id = 2,
                            AverageGrade = 78.200000000000003,
                            CourseId = 2,
                            DateOfBirth = new DateTime(2024, 2, 12, 14, 1, 51, 764, DateTimeKind.Utc).AddTicks(699),
                            FirstName = "Jane",
                            LastName = "Smith"
                        });
                });

            modelBuilder.Entity("exercise.wwwapi.DataModels.StudentModels.Student", b =>
                {
                    b.HasOne("exercise.wwwapi.DataModels.CourseModels.Course", "Course")
                        .WithMany("Students")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("exercise.wwwapi.DataModels.CourseModels.Course", b =>
                {
                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
