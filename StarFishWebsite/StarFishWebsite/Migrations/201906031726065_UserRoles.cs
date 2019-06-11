namespace StarFishWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserRoles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        IPAddress = c.String(),
                        MachineName = c.String(),
                        LoginTime = c.DateTime(nullable: false),
                        Role_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Roles", t => t.Role_ID)
                .Index(t => t.Role_ID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AccessLevel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Fish", "AccessLevel", c => c.Int(nullable: false));
            AddColumn("dbo.FishTypes", "AccessLevel", c => c.Int(nullable: false));
            AddColumn("dbo.Foods", "AccessLevel", c => c.Int(nullable: false));
            AddColumn("dbo.FoodTypes", "AccessLevel", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Logins", "Role_ID", "dbo.Roles");
            DropIndex("dbo.Logins", new[] { "Role_ID" });
            DropColumn("dbo.FoodTypes", "AccessLevel");
            DropColumn("dbo.Foods", "AccessLevel");
            DropColumn("dbo.FishTypes", "AccessLevel");
            DropColumn("dbo.Fish", "AccessLevel");
            DropTable("dbo.Roles");
            DropTable("dbo.Logins");
        }
    }
}
