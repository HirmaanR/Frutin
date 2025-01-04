namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit_contactModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "CreateDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "CreateDate");
        }
    }
}
