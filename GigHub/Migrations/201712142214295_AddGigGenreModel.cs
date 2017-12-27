namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGigGenreModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Gigs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false, precision: 0),
                        Venue = c.String(maxLength: 255, storeType: "nvarchar"),
                        Artist_Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Genre_Id = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Artist_Id, cascadeDelete: true)
                .ForeignKey("dbo.Genres", t => t.Genre_Id, cascadeDelete: true)
                .Index(t => t.Artist_Id)
                .Index(t => t.Genre_Id);
            
            AlterColumn("dbo.AspNetUsers", "PasswordHash", c => c.String(unicode: false));
            AlterColumn("dbo.AspNetUsers", "SecurityStamp", c => c.String(unicode: false));
            AlterColumn("dbo.AspNetUsers", "PhoneNumber", c => c.String(unicode: false));
            AlterColumn("dbo.AspNetUsers", "LockoutEndDateUtc", c => c.DateTime(precision: 0));
            AlterColumn("dbo.AspNetUserClaims", "ClaimType", c => c.String(unicode: false));
            AlterColumn("dbo.AspNetUserClaims", "ClaimValue", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Gigs", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.Gigs", "Artist_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Gigs", new[] { "Genre_Id" });
            DropIndex("dbo.Gigs", new[] { "Artist_Id" });
            AlterColumn("dbo.AspNetUserClaims", "ClaimValue", c => c.String());
            AlterColumn("dbo.AspNetUserClaims", "ClaimType", c => c.String());
            AlterColumn("dbo.AspNetUsers", "LockoutEndDateUtc", c => c.DateTime());
            AlterColumn("dbo.AspNetUsers", "PhoneNumber", c => c.String());
            AlterColumn("dbo.AspNetUsers", "SecurityStamp", c => c.String());
            AlterColumn("dbo.AspNetUsers", "PasswordHash", c => c.String());
            DropTable("dbo.Gigs");
            DropTable("dbo.Genres");
        }
    }
}
