namespace EduConnect.BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UDbThreads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 128),
                        Author = c.String(nullable: false),
                        Category = c.String(nullable: false),
                        Description = c.String(maxLength: 2048),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UDbTables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 30),
                        Password = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 30),
                        LastLogin = c.DateTime(nullable: false),
                        Level = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UDbTables");
            DropTable("dbo.UDbThreads");
        }
    }
}
