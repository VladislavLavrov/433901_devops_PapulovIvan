using _14_Calculator.Data;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _14_Calculator.Migrations;

[DbContext(typeof(CalculatorDbContext))]
[Migration("20261020110000_m_init")]
public partial class m_init : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "DataInputVariants",
            columns: table => new
            {
                ID_DataInputVariant = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", Pomelo.EntityFrameworkCore.MySql.Metadata.MySqlValueGenerationStrategy.IdentityColumn),
                Operand_1 = table.Column<double>(type: "double", nullable: false),
                Operand_2 = table.Column<double>(type: "double", nullable: false),
                Type_operation = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Result = table.Column<double>(type: "double", nullable: false),
                CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
            },
            constraints: table => table.PrimaryKey("PK_DataInputVariants", x => x.ID_DataInputVariant))
            .Annotation("MySql:CharSet", "utf8mb4")
            .Annotation("MySql:Collation", "utf8mb4_general_ci");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(name: "DataInputVariants");
    }
}
