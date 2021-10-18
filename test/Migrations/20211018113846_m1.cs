using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopAPISourceCode.Migrations
{
    public partial class m1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategorieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategorieTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategorieMetaTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Categorie = table.Column<int>(type: "int", nullable: true),
                    CategorieImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategorieId);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_Categorie",
                        column: x => x.Categorie,
                        principalTable: "Categories",
                        principalColumn: "CategorieId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductBrand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductAnalysis = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserSSN = table.Column<double>(type: "float", nullable: false),
                    UserUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserPhone = table.Column<double>(type: "float", nullable: false),
                    UserRole = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "CategorieProduct",
                columns: table => new
                {
                    CategorieProductsProductId = table.Column<int>(type: "int", nullable: false),
                    ProductCategoriesCategorieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorieProduct", x => new { x.CategorieProductsProductId, x.ProductCategoriesCategorieId });
                    table.ForeignKey(
                        name: "FK_CategorieProduct_Categories_ProductCategoriesCategorieId",
                        column: x => x.ProductCategoriesCategorieId,
                        principalTable: "Categories",
                        principalColumn: "CategorieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategorieProduct_Products_CategorieProductsProductId",
                        column: x => x.CategorieProductsProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Meta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Context = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meta_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Options",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    Discount = table.Column<float>(type: "real", nullable: false),
                    DiscountStrt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiscountEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Options_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Spec",
                columns: table => new
                {
                    SpecId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecProductId = table.Column<int>(type: "int", nullable: false),
                    SpecKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecVlaue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spec", x => x.SpecId);
                    table.ForeignKey(
                        name: "FK_Spec_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    TagId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagProductsProductId = table.Column<int>(type: "int", nullable: true),
                    TagTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TagMetaTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TagSlug = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TagContext = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.TagId);
                    table.ForeignKey(
                        name: "FK_Tags_Products_TagProductsProductId",
                        column: x => x.TagProductsProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressState = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressCounty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressHome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressPostalCode = table.Column<double>(type: "float", nullable: false),
                    AddressUserUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_Addresses_Users_AddressUserUserId",
                        column: x => x.AddressUserUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    CartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartUserUserId = table.Column<int>(type: "int", nullable: true),
                    CartCreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CartUpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CartStatus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.CartId);
                    table.ForeignKey(
                        name: "FK_Carts_Users_CartUserUserId",
                        column: x => x.CartUserUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    LikeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LikeUserUserId = table.Column<int>(type: "int", nullable: false),
                    LikeProductProductId = table.Column<int>(type: "int", nullable: false),
                    LikeDateTimeAdded = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.LikeId);
                    table.ForeignKey(
                        name: "FK_Likes_Products_LikeProductProductId",
                        column: x => x.LikeProductProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Likes_Users_LikeUserUserId",
                        column: x => x.LikeUserUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notices",
                columns: table => new
                {
                    NoticeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoticeUserUserId = table.Column<int>(type: "int", nullable: true),
                    NoticeProductProductId = table.Column<int>(type: "int", nullable: true),
                    NoticeDateTimeAdded = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notices", x => x.NoticeId);
                    table.ForeignKey(
                        name: "FK_Notices_Products_NoticeProductProductId",
                        column: x => x.NoticeProductProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notices_Users_NoticeUserUserId",
                        column: x => x.NoticeUserUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderUserUserId = table.Column<int>(type: "int", nullable: true),
                    OrderCreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderUpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderTotal = table.Column<double>(type: "float", nullable: false),
                    OrderMoneySaved = table.Column<double>(type: "float", nullable: false),
                    OrderPayingPrice = table.Column<double>(type: "float", nullable: false),
                    OrderStatus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Users_OrderUserUserId",
                        column: x => x.OrderUserUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ReviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReviewTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReviewRating = table.Column<int>(type: "int", nullable: false),
                    ReviewStatus = table.Column<int>(type: "int", nullable: false),
                    ReviewContext = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReviewUserUserId = table.Column<int>(type: "int", nullable: true),
                    ReviewProductProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_Reviews_Products_ReviewProductProductId",
                        column: x => x.ReviewProductProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_ReviewUserUserId",
                        column: x => x.ReviewUserUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageProductProductId = table.Column<int>(type: "int", nullable: true),
                    ImageProductOptionId = table.Column<int>(type: "int", nullable: true),
                    ImagesUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.ImageId);
                    table.ForeignKey(
                        name: "FK_Images_Options_ImageProductOptionId",
                        column: x => x.ImageProductOptionId,
                        principalTable: "Options",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Images_Products_ImageProductProductId",
                        column: x => x.ImageProductProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    CartItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartItemCartCartId = table.Column<int>(type: "int", nullable: true),
                    CartItemProductProductId = table.Column<int>(type: "int", nullable: true),
                    CartItemProductOptionId = table.Column<int>(type: "int", nullable: true),
                    CartItemCreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CartItemUpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CartItemQuantity = table.Column<int>(type: "int", nullable: false),
                    CartItemStatus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.CartItemId);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartItemCartCartId",
                        column: x => x.CartItemCartCartId,
                        principalTable: "Carts",
                        principalColumn: "CartId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CartItems_Options_CartItemProductOptionId",
                        column: x => x.CartItemProductOptionId,
                        principalTable: "Options",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CartItems_Products_CartItemProductProductId",
                        column: x => x.CartItemProductProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    OrderItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderItemOrderOrderId = table.Column<int>(type: "int", nullable: true),
                    OrderItemProductProductId = table.Column<int>(type: "int", nullable: true),
                    OrderItemProductOptionId = table.Column<int>(type: "int", nullable: true),
                    OrderItemQuantity = table.Column<int>(type: "int", nullable: false),
                    OrderItemCreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderItemUpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderItemStatus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.OrderItemId);
                    table.ForeignKey(
                        name: "FK_OrderItems_Options_OrderItemProductOptionId",
                        column: x => x.OrderItemProductOptionId,
                        principalTable: "Options",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderItemOrderOrderId",
                        column: x => x.OrderItemOrderOrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_OrderItemProductProductId",
                        column: x => x.OrderItemProductProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionOrderOrderId = table.Column<int>(type: "int", nullable: true),
                    TransactionUserUserId = table.Column<int>(type: "int", nullable: true),
                    TransactionType = table.Column<int>(type: "int", nullable: false),
                    TransactionStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionCreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransactionUpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransactionContext = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionPaidPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_Transactions_Orders_TransactionOrderOrderId",
                        column: x => x.TransactionOrderOrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transactions_Users_TransactionUserUserId",
                        column: x => x.TransactionUserUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_AddressUserUserId",
                table: "Addresses",
                column: "AddressUserUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartItemCartCartId",
                table: "CartItems",
                column: "CartItemCartCartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartItemProductOptionId",
                table: "CartItems",
                column: "CartItemProductOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartItemProductProductId",
                table: "CartItems",
                column: "CartItemProductProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_CartUserUserId",
                table: "Carts",
                column: "CartUserUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CategorieProduct_ProductCategoriesCategorieId",
                table: "CategorieProduct",
                column: "ProductCategoriesCategorieId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Categorie",
                table: "Categories",
                column: "Categorie");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ImageProductOptionId",
                table: "Images",
                column: "ImageProductOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ImageProductProductId",
                table: "Images",
                column: "ImageProductProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_LikeProductProductId",
                table: "Likes",
                column: "LikeProductProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_LikeUserUserId",
                table: "Likes",
                column: "LikeUserUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Meta_ProductId",
                table: "Meta",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Notices_NoticeProductProductId",
                table: "Notices",
                column: "NoticeProductProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Notices_NoticeUserUserId",
                table: "Notices",
                column: "NoticeUserUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Options_ProductId",
                table: "Options",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderItemOrderOrderId",
                table: "OrderItems",
                column: "OrderItemOrderOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderItemProductOptionId",
                table: "OrderItems",
                column: "OrderItemProductOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderItemProductProductId",
                table: "OrderItems",
                column: "OrderItemProductProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderUserUserId",
                table: "Orders",
                column: "OrderUserUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ReviewProductProductId",
                table: "Reviews",
                column: "ReviewProductProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ReviewUserUserId",
                table: "Reviews",
                column: "ReviewUserUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Spec_ProductId",
                table: "Spec",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_TagProductsProductId",
                table: "Tags",
                column: "TagProductsProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TransactionOrderOrderId",
                table: "Transactions",
                column: "TransactionOrderOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TransactionUserUserId",
                table: "Transactions",
                column: "TransactionUserUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "CategorieProduct");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "Meta");

            migrationBuilder.DropTable(
                name: "Notices");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Spec");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Options");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
