namespace MsUni.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "Age", c => c.Short(nullable: false));
            AddColumn("dbo.Contacts", "Mobile", c => c.String());
            AddColumn("dbo.Contacts", "University", c => c.String());
            DropColumn("dbo.Contacts", "State");
            DropColumn("dbo.Contacts", "Zip");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contacts", "Zip", c => c.String());
            AddColumn("dbo.Contacts", "State", c => c.String());
            DropColumn("dbo.Contacts", "University");
            DropColumn("dbo.Contacts", "Mobile");
            DropColumn("dbo.Contacts", "Age");
        }
    }
}
