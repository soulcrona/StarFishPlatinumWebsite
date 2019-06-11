namespace StarFishWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Fish", "Price", c => c.Single(nullable: false));
            AddColumn("dbo.Foods", "price", c => c.Single(nullable: false));
            AddColumn("dbo.Foods", "icon_ID", c => c.Int());
            CreateIndex("dbo.Foods", "icon_ID");
            AddForeignKey("dbo.Foods", "icon_ID", "dbo.Images", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Foods", "icon_ID", "dbo.Images");
            DropIndex("dbo.Foods", new[] { "icon_ID" });
            DropColumn("dbo.Foods", "icon_ID");
            DropColumn("dbo.Foods", "price");
            DropColumn("dbo.Fish", "Price");
        }
    }
}
