using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Proyecto_Entity_F.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[,]
                {
                    { new Guid("df4de29b-8dc1-48bc-93bb-36aabebc8702"), null, "Actividades Realizadas", 29 },
                    { new Guid("df4de29b-8dc1-48bc-93bb-36aabebc879d"), null, "Actividades pendientes", 20 }
                });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaID", "CategoriaId", "Descripcion", "FechaCreacion", "PrioridadTarea", "Titulo" },
                values: new object[,]
                {
                    { new Guid("df4de29b-8dc1-48bc-93bb-36aabebc8710"), new Guid("df4de29b-8dc1-48bc-93bb-36aabebc879d"), null, new DateTime(2024, 8, 21, 16, 32, 52, 661, DateTimeKind.Local).AddTicks(4750), 1, "Pago de servicio publicos" },
                    { new Guid("df4de29b-8dc1-48bc-93bb-36aabebc8711"), new Guid("df4de29b-8dc1-48bc-93bb-36aabebc8702"), null, new DateTime(2024, 8, 21, 16, 32, 52, 661, DateTimeKind.Local).AddTicks(4766), 2, "Compra del Mercado" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaID",
                keyValue: new Guid("df4de29b-8dc1-48bc-93bb-36aabebc8710"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaID",
                keyValue: new Guid("df4de29b-8dc1-48bc-93bb-36aabebc8711"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("df4de29b-8dc1-48bc-93bb-36aabebc8702"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("df4de29b-8dc1-48bc-93bb-36aabebc879d"));

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
