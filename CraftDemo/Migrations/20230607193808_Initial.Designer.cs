﻿// <auto-generated />
using System;
using CraftDemo.Database.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CraftDemo.Migrations
{
    [DbContext(typeof(CraftDemoConfig))]
    [Migration("20230607193808_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CraftDemo.Database.Data.Models.GitHubUserInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(63)
                        .HasColumnType("nvarchar(63)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(39)
                        .HasColumnType("nvarchar(39)");

                    b.HasKey("Id");

                    b.ToTable("GitHubUserInfo");
                });
#pragma warning restore 612, 618
        }
    }
}
