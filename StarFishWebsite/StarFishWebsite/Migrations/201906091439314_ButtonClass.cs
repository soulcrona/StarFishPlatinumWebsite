namespace StarFishWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ButtonClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Buttons",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        value = c.Int(nullable: false),
                        image_ID = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Images", t => t.image_ID)
                .Index(t => t.image_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Buttons", "image_ID", "dbo.Images");
            DropIndex("dbo.Buttons", new[] { "image_ID" });
            DropTable("dbo.Buttons");
        }
    }
}
