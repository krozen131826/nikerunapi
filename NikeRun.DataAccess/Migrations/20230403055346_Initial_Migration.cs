using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NikeRun.DataAccess.Migrations
{
    public partial class Initial_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Category = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageLink = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Size = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Size = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Carts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RefToken = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    JwtId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    IsRevoked = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshToken_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "ProductName" },
                values: new object[,]
                {
                    { 1, "Kids", "Nike Air Max SYSTM" },
                    { 2, "Kids", "Nike Air Zoom Pegasus 39" },
                    { 3, "Mens", "Nike Winflo 8" },
                    { 4, "Mens", "Nike ZoomX Vaporfly Next 2" },
                    { 5, "Mens", "Nike ZoomX Streakfly" },
                    { 6, "Womens", "Nike ZoomX Invincible Run Flyknit 2" },
                    { 7, "Womens", "Nike ZoomX Streakfly" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "ImageLink", "ProductId" },
                values: new object[,]
                {
                    { 1, "https://i.postimg.cc/28QHckXP/Nike-Air-Max-SYSTM-1.png", 1 },
                    { 2, "https://i.postimg.cc/qvp1WPPg/Nike-Air-Max-SYSTM-2.png", 1 },
                    { 3, "https://i.postimg.cc/Prs3QpKW/Nike-Air-Max-SYSTM-3.png", 1 },
                    { 4, "https://i.postimg.cc/3x9thLh1/Nike-Air-Max-SYSTM-4.png", 1 },
                    { 5, "https://i.postimg.cc/VsbZtB9s/Nike-Air-Max-SYSTM-5.png", 1 },
                    { 6, "https://i.postimg.cc/MGCVJRnt/Nike-Air-Zoom-Pegasus-39-1.png", 2 },
                    { 7, "https://i.postimg.cc/76S7H674/Nike-Air-Zoom-Pegasus-39-2.png", 2 },
                    { 8, "https://i.postimg.cc/2ymWVDFZ/Nike-Air-Zoom-Pegasus-39-3.png", 2 },
                    { 9, "https://i.postimg.cc/sf9SbMs9/Nike-Air-Zoom-Pegasus-39-4.png", 2 },
                    { 10, "https://i.postimg.cc/KjNMTHJs/Nike-Air-Zoom-Pegasus-39-5.png", 2 },
                    { 11, "https://i.postimg.cc/85bwHJC7/Nike-Winflo-8-1.png", 3 },
                    { 12, "https://i.postimg.cc/yxYjr1Jv/Nike-Winflo-8-2.png", 3 },
                    { 13, "https://i.postimg.cc/kG1c00K9/Nike-Winflo-8-3.png", 3 },
                    { 14, "https://i.postimg.cc/Pr7y2kdQ/Nike-Winflo-8-4.png", 3 },
                    { 15, "https://i.postimg.cc/Y2bbLWVV/Nike-Winflo-8-5.png", 3 },
                    { 16, "https://i.postimg.cc/Nf40QRDC/Nike-Zoom-X-Streakfly-1.png", 4 },
                    { 17, "https://i.postimg.cc/Kctzs6M2/Nike-Zoom-X-Streakfly-2.png", 4 },
                    { 18, "https://i.postimg.cc/TYGw8tVW/Nike-Zoom-X-Streakfly-3.png", 4 },
                    { 19, "https://i.postimg.cc/XY17C3Tw/Nike-Zoom-X-Streakfly-4.png", 4 },
                    { 20, "https://i.postimg.cc/3xxxNWb8/Nike-Zoom-X-Streakfly-5.png", 4 },
                    { 21, "https://i.postimg.cc/bJBQCKDb/zoomx-streakfly-1.png", 5 },
                    { 22, "https://i.postimg.cc/7663Nx6w/zoomx-streakfly-2.png", 5 },
                    { 23, "https://i.postimg.cc/6q4CDYnP/zoomx-streakfly-3.png", 5 },
                    { 24, "https://i.postimg.cc/Th8nGgc3/zoomx-streakfly-4.png", 5 },
                    { 25, "https://i.postimg.cc/XNrhjWgR/zoomx-streakfly-5.png", 5 },
                    { 26, "https://i.postimg.cc/YSw1LYxV/Nike-Zoom-X-Invincible-Run-Flyknit-2-1.png", 6 },
                    { 27, "https://i.postimg.cc/QxwgsRKj/Nike-Zoom-X-Invincible-Run-Flyknit-2-2.png", 6 },
                    { 28, "https://i.postimg.cc/9Q9dfJyZ/Nike-Zoom-X-Invincible-Run-Flyknit-2-3.png", 6 },
                    { 29, "https://i.postimg.cc/vTD9wzQ1/Nike-Zoom-X-Invincible-Run-Flyknit-2-4.png", 6 },
                    { 30, "https://i.postimg.cc/XJsFPh0S/Nike-Zoom-X-Invincible-Run-Flyknit-2-5.png", 6 },
                    { 31, "https://i.postimg.cc/cL6s7bFt/Nike-Zoom-X-Streakfly-1.png", 7 },
                    { 32, "https://i.postimg.cc/nh5n3GWR/Nike-Zoom-X-Streakfly-2.png", 7 },
                    { 33, "https://i.postimg.cc/d1cwYtwG/Nike-Zoom-X-Streakfly-3.png", 7 },
                    { 34, "https://i.postimg.cc/wM0pLXJk/Nike-Zoom-X-Streakfly-4.png", 7 },
                    { 35, "https://i.postimg.cc/j2sTDgW5/Nike-Zoom-X-Streakfly-5.png", 7 },
                    { 36, "https://i.postimg.cc/vB7MHFZk/Nike-Zoom-X-Streakfly-6.png", 7 }
                });

            migrationBuilder.InsertData(
                table: "ProductDetails",
                columns: new[] { "Id", "Description", "Price", "ProductId", "Size" },
                values: new object[,]
                {
                    { 1, "Cassette mixtapes. Music videos on TV. Shopping centre arcades. The '80s were fun and wild! We're celebrating that wicked cool era with the Nike Air Max SYSTM. From the big and bold Air unit to design lines (inspired by our favourite throwback Air Max shoes), it's all about bringing back what's cool to a new generation.", 3500m, 1, 8m },
                    { 2, "Cassette mixtapes. Music videos on TV. Shopping centre arcades. The '80s were fun and wild! We're celebrating that wicked cool era with the Nike Air Max SYSTM. From the big and bold Air unit to design lines (inspired by our favourite throwback Air Max shoes), it's all about bringing back what's cool to a new generation.", 3500m, 1, 9m },
                    { 3, "Cassette mixtapes. Music videos on TV. Shopping centre arcades. The '80s were fun and wild! We're celebrating that wicked cool era with the Nike Air Max SYSTM. From the big and bold Air unit to design lines (inspired by our favourite throwback Air Max shoes), it's all about bringing back what's cool to a new generation.", 3500m, 1, 10m },
                    { 4, "The Nike Air Zoom Pegasus 39 is made for runners of ALL levels—from athletics speedsters to freeze tig champs. Chase your goals with an extra bounce to your stride thanks to our innovative Zoom Air. It's also breathable up top and snug around the laces so you can feel cool, comfortable and confident with every mile", 5000m, 2, 8m },
                    { 5, "The Nike Air Zoom Pegasus 39 is made for runners of ALL levels—from athletics speedsters to freeze tig champs. Chase your goals with an extra bounce to your stride thanks to our innovative Zoom Air. It's also breathable up top and snug around the laces so you can feel cool, comfortable and confident with every mile", 5000m, 2, 9m },
                    { 6, "The Nike Air Zoom Pegasus 39 is made for runners of ALL levels—from athletics speedsters to freeze tig champs. Chase your goals with an extra bounce to your stride thanks to our innovative Zoom Air. It's also breathable up top and snug around the laces so you can feel cool, comfortable and confident with every mile", 5000m, 2, 10m }
                });

            migrationBuilder.InsertData(
                table: "ProductDetails",
                columns: new[] { "Id", "Description", "Price", "ProductId", "Size" },
                values: new object[,]
                {
                    { 7, "If running is a daily habit, you need support to match your speed. The Nike Winflo 8 brings back the cushioning you love and pairs it with details like a translucent upper and Flywire technology for a snug, stable fit for long road runs.", 8500m, 3, 8m },
                    { 8, "If running is a daily habit, you need support to match your speed. The Nike Winflo 8 brings back the cushioning you love and pairs it with details like a translucent upper and Flywire technology for a snug, stable fit for long road runs.", 8500m, 3, 9m },
                    { 9, "If running is a daily habit, you need support to match your speed. The Nike Winflo 8 brings back the cushioning you love and pairs it with details like a translucent upper and Flywire technology for a snug, stable fit for long road runs.", 8500m, 3, 10m },
                    { 10, "Continue the next evolution of speed with a racing shoe made to help you chase new goals and records. It helps improve comfort and breathability with a redesigned upper. From a 10K to a marathon, this model, like the previous version, has the responsive cushioning and secure support to push you towards your personal best.", 9000m, 4, 8m },
                    { 11, "Continue the next evolution of speed with a racing shoe made to help you chase new goals and records. It helps improve comfort and breathability with a redesigned upper. From a 10K to a marathon, this model, like the previous version, has the responsive cushioning and secure support to push you towards your personal best.", 9000m, 4, 9m },
                    { 12, "Continue the next evolution of speed with a racing shoe made to help you chase new goals and records. It helps improve comfort and breathability with a redesigned upper. From a 10K to a marathon, this model, like the previous version, has the responsive cushioning and secure support to push you towards your personal best.", 9000m, 4, 10m },
                    { 13, "Our lightest racing shoe, the Nike ZoomX Streakfly is all about the speed you need to take on the competition in a mile, 5K or 10K race. Low profile with sleek details, it feels like it disappears on your foot to help you better connect with the road on the way to your personal best. Pops of bright colour add a fun refresh, so you can turn heads at the finishing line.", 9500m, 5, 8m },
                    { 14, "Our lightest racing shoe, the Nike ZoomX Streakfly is all about the speed you need to take on the competition in a mile, 5K or 10K race. Low profile with sleek details, it feels like it disappears on your foot to help you better connect with the road on the way to your personal best. Pops of bright colour add a fun refresh, so you can turn heads at the finishing line.", 9500m, 5, 9m },
                    { 15, "Our lightest racing shoe, the Nike ZoomX Streakfly is all about the speed you need to take on the competition in a mile, 5K or 10K race. Low profile with sleek details, it feels like it disappears on your foot to help you better connect with the road on the way to your personal best. Pops of bright colour add a fun refresh, so you can turn heads at the finishing line.", 9500m, 5, 10m },
                    { 16, "Keep pushing your runs to the limit. The Nike ZoomX Invincible Run Flyknit 2 keeps you going with the same super-soft feel that lets you feel the potential when your foot hits the pavement. We created the shoe with plenty of springy responsiveness and our highest level of support to keep you feeling secure and competitive. It's one of our most tested shoes, still designed for you to stay on the road and away from the sidelines.", 7500m, 6, 8m },
                    { 17, "Keep pushing your runs to the limit. The Nike ZoomX Invincible Run Flyknit 2 keeps you going with the same super-soft feel that lets you feel the potential when your foot hits the pavement. We created the shoe with plenty of springy responsiveness and our highest level of support to keep you feeling secure and competitive. It's one of our most tested shoes, still designed for you to stay on the road and away from the sidelines.", 7500m, 6, 9m },
                    { 18, "Keep pushing your runs to the limit. The Nike ZoomX Invincible Run Flyknit 2 keeps you going with the same super-soft feel that lets you feel the potential when your foot hits the pavement. We created the shoe with plenty of springy responsiveness and our highest level of support to keep you feeling secure and competitive. It's one of our most tested shoes, still designed for you to stay on the road and away from the sidelines.", 7500m, 6, 10m },
                    { 19, "Our lightest racing shoe, the Nike ZoomX Streakfly is all about the speed you need to take on the competition in a mile, 5K or 10K race. Low profile with sleek details, it feels like it disappears on your foot to help you better connect with the road on the way to your personal best.", 7000m, 7, 8m },
                    { 20, "Our lightest racing shoe, the Nike ZoomX Streakfly is all about the speed you need to take on the competition in a mile, 5K or 10K race. Low profile with sleek details, it feels like it disappears on your foot to help you better connect with the road on the way to your personal best.", 7000m, 7, 9m },
                    { 21, "Our lightest racing shoe, the Nike ZoomX Streakfly is all about the speed you need to take on the competition in a mile, 5K or 10K race. Low profile with sleek details, it feels like it disappears on your foot to help you better connect with the road on the way to your personal best.", 7000m, 7, 10m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carts_ProductId",
                table: "Carts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ProductId",
                table: "Images",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_ProductId",
                table: "ProductDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_UserId",
                table: "RefreshToken",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "ProductDetails");

            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
