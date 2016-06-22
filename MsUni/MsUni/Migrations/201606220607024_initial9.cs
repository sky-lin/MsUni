namespace MsUni.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Candidates", "Job", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Candidates", "Job");
        }
    }
}
