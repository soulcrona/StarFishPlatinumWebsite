namespace StarFishWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AvailabilityAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AffiliateLinks", "Available", c => c.Boolean(nullable: false));
            AddColumn("dbo.FishTypes", "Available", c => c.Boolean(nullable: false));
            AddColumn("dbo.Foods", "Available", c => c.Boolean(nullable: false));
            AddColumn("dbo.FoodTypes", "Available", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FoodTypes", "Available");
            DropColumn("dbo.Foods", "Available");
            DropColumn("dbo.FishTypes", "Available");
            DropColumn("dbo.AffiliateLinks", "Available");
        }
    }
}
