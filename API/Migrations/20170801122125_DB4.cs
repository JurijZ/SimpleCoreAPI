using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class DB4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Populate Products table with some records
            migrationBuilder.Sql("INSERT INTO Products(Name, OriginPostCode, Rating) VALUES('bus', '3333', 4)");
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Products WHERE Name = 'bus'");
        }
    }
}
