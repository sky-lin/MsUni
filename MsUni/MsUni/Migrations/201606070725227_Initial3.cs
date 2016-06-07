namespace MsUni.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Votes",
                c => new
                    {
                        VoteId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        UserIP = c.String(),
                        VoteTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.VoteId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Votes");
        }
    }
}
