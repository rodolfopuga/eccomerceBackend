using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI_3.Migrations.AppDb
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    pro_id = table.Column<string>(nullable: false),
                    pro_nombre = table.Column<string>(nullable: true),
                    pro_descripcion = table.Column<string>(nullable: true),
                    pro_precio = table.Column<decimal>(nullable: false),
                    pro_cantidad = table.Column<string>(nullable: true),
                    pro_img = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.pro_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Producto");
        }
    }
}
