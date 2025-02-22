using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AtTheSeams.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Measurements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: false),
                    A_ChestMeasurement = table.Column<int>(type: "INTEGER", nullable: true),
                    B_SeatMeasurement = table.Column<int>(type: "INTEGER", nullable: true),
                    C_WaistMeasurement = table.Column<int>(type: "INTEGER", nullable: true),
                    D_TrouserMeasurement = table.Column<int>(type: "INTEGER", nullable: true),
                    E_F_HalfBackMeasurement = table.Column<int>(type: "INTEGER", nullable: true),
                    G_H_BackNeckToWaistMeasurement = table.Column<int>(type: "INTEGER", nullable: true),
                    G_I_SyceDepthMeasurement = table.Column<int>(type: "INTEGER", nullable: true),
                    I_L_SleeveLengthOnePieceMeasurement = table.Column<int>(type: "INTEGER", nullable: true),
                    E_I_SleeveLengthTwoPieceMeasurement = table.Column<int>(type: "INTEGER", nullable: true),
                    N_InsideLegMeasurement = table.Column<int>(type: "INTEGER", nullable: true),
                    P_Q_BodyRiseMeasurement = table.Column<int>(type: "INTEGER", nullable: true),
                    R_CloseWristMeasurement = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measurements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Measurements_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Measurements_ClientId",
                table: "Measurements",
                column: "ClientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Measurements");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
