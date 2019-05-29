namespace StarFishWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Foods", "FishID", "dbo.Fish");
            DropIndex("dbo.Foods", new[] { "FishID" });
            DropColumn("dbo.Foods", "FishID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Foods", "FishID", c => c.Int(nullable: false));
            CreateIndex("dbo.Foods", "FishID");
            AddForeignKey("dbo.Foods", "FishID", "dbo.Fish", "ID", cascadeDelete: true);
        }
    }
}
