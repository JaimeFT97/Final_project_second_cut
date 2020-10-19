using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace FinalProjectSecondCut.Migrations
{
    public partial class BDInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Country_name = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Gender_name = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Language_name = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Age = table.Column<int>(maxLength: 30, nullable: false),
                    Gender = table.Column<string>(maxLength: 30, nullable: false),
                    Role = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Artist",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Artistic_name = table.Column<string>(maxLength: 30, nullable: false),
                    Real_name = table.Column<string>(maxLength: 30, nullable: false),
                    Country_id = table.Column<int>(nullable: false),
                    Average_salary = table.Column<float>(nullable: false),
                    Occupation = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Artist_Country_Country_id",
                        column: x => x.Country_id,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Album",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Album_name = table.Column<string>(maxLength: 30, nullable: false),
                    Album_cover = table.Column<string>(maxLength: 150, nullable: false),
                    Song_quantity = table.Column<int>(nullable: false),
                    Duration = table.Column<string>(maxLength: 30, nullable: false),
                    Link_album = table.Column<string>(maxLength: 150, nullable: false),
                    Artist_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Album", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Album_Artist_Artist_id",
                        column: x => x.Artist_id,
                        principalTable: "Artist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Song",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Song_name = table.Column<string>(maxLength: 30, nullable: false),
                    Duration = table.Column<string>(maxLength: 30, nullable: false),
                    Gender_id = table.Column<int>(nullable: false),
                    Language_id = table.Column<int>(nullable: false),
                    Country_id = table.Column<int>(nullable: false),
                    Link_song = table.Column<string>(maxLength: 150, nullable: false),
                    Album_id = table.Column<int>(nullable: false),
                    Artist_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Song", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Song_Album_Album_id",
                        column: x => x.Album_id,
                        principalTable: "Album",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Song_Artist_Artist_id",
                        column: x => x.Artist_id,
                        principalTable: "Artist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Song_Country_Country_id",
                        column: x => x.Country_id,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Song_Gender_Gender_id",
                        column: x => x.Gender_id,
                        principalTable: "Gender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Song_Language_Language_id",
                        column: x => x.Language_id,
                        principalTable: "Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Album_Artist_id",
                table: "Album",
                column: "Artist_id");

            migrationBuilder.CreateIndex(
                name: "IX_Artist_Country_id",
                table: "Artist",
                column: "Country_id");

            migrationBuilder.CreateIndex(
                name: "IX_Song_Album_id",
                table: "Song",
                column: "Album_id");

            migrationBuilder.CreateIndex(
                name: "IX_Song_Artist_id",
                table: "Song",
                column: "Artist_id");

            migrationBuilder.CreateIndex(
                name: "IX_Song_Country_id",
                table: "Song",
                column: "Country_id");

            migrationBuilder.CreateIndex(
                name: "IX_Song_Gender_id",
                table: "Song",
                column: "Gender_id");

            migrationBuilder.CreateIndex(
                name: "IX_Song_Language_id",
                table: "Song",
                column: "Language_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Song");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "Album");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropTable(
                name: "Artist");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
