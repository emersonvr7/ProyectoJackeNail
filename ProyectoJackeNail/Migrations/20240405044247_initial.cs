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
                    table.PrimaryKey("PK__Insumo__F378A2AF29A6993F", x => x.IdInsumo);
                });

            migrationBuilder.CreateTable(
                name: "Permisos",
                columns: table => new
                {
                    IdPermiso = table.Column<int>(type: "int", nullable: false),
                    NombrePermiso = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Permisos__0D626EC8307527CA", x => x.IdPermiso);
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
                    table.PrimaryKey("PK__Proveedo__E8B631AF5FBA1E98", x => x.IdProveedor);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    IdRol = table.Column<int>(type: "int", nullable: false),
                    NombreRol = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Roles__2A49584C9D0DA22D", x => x.IdRol);
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
                    table.PrimaryKey("PK__Service__3214EC070A6F65D0", x => x.Id);
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
                    table.PrimaryKey("PK__Compra__0A5CDB5CEDB8C48E", x => x.IdCompra);
                    table.ForeignKey(
                        name: "FK__Compra__IdProvee__5CD6CB2B",
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
                    table.PrimaryKey("PK__Cliente__3214EC07E941F491", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Cliente__RolId__4E88ABD4",
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
                    table.PrimaryKey("PK__Empleado__3214EC07A8A6A39A", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Empleado__RolId__4BAC3F29",
                        column: x => x.RolId,
                        principalTable: "Roles",
                        principalColumn: "IdRol");
                });

            migrationBuilder.CreateTable(
                name: "PermisosPorRol",
                columns: table => new
                {
                    RolId = table.Column<int>(type: "int", nullable: false),
                    PermisoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Permisos__D04D0E835A48D70B", x => new { x.RolId, x.PermisoId });
                    table.ForeignKey(
                        name: "FK__PermisosP__Permi__46E78A0C",
                        column: x => x.PermisoId,
                        principalTable: "Permisos",
                        principalColumn: "IdPermiso");
                    table.ForeignKey(
                        name: "FK__PermisosP__RolId__45F365D3",
                        column: x => x.RolId,
                        principalTable: "Roles",
                        principalColumn: "IdRol");
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    NombreUsuario = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    ApellidoUsuario = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    RolId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Usuarios__5B65BF97A36D1022", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK__Usuarios__RolId__4316F928",
                        column: x => x.RolId,
                        principalTable: "Roles",
                        principalColumn: "IdRol");
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
                    table.PrimaryKey("PK__Agendami__3214EC27EE3D06D8", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Agendamie__Clien__52593CB8",
                        column: x => x.ClienteID,
                        principalTable: "Cliente",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Agendamie__Emple__534D60F1",
                        column: x => x.EmpleadoID,
                        principalTable: "Empleado",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Agendamie__Servi__5165187F",
                        column: x => x.ServicioID,
                        principalTable: "Service",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    IdVenta = table.Column<int>(type: "int", nullable: false),
                    FechaVenta = table.Column<DateTime>(type: "datetime", nullable: false),
                    IdServicio = table.Column<int>(type: "int", nullable: true),
                    IdEmpleado = table.Column<int>(type: "int", nullable: true),
                    IdCliente = table.Column<int>(type: "int", nullable: true),
                    TotalVenta = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Ventas__BC1240BD25AD6065", x => x.IdVenta);
                    table.ForeignKey(
                        name: "FK__Ventas__IdClient__5812160E",
                        column: x => x.IdCliente,
                        principalTable: "Empleado",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Ventas__IdEmplea__571DF1D5",
                        column: x => x.IdEmpleado,
                        principalTable: "Cliente",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Ventas__IdServic__5629CD9C",
                        column: x => x.IdServicio,
                        principalTable: "Service",
                        principalColumn: "Id");
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
                name: "IX_Empleado_RolId",
                table: "Empleado",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_PermisosPorRol_PermisoId",
                table: "PermisosPorRol",
                column: "PermisoId");

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
                name: "Compra");

            migrationBuilder.DropTable(
                name: "Insumo");

            migrationBuilder.DropTable(
                name: "PermisosPorRol");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Ventas");

            migrationBuilder.DropTable(
                name: "Proveedor");

            migrationBuilder.DropTable(
                name: "Permisos");

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
