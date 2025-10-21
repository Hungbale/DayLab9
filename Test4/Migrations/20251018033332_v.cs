using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test4.Migrations
{
    /// <inheritdoc />
    public partial class v : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoaiSanPham",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaLoai = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TenLoai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiSanPham", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SanPham",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSanPham = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TenSanPham = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    DonGia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LoaiSanPhamId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPham", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SanPham_LoaiSanPham_LoaiSanPhamId",
                        column: x => x.LoaiSanPhamId,
                        principalTable: "LoaiSanPham",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoaiSanPham_MaLoai",
                table: "LoaiSanPham",
                column: "MaLoai",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_LoaiSanPhamId",
                table: "SanPham",
                column: "LoaiSanPhamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SanPham");

            migrationBuilder.DropTable(
                name: "LoaiSanPham");
        }
    }
}
