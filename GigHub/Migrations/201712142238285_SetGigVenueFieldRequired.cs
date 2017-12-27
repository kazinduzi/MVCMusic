namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetGigVenueFieldRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Gigs", "Venue", c => c.String(nullable: false, maxLength: 255, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Gigs", "Venue", c => c.String(maxLength: 255, storeType: "nvarchar"));
        }
    }
}
