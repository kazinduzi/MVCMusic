namespace MVCMusic.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddOneToMany_Customer_Reviewed : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerModel",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CustomerId = c.String(nullable: false, unicode: false),
                        Name = c.String(nullable: false, unicode: false),
                        Country = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MovieModel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, unicode: false),
                        Duration = c.Int(nullable: false),
                        ReleasedDate = c.DateTime(nullable: false, precision: 0),
                        Genre = c.String(nullable: false, unicode: false),
                        Created = c.DateTime(nullable: false, precision: 0),
                        MovieCustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CustomerModel", t => t.MovieCustomerId, cascadeDelete: true)
                .Index(t => t.MovieCustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovieModel", "MovieCustomerId", "dbo.CustomerModel");
            DropIndex("dbo.MovieModel", new[] { "MovieCustomerId" });
            DropTable("dbo.MovieModel");
            DropTable("dbo.CustomerModel");
        }
    }
}
