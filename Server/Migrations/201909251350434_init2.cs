namespace Server.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Domains",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        Success = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.TestPings");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TestPings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Domain = c.String(),
                        Success = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.Domains");
        }
    }
}
