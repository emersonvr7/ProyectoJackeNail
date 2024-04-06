using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoJackeNail.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Insumo",
                columns: table => new
                {
                    IdInsumo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImagenInsumo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    NombreInsumo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CantidadInsumo = table.Column<int>(type: "int", nullable: true),
                    UsosDisponibles = table.Column<int>(type: "int", nullable: true),
                    EstadoInsumo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Insumo__F378A2AF908311F0", x => x.IdInsumo);
                });

            migrationBuilder.CreateTable(
                name: "Permisos",
                columns: table => new
                {
                    IdPermiso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombrePermiso = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Permisos__0D626EC880484D71", x => x.IdPermiso);
                });

            migrationBuilder.CreateTable(
                name: "Proveedor",
                columns: table => new
                {
                    IdProveedor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreProveedor = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CorreoProveedor = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    TelefonoProveedor = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    DireccionProveedor = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true),
                    EmpresaProveedor = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    EstadoProveedor = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Proveedo__E8B631AFED56D008", x => x.IdProveedor);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    IdRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreRol = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Roles__2A49584CBA7D9C2D", x => x.IdRol);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Servicio = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Precio = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Tiempo = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    ImgServicio = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: true),
                    NivelUña = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    EstadoServicio = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Service__3214EC07715549BA", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Compra",
                columns: table => new
                {
                    IdCompra = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProveedor = table.Column<int>(type: "int", nullable: true),
                    FechaCompra = table.Column<DateTime>(type: "datetime", nullable: true),
                    DescuentoCompra = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    SubtotalCompra = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    IvaCompra = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    EstadoCompra = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Compra__0A5CDB5C6E63C7ED", x => x.IdCompra);
                    table.ForeignKey(
                        name: "FK__Compra__IdProvee__5441852A",
                        column: x => x.IdProveedor,
                        principalTable: "Proveedor",
                        principalColumn: "IdProveedor");
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Correo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Telefono = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    RolId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Cliente__3214EC0742EED453", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Cliente__RolId__45F365D3",
                        column: x => x.RolId,
                        principalTable: "Roles",
                        principalColumn: "IdRol");
                });

            migrationBuilder.CreateTable(
                name: "Empleado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Correo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Telefono = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Documento = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    RolId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Empleado__3214EC0743C10A35", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Empleado__RolId__4316F928",
                        column: x => x.RolId,
                        principalTable: "Roles",
                        principalColumn: "IdRol");
                });

            migrationBuilder.CreateTable(
                name: "PermisosPorRol",
                columns: table => new
                {
                    RolId = table.Column<int>(type: "int", nullable: true),
                    PermisoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK__PermisosP__Permi__3E52440B",
                        column: x => x.PermisoId,
                        principalTable: "Permisos",
                        principalColumn: "IdPermiso");
                    table.ForeignKey(
                        name: "FK__PermisosP__RolId__3D5E1FD2",
                        column: x => x.RolId,
                        principalTable: "Roles",
                        principalColumn: "IdRol");
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreUsuario = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    ApellidoUsuario = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    RolId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Usuarios__5B65BF972FD562C2", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK__Usuarios__RolId__3B75D760",
                        column: x => x.RolId,
                        principalTable: "Roles",
                        principalColumn: "IdRol");
                });

            migrationBuilder.CreateTable(
                name: "DetalleCompra",
                columns: table => new
                {
                    IdDetalle = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCompra = table.Column<int>(type: "int", nullable: true),
                    IdInsumo = table.Column<int>(type: "int", nullable: true),
                    ImagenInsumo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    NombreInsumo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CantidadInsumo = table.Column<int>(type: "int", nullable: true),
                    UsosDisponibles = table.Column<int>(type: "int", nullable: true),
                    Categoria = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    totalValorInsumos = table.Column<decimal>(type: "decimal(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DetalleC__E43646A53AC81008", x => x.IdDetalle);
                    table.ForeignKey(
                        name: "FK__DetalleCo__IdCom__59063A47",
                        column: x => x.IdCompra,
                        principalTable: "Compra",
                        principalColumn: "IdCompra");
                    table.ForeignKey(
                        name: "FK__DetalleCo__IdIns__59FA5E80",
                        column: x => x.IdInsumo,
                        principalTable: "Insumo",
                        principalColumn: "IdInsumo");
                });

            migrationBuilder.CreateTable(
                name: "Agendamiento",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteID = table.Column<int>(type: "int", nullable: true),
                    ServicioID = table.Column<int>(type: "int", nullable: true),
                    EmpleadoID = table.Column<int>(type: "int", nullable: true),
                    FechaAgenda = table.Column<DateOnly>(type: "date", nullable: true),
                    EstadoAgenda = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Agendami__3214EC27C827C081", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Agendamie__Clien__49C3F6B7",
                        column: x => x.ClienteID,
                        principalTable: "Cliente",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Agendamie__Emple__4AB81AF0",
                        column: x => x.EmpleadoID,
                        principalTable: "Empleado",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Agendamie__Servi__48CFD27E",
                        column: x => x.ServicioID,
                        principalTable: "Service",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    IdVenta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaVenta = table.Column<DateTime>(type: "datetime", nullable: false),
                    IdServicio = table.Column<int>(type: "int", nullable: true),
                    IdEmpleado = table.Column<int>(type: "int", nullable: true),
                    IdCliente = table.Column<int>(type: "int", nullable: true),
                    TotalVenta = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Iva = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Subtotal = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Descuento = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    EstadoVenta = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Ventas__BC1240BD506B595F", x => x.IdVenta);
                    table.ForeignKey(
                        name: "FK__Ventas__IdClient__4F7CD00D",
                        column: x => x.IdCliente,
                        principalTable: "Empleado",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Ventas__IdEmplea__4E88ABD4",
                        column: x => x.IdEmpleado,
                        principalTable: "Cliente",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Ventas__IdServic__4D94879B",
                        column: x => x.IdServicio,
                        principalTable: "Service",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DetalleVenta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdVenta = table.Column<int>(type: "int", nullable: false),
                    IdInsumo = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DetalleV__3214EC07E7E53F9D", x => x.Id);
                    table.ForeignKey(
                        name: "FK__DetalleVe__IdIns__5DCAEF64",
                        column: x => x.IdInsumo,
                        principalTable: "Insumo",
                        principalColumn: "IdInsumo");
                    table.ForeignKey(
                        name: "FK__DetalleVe__IdVen__5CD6CB2B",
                        column: x => x.IdVenta,
                        principalTable: "Ventas",
                        principalColumn: "IdVenta");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agendamiento_ClienteID",
                table: "Agendamiento",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamiento_EmpleadoID",
                table: "Agendamiento",
                column: "EmpleadoID");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamiento_ServicioID",
                table: "Agendamiento",
                column: "ServicioID");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_RolId",
                table: "Cliente",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_Compra_IdProveedor",
                table: "Compra",
                column: "IdProveedor");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleCompra_IdCompra",
                table: "DetalleCompra",
                column: "IdCompra");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleCompra_IdInsumo",
                table: "DetalleCompra",
                column: "IdInsumo");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleVenta_IdInsumo",
                table: "DetalleVenta",
                column: "IdInsumo");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleVenta_IdVenta",
                table: "DetalleVenta",
                column: "IdVenta");

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_RolId",
                table: "Empleado",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_PermisosPorRol_PermisoId",
                table: "PermisosPorRol",
                column: "PermisoId");

            migrationBuilder.CreateIndex(
                name: "IX_PermisosPorRol_RolId",
                table: "PermisosPorRol",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_RolId",
                table: "Usuarios",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_IdCliente",
                table: "Ventas",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_IdEmpleado",
                table: "Ventas",
                column: "IdEmpleado");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_IdServicio",
                table: "Ventas",
                column: "IdServicio");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agendamiento");

            migrationBuilder.DropTable(
                name: "DetalleCompra");

            migrationBuilder.DropTable(
                name: "DetalleVenta");

            migrationBuilder.DropTable(
                name: "PermisosPorRol");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Compra");

            migrationBuilder.DropTable(
                name: "Insumo");

            migrationBuilder.DropTable(
                name: "Ventas");

            migrationBuilder.DropTable(
                name: "Permisos");

            migrationBuilder.DropTable(
                name: "Proveedor");

            migrationBuilder.DropTable(
                name: "Empleado");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
