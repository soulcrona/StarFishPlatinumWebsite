namespace StarFishWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Foods", "FoodPreferences_ID", "dbo.FoodPreferences");
            DropForeignKey("dbo.Fish", "FoodPreferences_ID", "dbo.FoodPreferences");
            DropIndex("dbo.Fish", new[] { "FoodPreferences_ID" });
            DropIndex("dbo.Foods", new[] { "FoodPreferences_ID" });
            AddColumn("dbo.Foods", "Fish_ID", c => c.Int());
            CreateIndex("dbo.Foods", "Fish_ID");
            AddForeignKey("dbo.Foods", "Fish_ID", "dbo.Fish", "ID");
            DropColumn("dbo.Fish", "FoodPreferences_ID");
            DropColumn("dbo.Foods", "FoodPreferences_ID");
            DropTable("dbo.FoodPreferences");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.FoodPreferences",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Foods", "FoodPreferences_ID", c => c.Int());
            AddColumn("dbo.Fish", "FoodPreferences_ID", c => c.Int());
            DropForeignKey("dbo.Foods", "Fish_ID", "dbo.Fish");
            DropIndex("dbo.Foods", new[] { "Fish_ID" });
            DropColumn("dbo.Foods", "Fish_ID");
            CreateIndex("dbo.Foods", "FoodPreferences_ID");
            CreateIndex("dbo.Fish", "FoodPreferences_ID");
            AddForeignKey("dbo.Fish", "FoodPreferences_ID", "dbo.FoodPreferences", "ID");
            AddForeignKey("dbo.Foods", "FoodPreferences_ID", "dbo.FoodPreferences", "ID");
        }
    }
}
