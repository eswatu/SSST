﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SSST.Data;

namespace SSST.Migrations
{
    [DbContext(typeof(SSSTContext))]
    [Migration("20200627043734_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SSST.Models.Siswa", b =>
                {
                    b.Property<int>("SiswaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SiswaAlamat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SiswaKelas")
                        .HasColumnType("int");

                    b.Property<string>("SiswaNama")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SiswaNim")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SiswaID");

                    b.ToTable("Siswa");
                });
#pragma warning restore 612, 618
        }
    }
}
