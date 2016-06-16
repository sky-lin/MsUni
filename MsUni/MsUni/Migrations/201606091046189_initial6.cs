namespace MsUni.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Images", "UserId", c => c.String());
            AddColumn("dbo.Images", "ImageType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Images", "ImageType");
            DropColumn("dbo.Images", "UserId");
        }
    }
}
