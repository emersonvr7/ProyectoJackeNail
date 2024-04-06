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

    public virtual DbSet<DetalleCompra> DetalleCompras { get; set; }

    public virtual DbSet<DetalleVentum> DetalleVenta { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Insumo> Insumos { get; set; }

    public virtual DbSet<Permiso> Permisos { get; set; }

    public virtual DbSet<PermisosPorRol> PermisosPorRols { get; set; }

    public virtual DbSet<Proveedor> Proveedors { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Venta> Ventas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Agendamiento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Agendami__3214EC27C827C081");

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
                .HasConstraintName("FK__Agendamie__Clien__49C3F6B7");

            entity.HasOne(d => d.Empleado).WithMany(p => p.Agendamientos)
                .HasForeignKey(d => d.EmpleadoId)
                .HasConstraintName("FK__Agendamie__Emple__4AB81AF0");

            entity.HasOne(d => d.Servicio).WithMany(p => p.Agendamientos)
                .HasForeignKey(d => d.ServicioId)
                .HasConstraintName("FK__Agendamie__Servi__48CFD27E");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cliente__3214EC0742EED453");

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
                .HasConstraintName("FK__Cliente__RolId__45F365D3");
        });

        modelBuilder.Entity<Compra>(entity =>
        {
            entity.HasKey(e => e.IdCompra).HasName("PK__Compra__0A5CDB5C6E63C7ED");

            entity.ToTable("Compra");

            entity.Property(e => e.DescuentoCompra).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.FechaCompra).HasColumnType("datetime");
            entity.Property(e => e.IvaCompra).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.SubtotalCompra).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.Compras)
                .HasForeignKey(d => d.IdProveedor)
                .HasConstraintName("FK__Compra__IdProvee__5441852A");
        });

        modelBuilder.Entity<DetalleCompra>(entity =>
        {
            entity.HasKey(e => e.IdDetalle).HasName("PK__DetalleC__E43646A53AC81008");

            entity.ToTable("DetalleCompra");

            entity.Property(e => e.Categoria)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ImagenInsumo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NombreInsumo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TotalValorInsumos)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("totalValorInsumos");

            entity.HasOne(d => d.IdCompraNavigation).WithMany(p => p.DetalleCompras)
                .HasForeignKey(d => d.IdCompra)
                .HasConstraintName("FK__DetalleCo__IdCom__59063A47");

            entity.HasOne(d => d.IdInsumoNavigation).WithMany(p => p.DetalleCompras)
                .HasForeignKey(d => d.IdInsumo)
                .HasConstraintName("FK__DetalleCo__IdIns__59FA5E80");
        });

        modelBuilder.Entity<DetalleVentum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DetalleV__3214EC07E7E53F9D");

            entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.IdInsumoNavigation).WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.IdInsumo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DetalleVe__IdIns__5DCAEF64");

            entity.HasOne(d => d.IdVentaNavigation).WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.IdVenta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DetalleVe__IdVen__5CD6CB2B");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Empleado__3214EC0743C10A35");

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
                .HasConstraintName("FK__Empleado__RolId__4316F928");
        });

        modelBuilder.Entity<Insumo>(entity =>
        {
            entity.HasKey(e => e.IdInsumo).HasName("PK__Insumo__F378A2AF908311F0");

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
            entity.HasKey(e => e.IdPermiso).HasName("PK__Permisos__0D626EC880484D71");

            entity.Property(e => e.NombrePermiso).HasMaxLength(40);
        });

        modelBuilder.Entity<PermisosPorRol>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PermisosPorRol");

            entity.HasOne(d => d.Permiso).WithMany()
                .HasForeignKey(d => d.PermisoId)
                .HasConstraintName("FK__PermisosP__Permi__3E52440B");

            entity.HasOne(d => d.Rol).WithMany()
                .HasForeignKey(d => d.RolId)
                .HasConstraintName("FK__PermisosP__RolId__3D5E1FD2");
        });

        modelBuilder.Entity<Proveedor>(entity =>
        {
            entity.HasKey(e => e.IdProveedor).HasName("PK__Proveedo__E8B631AFED56D008");

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
            entity.HasKey(e => e.IdRol).HasName("PK__Roles__2A49584CBA7D9C2D");

            entity.Property(e => e.NombreRol).HasMaxLength(40);
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Service__3214EC07715549BA");

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
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuarios__5B65BF972FD562C2");

            entity.Property(e => e.ApellidoUsuario).HasMaxLength(40);
            entity.Property(e => e.Correo).HasMaxLength(50);
            entity.Property(e => e.NombreUsuario).HasMaxLength(40);
            entity.Property(e => e.Telefono).HasMaxLength(20);

            entity.HasOne(d => d.Rol).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.RolId)
                .HasConstraintName("FK__Usuarios__RolId__3B75D760");
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.IdVenta).HasName("PK__Ventas__BC1240BD506B595F");

            entity.Property(e => e.Descuento).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.EstadoVenta)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaVenta).HasColumnType("datetime");
            entity.Property(e => e.Iva).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Subtotal).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TotalVenta).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__Ventas__IdClient__4F7CD00D");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdEmpleado)
                .HasConstraintName("FK__Ventas__IdEmplea__4E88ABD4");

            entity.HasOne(d => d.IdServicioNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdServicio)
                .HasConstraintName("FK__Ventas__IdServic__4D94879B");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
