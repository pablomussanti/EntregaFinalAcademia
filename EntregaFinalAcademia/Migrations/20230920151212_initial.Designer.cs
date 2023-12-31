﻿// <auto-generated />
using System;
using EntregaFinalAcademia.DataAcess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EntregaFinalAcademia.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230920151212_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EntregaFinalAcademia.Entities.Job", b =>
                {
                    b.Property<int>("CodTrabajo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("job_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodTrabajo"), 1L, 1);

                    b.Property<int>("CantHoras")
                        .HasColumnType("int")
                        .HasColumnName("job_cantHoras");

                    b.Property<int>("CodProyecto")
                        .HasColumnType("int");

                    b.Property<int>("CodServicio")
                        .HasColumnType("int");

                    b.Property<decimal>("Costo")
                        .HasColumnType("decimal(38,17)")
                        .HasColumnName("job_costo");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit")
                        .HasColumnName("job_estado");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("date")
                        .HasColumnName("job_date");

                    b.Property<double>("ValorHora")
                        .HasColumnType("float")
                        .HasColumnName("job_valorHora");

                    b.HasKey("CodTrabajo");

                    b.ToTable("Jobs");

                    b.HasData(
                        new
                        {
                            CodTrabajo = 1,
                            CantHoras = 20,
                            CodProyecto = 1,
                            CodServicio = 1,
                            Costo = 2000m,
                            Estado = true,
                            Fecha = new DateTime(2023, 9, 20, 12, 12, 12, 217, DateTimeKind.Local).AddTicks(594),
                            ValorHora = 100.0
                        });
                });

            modelBuilder.Entity("EntregaFinalAcademia.Entities.Proyect", b =>
                {
                    b.Property<int>("CodProyecto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("proyect_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodProyecto"), 1L, 1);

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("proyect_direccion");

                    b.Property<int>("Estado")
                        .HasColumnType("int")
                        .HasColumnName("proyect_estado");

                    b.Property<bool>("EstadoActivo")
                        .HasColumnType("bit")
                        .HasColumnName("proyect_estadoActivo");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("proyect_nombre");

                    b.HasKey("CodProyecto");

                    b.ToTable("Proyects");

                    b.HasData(
                        new
                        {
                            CodProyecto = 1,
                            Direccion = "Santa Fe 29475",
                            Estado = 1,
                            EstadoActivo = true,
                            Nombre = "Proyecto A"
                        },
                        new
                        {
                            CodProyecto = 2,
                            Direccion = "Suipacha 2923",
                            Estado = 2,
                            EstadoActivo = true,
                            Nombre = "Proyecto B"
                        },
                        new
                        {
                            CodProyecto = 3,
                            Direccion = "Ferro 14545",
                            Estado = 3,
                            EstadoActivo = true,
                            Nombre = "Proyecto C"
                        });
                });

            modelBuilder.Entity("EntregaFinalAcademia.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("role_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit")
                        .HasColumnName("role_activo");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("role_description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("role_name");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Activo = true,
                            Description = "Admin",
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Activo = true,
                            Description = "Consultor",
                            Name = "Consultor"
                        });
                });

            modelBuilder.Entity("EntregaFinalAcademia.Entities.Service", b =>
                {
                    b.Property<int>("codServicio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("service_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("codServicio"), 1L, 1);

                    b.Property<string>("descr")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("service_descr");

                    b.Property<bool>("estado")
                        .HasColumnType("bit")
                        .HasColumnName("service_estado");

                    b.Property<double>("valorHora")
                        .HasColumnType("float")
                        .HasColumnName("service_valorHora");

                    b.HasKey("codServicio");

                    b.ToTable("Services");

                    b.HasData(
                        new
                        {
                            codServicio = 1,
                            descr = "Reparacion",
                            estado = true,
                            valorHora = 250.0
                        },
                        new
                        {
                            codServicio = 2,
                            descr = "Mantenimiento",
                            estado = true,
                            valorHora = 100.0
                        });
                });

            modelBuilder.Entity("EntregaFinalAcademia.Entities.User", b =>
                {
                    b.Property<int>("CodUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodUsuario"), 1L, 1);

                    b.Property<string>("Clave")
                        .IsRequired()
                        .HasColumnType("VARCHAR(250)")
                        .HasColumnName("user_clave");

                    b.Property<double>("Dni")
                        .HasColumnType("float")
                        .HasColumnName("user_dni");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("user_email");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit")
                        .HasColumnName("user_estado");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("user_nombre");

                    b.Property<int>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("role_id");

                    b.HasKey("CodUsuario");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            CodUsuario = 1,
                            Clave = "e5c92d3ab3273a76fc60e0358552affe0e7f3fc68287c6f3bd463400cf7309c3",
                            Dni = 11111111.0,
                            Email = "admin@hotmail.com",
                            Estado = true,
                            Nombre = "Admin",
                            RoleId = 1
                        });
                });

            modelBuilder.Entity("EntregaFinalAcademia.Entities.User", b =>
                {
                    b.HasOne("EntregaFinalAcademia.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });
#pragma warning restore 612, 618
        }
    }
}
