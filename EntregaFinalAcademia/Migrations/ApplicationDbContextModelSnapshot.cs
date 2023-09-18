﻿// <auto-generated />
using System;
using EntregaFinalAcademia.DataAcess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EntregaFinalAcademia.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<double>("Costo")
                        .HasColumnType("float")
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
                            Costo = 2000.0,
                            Estado = true,
                            Fecha = new DateTime(2023, 9, 16, 18, 53, 33, 159, DateTimeKind.Local).AddTicks(7619),
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

                    b.Property<bool>("Estado")
                        .HasColumnType("bit")
                        .HasColumnName("proyect_estado");

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
                            Estado = true,
                            Nombre = "Proyecto 1"
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
                            Description = "Consulta",
                            Name = "Consulta"
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
                        .HasColumnType("VARCHAR(60)")
                        .HasColumnName("user_clave");

                    b.Property<double>("Dni")
                        .HasColumnType("float")
                        .HasColumnName("user_dni");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit")
                        .HasColumnName("user_estado");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("user_nombre");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("Tipo")
                        .HasColumnType("int")
                        .HasColumnName("user_tipo");

                    b.HasKey("CodUsuario");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            CodUsuario = 1,
                            Clave = "",
                            Dni = 40951295.0,
                            Estado = true,
                            Nombre = "Pedro",
                            Tipo = 1
                        });
                });

            modelBuilder.Entity("EntregaFinalAcademia.Entities.User", b =>
                {
                    b.HasOne("EntregaFinalAcademia.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.Navigation("Role");
                });
#pragma warning restore 612, 618
        }
    }
}