namespace MsUni.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Candidates", "CandidateImageId", c => c.Int(nullable: false));
            DropColumn("dbo.Candidates", "CandidateImage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Candidates", "CandidateImage", c => c.Binary());
            DropColumn("dbo.Candidates", "CandidateImageId");
        }
    }
}
