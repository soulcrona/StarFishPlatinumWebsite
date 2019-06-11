namespace StarFishWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class environment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Environments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        available = c.Boolean(nullable: false),
                        price = c.Single(nullable: false),
                        foodType_ID = c.Int(),
                        image_ID = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.FoodTypes", t => t.foodType_ID)
                .ForeignKey("dbo.Images", t => t.image_ID)
                .Index(t => t.foodType_ID)
                .Index(t => t.image_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Environments", "image_ID", "dbo.Images");
            DropForeignKey("dbo.Environments", "foodType_ID", "dbo.FoodTypes");
            DropIndex("dbo.Environments", new[] { "image_ID" });
            DropIndex("dbo.Environments", new[] { "foodType_ID" });
            DropTable("dbo.Environments");
        }
    }
}
