﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuartetDBAppEFCore;

#nullable disable

namespace QuartetDBAppEFCore.Migrations
{
    [DbContext(typeof(QuartetScoreDBContext))]
    [Migration("20240410014947_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("QuartetDBAppEFCore.QuartetScore", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MusScore")
                        .HasColumnType("int");

                    b.Property<int>("PerScore")
                        .HasColumnType("int");

                    b.Property<string>("QuartetName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SngScore")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("QuartetScores");
                });
#pragma warning restore 612, 618
        }
    }
}
