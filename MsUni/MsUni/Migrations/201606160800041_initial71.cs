namespace MsUni.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial71 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Contacts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Age = c.Short(nullable: false),
                        Address = c.String(),
                        City = c.String(),
                        Mobile = c.String(),
                        University = c.String(),
                        Email = c.String(),
                        Vote = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ContactId);
            
        }
    }
}
