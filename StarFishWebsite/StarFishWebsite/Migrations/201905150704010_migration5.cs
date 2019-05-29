namespace StarFishWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Images", "ImageFile", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Images", "ImageFile");
        }
    }
}
