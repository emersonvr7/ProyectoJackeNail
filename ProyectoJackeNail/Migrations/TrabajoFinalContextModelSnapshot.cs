﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyectoJackeNail.Models;

#nullable disable

namespace ProyectoJackeNail.Migrations
{
    [DbContext(typeof(TrabajoFinalContext))]
    partial class TrabajoFinalContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PermisosPorRol", b =>
                {
                    b.Property<int>("RolId")
                        .HasColumnType("int");

                    b.Property<int>("PermisoId")
                        .HasColumnType("int");

                    b.HasKey("RolId", "PermisoId")
                        .HasName("PK__Permisos__D04D0E835A48D70B");

                    b.HasIndex("PermisoId");

                    b.ToTable("PermisosPorRol", (string)null);
                });

            modelBuilder.Entity("ProyectoJackeNail.Models.Agendamiento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ClienteId")
                        .HasColumnType("int")
                        .HasColumnName("ClienteID");

                    b.Property<int?>("EmpleadoId")
                        .HasColumnType("int")
                        .HasColumnName("EmpleadoID");

                    b.Property<string>("EstadoAgenda")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<DateOnly?>("FechaAgenda")
                        .HasColumnType("date");

                    b.Property<int?>("ServicioId")
                        .HasColumnType("int")
                        .HasColumnName("ServicioID");

                    b.HasKey("Id")
                        .HasName("PK__Agendami__3214EC27EE3D06D8");

                    b.HasIndex("ClienteId");

                    b.HasIndex("EmpleadoId");

                    b.HasIndex("ServicioId");

                    b.ToTable("Agendamiento", (string)null);
                });

            modelBuilder.Entity("ProyectoJackeNail.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Correo")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Nombre")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("RolId")
                        .HasColumnType("int");

                    b.Property<string>("Telefono")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id")
                        .HasName("PK__Cliente__3214EC07E941F491");

                    b.HasIndex("RolId");

                    b.ToTable("Cliente", (string)null);
                });

            modelBuilder.Entity("ProyectoJackeNail.Models.Compra", b =>
                {
                    b.Property<int>("IdCompra")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCompra"));

                    b.Property<decimal?>("DescuentoCompra")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<int?>("EstadoCompra")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FechaCompra")
                        .HasColumnType("datetime");

                    b.Property<int?>("IdProveedor")
                        .HasColumnType("int");

                    b.Property<decimal?>("IvaCompra")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<decimal?>("SubtotalCompra")
                        .HasColumnType("decimal(10, 2)");

                    b.HasKey("IdCompra")
                        .HasName("PK__Compra__0A5CDB5CEDB8C48E");

                    b.HasIndex("IdProveedor");

                    b.ToTable("Compra", (string)null);
                });

            modelBuilder.Entity("ProyectoJackeNail.Models.Empleado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Correo")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Documento")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Nombre")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("RolId")
                        .HasColumnType("int");

                    b.Property<string>("Telefono")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id")
                        .HasName("PK__Empleado__3214EC07A8A6A39A");

                    b.HasIndex("RolId");

                    b.ToTable("Empleado", (string)null);
                });

            modelBuilder.Entity("ProyectoJackeNail.Models.Insumo", b =>
                {
                    b.Property<int>("IdInsumo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdInsumo"));

                    b.Property<int?>("CantidadInsumo")
                        .HasColumnType("int");

                    b.Property<int?>("EstadoInsumo")
                        .HasColumnType("int");

                    b.Property<string>("ImagenInsumo")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("NombreInsumo")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("UsosDisponibles")
                        .HasColumnType("int");

                    b.HasKey("IdInsumo")
                        .HasName("PK__Insumo__F378A2AF29A6993F");

                    b.ToTable("Insumo", (string)null);
                });

            modelBuilder.Entity("ProyectoJackeNail.Models.Permiso", b =>
                {
                    b.Property<int>("IdPermiso")
                        .HasColumnType("int");

                    b.Property<string>("NombrePermiso")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("IdPermiso")
                        .HasName("PK__Permisos__0D626EC8307527CA");

                    b.ToTable("Permisos");
                });

            modelBuilder.Entity("ProyectoJackeNail.Models.Proveedor", b =>
                {
                    b.Property<int>("IdProveedor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProveedor"));

                    b.Property<string>("CorreoProveedor")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("DireccionProveedor")
                        .HasMaxLength(40)
                        .IsUnicode(false)
                        .HasColumnType("varchar(40)");

                    b.Property<string>("EmpresaProveedor")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("EstadoProveedor")
                        .HasColumnType("int");

                    b.Property<string>("NombreProveedor")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("TelefonoProveedor")
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)");

                    b.HasKey("IdProveedor")
                        .HasName("PK__Proveedo__E8B631AF5FBA1E98");

                    b.ToTable("Proveedor", (string)null);
                });

            modelBuilder.Entity("ProyectoJackeNail.Models.Role", b =>
                {
                    b.Property<int>("IdRol")
                        .HasColumnType("int");

                    b.Property<string>("NombreRol")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("IdRol")
                        .HasName("PK__Roles__2A49584C9D0DA22D");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("ProyectoJackeNail.Models.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("EstadoServicio")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ImgServicio")
                        .HasMaxLength(2000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2000)");

                    b.Property<string>("NivelUña")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Precio")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Servicio")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Tiempo")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id")
                        .HasName("PK__Service__3214EC070A6F65D0");

                    b.ToTable("Service", (string)null);
                });

            modelBuilder.Entity("ProyectoJackeNail.Models.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<string>("ApellidoUsuario")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int?>("RolId")
                        .HasColumnType("int");

                    b.Property<string>("Telefono")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdUsuario")
                        .HasName("PK__Usuarios__5B65BF97A36D1022");

                    b.HasIndex("RolId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("ProyectoJackeNail.Models.Venta", b =>
                {
                    b.Property<int>("IdVenta")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaVenta")
                        .HasColumnType("datetime");

                    b.Property<int?>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int?>("IdEmpleado")
                        .HasColumnType("int");

                    b.Property<int?>("IdServicio")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalVenta")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("IdVenta")
                        .HasName("PK__Ventas__BC1240BD25AD6065");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdEmpleado");

                    b.HasIndex("IdServicio");

                    b.ToTable("Ventas");
                });

            modelBuilder.Entity("PermisosPorRol", b =>
                {
                    b.HasOne("ProyectoJackeNail.Models.Permiso", null)
                        .WithMany()
                        .HasForeignKey("PermisoId")
                        .IsRequired()
                        .HasConstraintName("FK__PermisosP__Permi__46E78A0C");

                    b.HasOne("ProyectoJackeNail.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RolId")
                        .IsRequired()
                        .HasConstraintName("FK__PermisosP__RolId__45F365D3");
                });

            modelBuilder.Entity("ProyectoJackeNail.Models.Agendamiento", b =>
                {
                    b.HasOne("ProyectoJackeNail.Models.Cliente", "Cliente")
                        .WithMany("Agendamientos")
                        .HasForeignKey("ClienteId")
                        .HasConstraintName("FK__Agendamie__Clien__52593CB8");

                    b.HasOne("ProyectoJackeNail.Models.Empleado", "Empleado")
                        .WithMany("Agendamientos")
                        .HasForeignKey("EmpleadoId")
                        .HasConstraintName("FK__Agendamie__Emple__534D60F1");

                    b.HasOne("ProyectoJackeNail.Models.Service", "Servicio")
                        .WithMany("Agendamientos")
                        .HasForeignKey("ServicioId")
                        .HasConstraintName("FK__Agendamie__Servi__5165187F");

                    b.Navigation("Cliente");

                    b.Navigation("Empleado");

                    b.Navigation("Servicio");
                });

            modelBuilder.Entity("ProyectoJackeNail.Models.Cliente", b =>
                {
                    b.HasOne("ProyectoJackeNail.Models.Role", "Rol")
                        .WithMany("Clientes")
                        .HasForeignKey("RolId")
                        .HasConstraintName("FK__Cliente__RolId__4E88ABD4");

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("ProyectoJackeNail.Models.Compra", b =>
                {
                    b.HasOne("ProyectoJackeNail.Models.Proveedor", "IdProveedorNavigation")
                        .WithMany("Compras")
                        .HasForeignKey("IdProveedor")
                        .HasConstraintName("FK__Compra__IdProvee__5CD6CB2B");

                    b.Navigation("IdProveedorNavigation");
                });

            modelBuilder.Entity("ProyectoJackeNail.Models.Empleado", b =>
                {
                    b.HasOne("ProyectoJackeNail.Models.Role", "Rol")
                        .WithMany("Empleados")
                        .HasForeignKey("RolId")
                        .HasConstraintName("FK__Empleado__RolId__4BAC3F29");

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("ProyectoJackeNail.Models.Usuario", b =>
                {
                    b.HasOne("ProyectoJackeNail.Models.Role", "Rol")
                        .WithMany("Usuarios")
                        .HasForeignKey("RolId")
                        .HasConstraintName("FK__Usuarios__RolId__4316F928");

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("ProyectoJackeNail.Models.Venta", b =>
                {
                    b.HasOne("ProyectoJackeNail.Models.Empleado", "IdClienteNavigation")
                        .WithMany("Venta")
                        .HasForeignKey("IdCliente")
                        .HasConstraintName("FK__Ventas__IdClient__5812160E");

                    b.HasOne("ProyectoJackeNail.Models.Cliente", "IdEmpleadoNavigation")
                        .WithMany("Venta")
                        .HasForeignKey("IdEmpleado")
                        .HasConstraintName("FK__Ventas__IdEmplea__571DF1D5");

                    b.HasOne("ProyectoJackeNail.Models.Service", "IdServicioNavigation")
                        .WithMany("Venta")
                        .HasForeignKey("IdServicio")
                        .HasConstraintName("FK__Ventas__IdServic__5629CD9C");

                    b.Navigation("IdClienteNavigation");

                    b.Navigation("IdEmpleadoNavigation");

                    b.Navigation("IdServicioNavigation");
                });

            modelBuilder.Entity("ProyectoJackeNail.Models.Cliente", b =>
                {
                    b.Navigation("Agendamientos");

                    b.Navigation("Venta");
                });

            modelBuilder.Entity("ProyectoJackeNail.Models.Empleado", b =>
                {
                    b.Navigation("Agendamientos");

                    b.Navigation("Venta");
                });

            modelBuilder.Entity("ProyectoJackeNail.Models.Proveedor", b =>
                {
                    b.Navigation("Compras");
                });

            modelBuilder.Entity("ProyectoJackeNail.Models.Role", b =>
                {
                    b.Navigation("Clientes");

                    b.Navigation("Empleados");

                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("ProyectoJackeNail.Models.Service", b =>
                {
                    b.Navigation("Agendamientos");

                    b.Navigation("Venta");
                });
#pragma warning restore 612, 618
        }
    }
}
