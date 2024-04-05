using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProyectoJackeNail.Models;

public partial class TrabajoFinalContext : DbContext
{
    public TrabajoFinalContext()
    {
    }

    public TrabajoFinalContext(DbContextOptions<TrabajoFinalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Agendamiento> Agendamientos { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Compra> Compras { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Insumo> Insumos { get; set; }

    public virtual DbSet<Permiso> Permisos { get; set; }

    public virtual DbSet<Proveedor> Proveedors { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Venta> Ventas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured)
        {
        //    #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        //=> optionsBuilder.UseSqlServer("Server=EMERSON\\MSSQLSERVERS;Initial Catalog=TrabajoFinal;integrated security=true; TrustServerCertificate=true");


        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Agendamiento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Agendami__3214EC27EE3D06D8");

            entity.ToTable("Agendamiento");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.EmpleadoId).HasColumnName("EmpleadoID");
            entity.Property(e => e.EstadoAgenda)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ServicioId).HasColumnName("ServicioID");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Agendamientos)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK__Agendamie__Clien__52593CB8");

            entity.HasOne(d => d.Empleado).WithMany(p => p.Agendamientos)
                .HasForeignKey(d => d.EmpleadoId)
                .HasConstraintName("FK__Agendamie__Emple__534D60F1");

            entity.HasOne(d => d.Servicio).WithMany(p => p.Agendamientos)
                .HasForeignKey(d => d.ServicioId)
                .HasConstraintName("FK__Agendamie__Servi__5165187F");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cliente__3214EC07E941F491");

            entity.ToTable("Cliente");

            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Rol).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.RolId)
                .HasConstraintName("FK__Cliente__RolId__4E88ABD4");
        });

        modelBuilder.Entity<Compra>(entity =>
        {
            entity.HasKey(e => e.IdCompra).HasName("PK__Compra__0A5CDB5CEDB8C48E");

            entity.ToTable("Compra");

            entity.Property(e => e.DescuentoCompra).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.FechaCompra).HasColumnType("datetime");
            entity.Property(e => e.IvaCompra).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.SubtotalCompra).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.Compras)
                .HasForeignKey(d => d.IdProveedor)
                .HasConstraintName("FK__Compra__IdProvee__5CD6CB2B");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Empleado__3214EC07A8A6A39A");

            entity.ToTable("Empleado");

            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Documento)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Rol).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.RolId)
                .HasConstraintName("FK__Empleado__RolId__4BAC3F29");
        });

        modelBuilder.Entity<Insumo>(entity =>
        {
            entity.HasKey(e => e.IdInsumo).HasName("PK__Insumo__F378A2AF29A6993F");

            entity.ToTable("Insumo");

            entity.Property(e => e.ImagenInsumo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NombreInsumo)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Permiso>(entity =>
        {
            entity.HasKey(e => e.IdPermiso).HasName("PK__Permisos__0D626EC8307527CA");

            entity.Property(e => e.IdPermiso).ValueGeneratedNever();
            entity.Property(e => e.NombrePermiso).HasMaxLength(40);
        });

        modelBuilder.Entity<Proveedor>(entity =>
        {
            entity.HasKey(e => e.IdProveedor).HasName("PK__Proveedo__E8B631AF5FBA1E98");

            entity.ToTable("Proveedor");

            entity.Property(e => e.CorreoProveedor)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DireccionProveedor)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.EmpresaProveedor)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NombreProveedor)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TelefonoProveedor)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Roles__2A49584C9D0DA22D");

            entity.Property(e => e.IdRol).ValueGeneratedNever();
            entity.Property(e => e.NombreRol).HasMaxLength(40);

            entity.HasMany(d => d.Permisos).WithMany(p => p.Rols)
                .UsingEntity<Dictionary<string, object>>(
                    "PermisosPorRol",
                    r => r.HasOne<Permiso>().WithMany()
                        .HasForeignKey("PermisoId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__PermisosP__Permi__46E78A0C"),
                    l => l.HasOne<Role>().WithMany()
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__PermisosP__RolId__45F365D3"),
                    j =>
                    {
                        j.HasKey("RolId", "PermisoId").HasName("PK__Permisos__D04D0E835A48D70B");
                        j.ToTable("PermisosPorRol");
                    });
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Service__3214EC070A6F65D0");

            entity.ToTable("Service");

            entity.Property(e => e.EstadoServicio)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ImgServicio)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.NivelUña)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Precio)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Servicio)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Tiempo)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuarios__5B65BF97A36D1022");

            entity.Property(e => e.IdUsuario).ValueGeneratedNever();
            entity.Property(e => e.ApellidoUsuario).HasMaxLength(40);
            entity.Property(e => e.Correo).HasMaxLength(50);
            entity.Property(e => e.NombreUsuario).HasMaxLength(40);
            entity.Property(e => e.Telefono).HasMaxLength(20);

            entity.HasOne(d => d.Rol).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.RolId)
                .HasConstraintName("FK__Usuarios__RolId__4316F928");
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.IdVenta).HasName("PK__Ventas__BC1240BD25AD6065");

            entity.Property(e => e.IdVenta).ValueGeneratedNever();
            entity.Property(e => e.FechaVenta).HasColumnType("datetime");
            entity.Property(e => e.TotalVenta).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__Ventas__IdClient__5812160E");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdEmpleado)
                .HasConstraintName("FK__Ventas__IdEmplea__571DF1D5");

            entity.HasOne(d => d.IdServicioNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdServicio)
                .HasConstraintName("FK__Ventas__IdServic__5629CD9C");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
