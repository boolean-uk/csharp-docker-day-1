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
                        .HasColumnName("averageGrade");

                    b.Property<DateTime>("StartsAt")
                        .HasColumnType("date")
                        .HasColumnName("startsAt");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.ToTable("Course");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AverageGrade = 'A',
                            StartsAt = new DateTime(2024, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = ".NET Boolean Academy"
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
                        .HasColumnName("courseId");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("date")
                        .HasColumnName("dateOfBirth");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("firstName");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("lastName");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("student");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CourseId = 1,
                            DateOfBirth = new DateTime(1928, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Bjorg",
                            LastName = "Kristiansen"
                        });
                });

            modelBuilder.Entity("exercise.wwwapi.DataModels.Student", b =>
                {
                    b.HasOne("exercise.wwwapi.DataModels.Course", "course")
                        .WithMany("Students")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("course");
                });

            modelBuilder.Entity("exercise.wwwapi.DataModels.Course", b =>
                {
                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
