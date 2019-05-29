namespace StarFishWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration7 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Foods", "Fish_ID", "dbo.Fish");
            DropIndex("dbo.Foods", new[] { "Fish_ID" });
            CreateTable(
                "dbo.FoodFish",
                c => new
                    {
                        Food_ID = c.Int(nullable: false),
                        Fish_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Food_ID, t.Fish_ID })
                .ForeignKey("dbo.Foods", t => t.Food_ID, cascadeDelete: true)
                .ForeignKey("dbo.Fish", t => t.Fish_ID, cascadeDelete: true)
                .Index(t => t.Food_ID)
                .Index(t => t.Fish_ID);
            
            DropColumn("dbo.Foods", "Fish_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Foods", "Fish_ID", c => c.Int());
            DropForeignKey("dbo.FoodFish", "Fish_ID", "dbo.Fish");
            DropForeignKey("dbo.FoodFish", "Food_ID", "dbo.Foods");
            DropIndex("dbo.FoodFish", new[] { "Fish_ID" });
            DropIndex("dbo.FoodFish", new[] { "Food_ID" });
            DropTable("dbo.FoodFish");
            CreateIndex("dbo.Foods", "Fish_ID");
            AddForeignKey("dbo.Foods", "Fish_ID", "dbo.Fish", "ID");
        }
    }
}
