namespace StarFishWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration4 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Images", "ImageFile");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Images", "ImageFile", c => c.String());
        }
    }
}
