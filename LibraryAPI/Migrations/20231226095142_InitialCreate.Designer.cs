﻿// <auto-generated />
using System;
using LibraryAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LibraryAPI.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20231226095142_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("LibraryAPI.Models.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("article_id");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date")
                        .HasColumnName("article_date");

                    b.Property<string>("Text")
                        .HasColumnType("longtext")
                        .HasColumnName("article_text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("article_title");

                    b.HasKey("Id");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("LibraryAPI.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("book_id");

                    b.Property<double>("AverageRating")
                        .HasColumnType("double")
                        .HasColumnName("book_averagerating");

                    b.Property<string>("Description")
                        .HasColumnType("longtext")
                        .HasColumnName("book_description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("book_name");

                    b.Property<int>("TimesRated")
                        .HasColumnType("int")
                        .HasColumnName("book_timesrated");

                    b.Property<int>("Year")
                        .HasColumnType("int")
                        .HasColumnName("book_year");

                    b.HasKey("Id");

                    b.ToTable("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
