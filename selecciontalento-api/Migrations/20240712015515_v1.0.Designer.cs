﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using selecciontalento_api.Repositories;

#nullable disable

namespace selecciontalento_api.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240712015515_v1.0")]
    partial class v10
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("selecciontalento_api.Models.Estados", b =>
                {
                    b.Property<int>("EstId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("EstCategory")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("EstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("EstId");

                    b.ToTable("Estados");
                });

            modelBuilder.Entity("selecciontalento_api.Models.Roles", b =>
                {
                    b.Property<int>("RolId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("RolDescription")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("RolName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("RolId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("selecciontalento_api.Models.Usuarios", b =>
                {
                    b.Property<int>("UsuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("EstId")
                        .HasColumnType("int");

                    b.Property<int>("RolId")
                        .HasColumnType("int");

                    b.Property<string>("UsuAdicionalArchive")
                        .HasColumnType("longtext");

                    b.Property<int>("UsuAttempts")
                        .HasColumnType("int");

                    b.Property<string>("UsuEmail")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("UsuLastName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("UsuName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("UsuNumDni")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("UsuNumPhone")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("UsuPassword")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UsuProfilePicture")
                        .HasColumnType("longtext");

                    b.Property<string>("UsuTypeDni")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("varchar(2)");

                    b.HasKey("UsuId");

                    b.HasIndex("EstId");

                    b.HasIndex("RolId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("selecciontalento_api.Models.Usuarios", b =>
                {
                    b.HasOne("selecciontalento_api.Models.Estados", "Estado")
                        .WithMany("Usuarios")
                        .HasForeignKey("EstId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("selecciontalento_api.Models.Roles", "Rol")
                        .WithMany("Usuarios")
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estado");

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("selecciontalento_api.Models.Estados", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("selecciontalento_api.Models.Roles", b =>
                {
                    b.Navigation("Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
