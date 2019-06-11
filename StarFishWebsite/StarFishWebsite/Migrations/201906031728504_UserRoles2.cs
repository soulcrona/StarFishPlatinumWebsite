namespace StarFishWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserRoles2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AffiliateLinks", "AccessLevel", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AffiliateLinks", "AccessLevel");
        }
    }
}
