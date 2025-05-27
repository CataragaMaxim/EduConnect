namespace EduConnect.BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contact2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contacs", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Contacs", "Email", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Contacs", "Message", c => c.String(nullable: false, maxLength: 1000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contacs", "Message", c => c.String(maxLength: 1000));
            AlterColumn("dbo.Contacs", "Email", c => c.String(maxLength: 100));
            AlterColumn("dbo.Contacs", "Name", c => c.String(maxLength: 100));
        }
    }
}
