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
    [Migration("20240917065318_newMigration")]
    partial class newMigration
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

                    b.Property<DateTime>("CourseStart")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("courseStart");

                    b.Property<string>("CourseTitle")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("courseTitle");

                    b.HasKey("Id");

                    b.ToTable("courses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CourseStart = new DateTime(2024, 9, 17, 6, 53, 18, 463, DateTimeKind.Utc).AddTicks(1051),
                            CourseTitle = "c#"
                        });
                });

            modelBuilder.Entity("exercise.wwwapi.DataModels.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("AvgGrade")
                        .HasColumnType("numeric")
                        .HasColumnName("averageGrade");

                    b.Property<int>("CourseId")
                        .HasColumnType("integer")
                        .HasColumnName("courseId");

                    b.Property<int>("DateOfBirth")
                        .HasColumnType("integer")
                        .HasColumnName("dateofbirth");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("firstname");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("lastname");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("students");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AvgGrade = 10m,
                            CourseId = 1,
                            DateOfBirth = 1995,
                            FirstName = "Robert",
                            LastName = "Grey"
                        });
                });

            modelBuilder.Entity("exercise.wwwapi.DataModels.Student", b =>
                {
                    b.HasOne("exercise.wwwapi.DataModels.Course", "Course")
                        .WithMany("Students")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("exercise.wwwapi.DataModels.Course", b =>
                {
                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}