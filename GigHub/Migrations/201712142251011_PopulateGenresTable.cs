namespace GigHub.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateGenresTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO genres (ID, NAME) VALUES (1, 'Jazz'), (2, 'Blues'), (3, 'Pop'), (4, 'Rock')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM genres WHERE ID IN (1,2,3,4)");
        }
    }
}
