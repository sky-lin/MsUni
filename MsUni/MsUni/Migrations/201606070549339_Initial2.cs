namespace MsUni.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "Vote", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "Vote");
        }
    }
}
