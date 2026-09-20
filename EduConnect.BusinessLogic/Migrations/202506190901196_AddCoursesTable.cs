namespace EduConnect.BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCoursesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UDbCourses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 128),
                        Description = c.String(nullable: false, maxLength: 2048),
                        Category = c.String(nullable: false),
                        AccessLevel = c.String(nullable: false),
                        AllowedUsers = c.String(),
                        VideoUrl = c.String(),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UDbCourses");
        }
    }
}
