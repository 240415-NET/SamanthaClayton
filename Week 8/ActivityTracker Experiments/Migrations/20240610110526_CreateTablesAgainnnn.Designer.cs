﻿// <auto-generated />
using System;
using ActivityTracker.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ActivityTracker.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240610110526_CreateTablesAgainnnn")]
    partial class CreateTablesAgainnnn
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("SQL_Latin1_General_CP1_CS_AS")
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ActivityTracker.Models.Activity", b =>
                {
                    b.Property<Guid>("activityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateOnly>("Date_OfActivity")
                        .HasColumnType("date");

                    b.Property<TimeOnly>("Time_OfActivity")
                        .HasColumnType("time");

                    b.Property<string>("activity_Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nameOfPerson")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("userId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("activityID");

                    b.HasIndex("userId");

                    b.ToTable("Activity", (string)null);

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("ActivityTracker.Models.User", b =>
                {
                    b.Property<Guid>("userId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("userEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("user_FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("user_LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("userId");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("ActivityTracker.Models.Activity", b =>
                {
                    b.HasOne("ActivityTracker.Models.User", "user")
                        .WithMany("activitys")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("ActivityTracker.Models.User", b =>
                {
                    b.Navigation("activitys");
                });
#pragma warning restore 612, 618
        }
    }
}