using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SignalRApplication.Repository.Migrations
{
    public partial class InitalCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FriendShip",
                columns: table => new
                {
                    friendship_id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    personid_1 = table.Column<string>(maxLength: 20, nullable: true),
                    personid_2 = table.Column<string>(maxLength: 20, nullable: true),
                    established_date = table.Column<DateTime>(nullable: false),
                    create_at = table.Column<DateTime>(nullable: false),
                    delete_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendShip", x => x.friendship_id);
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    idmessage = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    iduser_send = table.Column<string>(maxLength: 20, nullable: true),
                    iduser_receive = table.Column<string>(maxLength: 20, nullable: true),
                    message = table.Column<string>(nullable: true),
                    create_at = table.Column<DateTime>(nullable: true),
                    delete_at = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.idmessage);
                });

            migrationBuilder.CreateTable(
                name: "MessageRoom",
                columns: table => new
                {
                    idmessage = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    idroom = table.Column<string>(maxLength: 32, nullable: true),
                    iduser_send = table.Column<string>(maxLength: 20, nullable: true),
                    message = table.Column<string>(nullable: true),
                    create_at = table.Column<DateTime>(nullable: true),
                    delete_at = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageRoom", x => x.idmessage);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    idroom = table.Column<string>(maxLength: 32, nullable: false),
                    iduser = table.Column<string>(maxLength: 20, nullable: false),
                    series = table.Column<int>(nullable: false),
                    display_name = table.Column<string>(nullable: false),
                    create_at = table.Column<DateTime>(nullable: true),
                    update_at = table.Column<DateTime>(nullable: true),
                    delete_at = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => new { x.idroom, x.iduser });
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    iduser = table.Column<string>(maxLength: 20, nullable: false),
                    username = table.Column<string>(maxLength: 100, nullable: false),
                    password = table.Column<string>(maxLength: 255, nullable: false),
                    active = table.Column<string>(nullable: true),
                    create_at = table.Column<DateTime>(nullable: true),
                    update_at = table.Column<DateTime>(nullable: true),
                    delete_at = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.iduser);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_username",
                table: "User",
                column: "username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FriendShip");

            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "MessageRoom");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
