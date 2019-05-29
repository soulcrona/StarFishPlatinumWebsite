namespace StarFishWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FishAvailabilityAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Fish", "Available", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Fish", "Available");
        }
    }
}
