﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSyste_.Data.Migrations
{
    public partial class AddCreatedOnColumnToHouses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("7d89d368-35e1-4397-b72b-eff826ce8e01"));

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("b5815663-bf99-485e-9a74-1584bed60877"));

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("f9355d50-37bf-4424-82af-5ea518fe54e2"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Houses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 27, 8, 50, 22, 175, DateTimeKind.Utc).AddTicks(9274));

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "Description", "ImageUrl", "PricePerMonth", "RenterId", "Title" },
                values: new object[] { new Guid("3859f5da-3c47-4581-ba49-52e67da26042"), "Near the Sea Garden in Burgas, Bulgaria", new Guid("3ada170c-705d-427d-845a-a3f5e0698431"), 2, "It has the best comfort you will ever ask for. With two bedrooms, it is great for your family.", "https://cf.bstatic.com/xdata/images/hotel/max1024x768/179489660.jpg?k=2029f6d9589b49c95dcc9503a265e292c2cdfcb5277487a0050397c3f8dd545a&o=&hp=1", 1200.00m, null, "Family House Comfort" });

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "Description", "ImageUrl", "PricePerMonth", "RenterId", "Title" },
                values: new object[] { new Guid("47b6b3a8-1c74-4b3b-95eb-c3792b5345de"), "Boyana Neighbourhood, Sofia, Bulgaria", new Guid("3ada170c-705d-427d-845a-a3f5e0698431"), 2, "This luxurious house is everything you will need. It is just excellent.", "https://i.pinimg.com/originals/a6/f5/85/a6f5850a77633c56e4e4ac4f867e3c00.jpg", 2000.00m, null, "Grand House" });

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "Description", "ImageUrl", "PricePerMonth", "RenterId", "Title" },
                values: new object[] { new Guid("b0346573-23a2-46e0-9f53-19ea9a8c8517"), "North London, UK (near the border)", new Guid("3ada170c-705d-427d-845a-a3f5e0698431"), 3, "A big house for your whole family. Don't miss to buy a house with three bedrooms.", "https://www.luxury-architecture.net/wpcontent/uploads/2017/12/1513217889-7597-FAIRWAYS-010.jpg", 2100.00m, new Guid("83f3ca42-8a1a-418b-8f26-08db76e0ad82"), "Big House Marina" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("3859f5da-3c47-4581-ba49-52e67da26042"));

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("47b6b3a8-1c74-4b3b-95eb-c3792b5345de"));

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("b0346573-23a2-46e0-9f53-19ea9a8c8517"));

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Houses");

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "Description", "ImageUrl", "PricePerMonth", "RenterId", "Title" },
                values: new object[] { new Guid("7d89d368-35e1-4397-b72b-eff826ce8e01"), "North London, UK (near the border)", new Guid("3ada170c-705d-427d-845a-a3f5e0698431"), 3, "A big house for your whole family. Don't miss to buy a house with three bedrooms.", "https://www.luxury-architecture.net/wpcontent/uploads/2017/12/1513217889-7597-FAIRWAYS-010.jpg", 2100.00m, new Guid("83f3ca42-8a1a-418b-8f26-08db76e0ad82"), "Big House Marina" });

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "Description", "ImageUrl", "PricePerMonth", "RenterId", "Title" },
                values: new object[] { new Guid("b5815663-bf99-485e-9a74-1584bed60877"), "Near the Sea Garden in Burgas, Bulgaria", new Guid("3ada170c-705d-427d-845a-a3f5e0698431"), 2, "It has the best comfort you will ever ask for. With two bedrooms, it is great for your family.", "https://cf.bstatic.com/xdata/images/hotel/max1024x768/179489660.jpg?k=2029f6d9589b49c95dcc9503a265e292c2cdfcb5277487a0050397c3f8dd545a&o=&hp=1", 1200.00m, null, "Family House Comfort" });

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "Description", "ImageUrl", "PricePerMonth", "RenterId", "Title" },
                values: new object[] { new Guid("f9355d50-37bf-4424-82af-5ea518fe54e2"), "Boyana Neighbourhood, Sofia, Bulgaria", new Guid("3ada170c-705d-427d-845a-a3f5e0698431"), 2, "This luxurious house is everything you will need. It is just excellent.", "https://i.pinimg.com/originals/a6/f5/85/a6f5850a77633c56e4e4ac4f867e3c00.jpg", 2000.00m, null, "Grand House" });
        }
    }
}
