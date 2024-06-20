using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using static MyWebAPI8.Helper.Enum;

#nullable disable

namespace MyBlogAPI8.Migrations
{
    /// <inheritdoc />
    public partial class InitialSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    password = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("users_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "posts",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    category = table.Column<int>(type: "integer", nullable: false),
                    created_by = table.Column<int>(type: "integer", nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    is_published = table.Column<bool>(type: "boolean", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("posts_pkey", x => x.id);
                    table.ForeignKey(
                        name: "created_by",
                        column: x => x.created_by,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "name", "password", "is_active" },
                values: new object[] { 1, "John Wick", "test@123", true });
            
            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "name", "password", "is_active" },
                values: new object[] { 2, "Bruce Lee", "test@123", true });
            
            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "name", "password", "is_active" },
                values: new object[] { 3, "James Bond", "test@123", true });

            migrationBuilder.InsertData(
                table: "posts",
                columns: new[] { "id", "title", "description", "category", "created_by", "is_published" },
                values: new object[] { 1, "First Post", "Health Post", 1, 1, true });

            migrationBuilder.InsertData(
                table: "posts",
                columns: new[] { "id", "title", "description", "category", "created_by", "is_published" },
                values: new object[] { 2, "Second Post", "Technology Post", 2, 1, true });
            
            migrationBuilder.InsertData(
                table: "posts",
                columns: new[] { "id", "title", "description", "category", "created_by", "is_published" },
                values: new object[] { 3, "Third Post", "Travel Post", 3, 2, true });

            migrationBuilder.CreateIndex(
                name: "IX_posts_created_by",
                table: "posts",
                column: "created_by");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "posts");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
