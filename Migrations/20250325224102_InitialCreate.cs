using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToyStore_API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_TOYS",
                columns: table => new
                {
                    Id_toy = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Name_toy = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Type_toy = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    Classification_toy = table.Column<int>(type: "NUMBER(10)", maxLength: 20, nullable: false),
                    Brand_toy = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: false),
                    Price_toy = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_TOYS", x => x.Id_toy);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_TOYS");
        }
    }
}
