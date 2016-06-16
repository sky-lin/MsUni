namespace MsUni.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Candidates",
                c => new
                    {
                        CandidateId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Age = c.Short(nullable: false),
                        City = c.String(),
                        Mobile = c.String(),
                        University = c.String(),
                        Email = c.String(),
                        CandidateImage = c.Binary(),
                        Vote = c.Int(nullable: false),
                        Approved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CandidateId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Candidates");
        }
    }
}
