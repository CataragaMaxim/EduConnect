namespace EduConnect.BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCommentsSupport : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UDbComments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ThreadId = c.Int(nullable: false),
                        Author = c.String(nullable: false),
                        Content = c.String(nullable: false, maxLength: 1024),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UDbThreads", t => t.ThreadId, cascadeDelete: true)
                .Index(t => t.ThreadId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UDbComments", "ThreadId", "dbo.UDbThreads");
            DropIndex("dbo.UDbComments", new[] { "ThreadId" });
            DropTable("dbo.UDbComments");
        }
    }
}
