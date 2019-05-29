namespace StarFishWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AffiliateLinks", "Description_ID", "dbo.Descriptions");
            DropForeignKey("dbo.Fish", "Description_ID", "dbo.Descriptions");
            DropForeignKey("dbo.Fish", "MoreDescriptions_ID", "dbo.Descriptions");
            DropForeignKey("dbo.Fish", "PrivateNotes_ID", "dbo.Notes");
            DropForeignKey("dbo.Fish", "SubDescriptions_ID", "dbo.Descriptions");
            DropIndex("dbo.AffiliateLinks", new[] { "Description_ID" });
            DropIndex("dbo.Fish", new[] { "Description_ID" });
            DropIndex("dbo.Fish", new[] { "MoreDescriptions_ID" });
            DropIndex("dbo.Fish", new[] { "PrivateNotes_ID" });
            DropIndex("dbo.Fish", new[] { "SubDescriptions_ID" });
            AddColumn("dbo.AffiliateLinks", "Description", c => c.String());
            AddColumn("dbo.Fish", "Description", c => c.String());
            AddColumn("dbo.Fish", "SubDescriptions", c => c.String());
            AddColumn("dbo.Fish", "PrivateNotes", c => c.String());
            AddColumn("dbo.Fish", "MoreDescriptions", c => c.String());
            DropColumn("dbo.AffiliateLinks", "Description_ID");
            DropColumn("dbo.Fish", "Description_ID");
            DropColumn("dbo.Fish", "MoreDescriptions_ID");
            DropColumn("dbo.Fish", "PrivateNotes_ID");
            DropColumn("dbo.Fish", "SubDescriptions_ID");
            DropTable("dbo.Descriptions");
            DropTable("dbo.Notes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Notes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Descriptions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Fish", "SubDescriptions_ID", c => c.Int());
            AddColumn("dbo.Fish", "PrivateNotes_ID", c => c.Int());
            AddColumn("dbo.Fish", "MoreDescriptions_ID", c => c.Int());
            AddColumn("dbo.Fish", "Description_ID", c => c.Int());
            AddColumn("dbo.AffiliateLinks", "Description_ID", c => c.Int());
            DropColumn("dbo.Fish", "MoreDescriptions");
            DropColumn("dbo.Fish", "PrivateNotes");
            DropColumn("dbo.Fish", "SubDescriptions");
            DropColumn("dbo.Fish", "Description");
            DropColumn("dbo.AffiliateLinks", "Description");
            CreateIndex("dbo.Fish", "SubDescriptions_ID");
            CreateIndex("dbo.Fish", "PrivateNotes_ID");
            CreateIndex("dbo.Fish", "MoreDescriptions_ID");
            CreateIndex("dbo.Fish", "Description_ID");
            CreateIndex("dbo.AffiliateLinks", "Description_ID");
            AddForeignKey("dbo.Fish", "SubDescriptions_ID", "dbo.Descriptions", "ID");
            AddForeignKey("dbo.Fish", "PrivateNotes_ID", "dbo.Notes", "ID");
            AddForeignKey("dbo.Fish", "MoreDescriptions_ID", "dbo.Descriptions", "ID");
            AddForeignKey("dbo.Fish", "Description_ID", "dbo.Descriptions", "ID");
            AddForeignKey("dbo.AffiliateLinks", "Description_ID", "dbo.Descriptions", "ID");
        }
    }
}
