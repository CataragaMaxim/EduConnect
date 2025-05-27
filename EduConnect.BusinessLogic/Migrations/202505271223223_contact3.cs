namespace EduConnect.BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contact3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacs", "Subiect", c => c.String(nullable: false, maxLength: 1000));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacs", "Subiect");
        }
    }
}
