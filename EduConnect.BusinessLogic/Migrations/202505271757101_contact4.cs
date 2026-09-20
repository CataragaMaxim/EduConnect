namespace EduConnect.BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contact4 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Contacs", newName: "Contacts");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Contacts", newName: "Contacs");
        }
    }
}
