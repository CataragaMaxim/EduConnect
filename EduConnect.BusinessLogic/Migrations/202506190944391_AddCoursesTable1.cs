namespace EduConnect.BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCoursesTable1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VideoItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 128),
                        VideoUrl = c.String(nullable: false),
                        Order = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UDbCourses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
            AlterColumn("dbo.UDbCourses", "Description", c => c.String(maxLength: 2048));
            AlterColumn("dbo.UDbCourses", "Category", c => c.String(nullable: false, maxLength: 64));
            DropColumn("dbo.UDbCourses", "VideoUrl");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UDbCourses", "VideoUrl", c => c.String());
            DropForeignKey("dbo.VideoItems", "CourseId", "dbo.UDbCourses");
            DropIndex("dbo.VideoItems", new[] { "CourseId" });
            AlterColumn("dbo.UDbCourses", "Category", c => c.String(nullable: false));
            AlterColumn("dbo.UDbCourses", "Description", c => c.String(nullable: false, maxLength: 2048));
            DropTable("dbo.VideoItems");
        }
    }
}
