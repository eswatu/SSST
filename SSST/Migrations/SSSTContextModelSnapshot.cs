﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SSST.Data;

namespace SSST.Migrations
{
    [DbContext(typeof(SSSTContext))]
    partial class SSSTContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SSST.Models.Guru", b =>
                {
                    b.Property<int>("GuruID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GuruNama")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GuruID");

                    b.ToTable("Guru");
                });

            modelBuilder.Entity("SSST.Models.Kelas", b =>
                {
                    b.Property<int>("KelasID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("KelasNama")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KelasTahun")
                        .HasColumnType("int");

                    b.Property<int>("guruPengampu")
                        .HasColumnType("int");

                    b.HasKey("KelasID");

                    b.ToTable("Kelas");
                });

            modelBuilder.Entity("SSST.Models.MataPelajaran", b =>
                {
                    b.Property<int>("MapelID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GuruMapel")
                        .HasColumnType("int");

                    b.Property<int>("MapelGrade")
                        .HasColumnType("int");

                    b.Property<string>("MapelNama")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MapelID");

                    b.ToTable("MataPelajaran");
                });

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
