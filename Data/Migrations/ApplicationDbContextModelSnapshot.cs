﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SlownikObcy2.Data;

namespace SlownikObcy2.Data.Migrations
{
    [DbContext(typeof(SlownikObcy2Context))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SlownikObcy2.Models.Angielski", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Obcy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Polski")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Angielski");
                });

            modelBuilder.Entity("SlownikObcy2.Models.Japonski", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Kana")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Kanji")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Polski")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Romaji")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Japonski");
                });
#pragma warning restore 612, 618
        }
    }
}
