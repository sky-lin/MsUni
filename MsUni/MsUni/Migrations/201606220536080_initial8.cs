namespace MsUni.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial8 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Candidates", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Candidates", "Mobile", c => c.String(nullable: false));
            AlterColumn("dbo.Candidates", "University", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Candidates", "University", c => c.String());
            AlterColumn("dbo.Candidates", "Mobile", c => c.String());
            AlterColumn("dbo.Candidates", "Name", c => c.String());
        }
    }
}
