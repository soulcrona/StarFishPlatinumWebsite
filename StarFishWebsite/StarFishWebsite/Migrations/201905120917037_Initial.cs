namespace StarFishWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AffiliateLinks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        SiteName = c.String(),
                        Description_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Descriptions", t => t.Description_ID)
                .Index(t => t.Description_ID);
            
            CreateTable(
                "dbo.Descriptions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Fish",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        InGame = c.Boolean(nullable: false),
                        AffiliateLink_ID = c.Int(),
                        Description_ID = c.Int(),
                        FishType_ID = c.Int(),
                        FoodPreferences_ID = c.Int(),
                        ImageCall_ID = c.Int(),
                        MoreDescriptions_ID = c.Int(),
                        PrivateNotes_ID = c.Int(),
                        SubDescriptions_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AffiliateLinks", t => t.AffiliateLink_ID)
                .ForeignKey("dbo.Descriptions", t => t.Description_ID)
                .ForeignKey("dbo.FishTypes", t => t.FishType_ID)
                .ForeignKey("dbo.FoodPreferences", t => t.FoodPreferences_ID)
                .ForeignKey("dbo.Images", t => t.ImageCall_ID)
                .ForeignKey("dbo.Descriptions", t => t.MoreDescriptions_ID)
                .ForeignKey("dbo.Notes", t => t.PrivateNotes_ID)
                .ForeignKey("dbo.Descriptions", t => t.SubDescriptions_ID)
                .Index(t => t.AffiliateLink_ID)
                .Index(t => t.Description_ID)
                .Index(t => t.FishType_ID)
                .Index(t => t.FoodPreferences_ID)
                .Index(t => t.ImageCall_ID)
                .Index(t => t.MoreDescriptions_ID)
                .Index(t => t.PrivateNotes_ID)
                .Index(t => t.SubDescriptions_ID);
            
            CreateTable(
                "dbo.FishTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.FoodPreferences",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Foods",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        InGame = c.Boolean(nullable: false),
                        FishID = c.Int(nullable: false),
                        TypeofFood_ID = c.Int(),
                        FoodPreferences_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Fish", t => t.FishID, cascadeDelete: true)
                .ForeignKey("dbo.FoodTypes", t => t.TypeofFood_ID)
                .ForeignKey("dbo.FoodPreferences", t => t.FoodPreferences_ID)
                .Index(t => t.FishID)
                .Index(t => t.TypeofFood_ID)
                .Index(t => t.FoodPreferences_ID);
            
            CreateTable(
                "dbo.FoodTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ImageFile = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Notes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Fish", "SubDescriptions_ID", "dbo.Descriptions");
            DropForeignKey("dbo.Fish", "PrivateNotes_ID", "dbo.Notes");
            DropForeignKey("dbo.Fish", "MoreDescriptions_ID", "dbo.Descriptions");
            DropForeignKey("dbo.Fish", "ImageCall_ID", "dbo.Images");
            DropForeignKey("dbo.Fish", "FoodPreferences_ID", "dbo.FoodPreferences");
            DropForeignKey("dbo.Foods", "FoodPreferences_ID", "dbo.FoodPreferences");
            DropForeignKey("dbo.Foods", "TypeofFood_ID", "dbo.FoodTypes");
            DropForeignKey("dbo.Foods", "FishID", "dbo.Fish");
            DropForeignKey("dbo.Fish", "FishType_ID", "dbo.FishTypes");
            DropForeignKey("dbo.Fish", "Description_ID", "dbo.Descriptions");
            DropForeignKey("dbo.Fish", "AffiliateLink_ID", "dbo.AffiliateLinks");
            DropForeignKey("dbo.AffiliateLinks", "Description_ID", "dbo.Descriptions");
            DropIndex("dbo.Foods", new[] { "FoodPreferences_ID" });
            DropIndex("dbo.Foods", new[] { "TypeofFood_ID" });
            DropIndex("dbo.Foods", new[] { "FishID" });
            DropIndex("dbo.Fish", new[] { "SubDescriptions_ID" });
            DropIndex("dbo.Fish", new[] { "PrivateNotes_ID" });
            DropIndex("dbo.Fish", new[] { "MoreDescriptions_ID" });
            DropIndex("dbo.Fish", new[] { "ImageCall_ID" });
            DropIndex("dbo.Fish", new[] { "FoodPreferences_ID" });
            DropIndex("dbo.Fish", new[] { "FishType_ID" });
            DropIndex("dbo.Fish", new[] { "Description_ID" });
            DropIndex("dbo.Fish", new[] { "AffiliateLink_ID" });
            DropIndex("dbo.AffiliateLinks", new[] { "Description_ID" });
            DropTable("dbo.Notes");
            DropTable("dbo.Images");
            DropTable("dbo.FoodTypes");
            DropTable("dbo.Foods");
            DropTable("dbo.FoodPreferences");
            DropTable("dbo.FishTypes");
            DropTable("dbo.Fish");
            DropTable("dbo.Descriptions");
            DropTable("dbo.AffiliateLinks");
        }
    }
}
